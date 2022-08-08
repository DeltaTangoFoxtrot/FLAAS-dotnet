using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace webapp.models
{
    public static class RouteManager
    {
        private const string fileName = "./routes.json";

        private static IEnumerable<Route> _routes = Enumerable.Empty<Route>();
        private static object mutex = new Object();

        public static bool AddRoute(Route route)
        {
            lock(mutex)
            {
                var newRoutes = _routes.OrderByDescending(r => r.CreatedOn)
                    .Take(99)
                    .Where(r => r.Path != route.Path)
                    .Append(route);
                
                try
                {
                    var routesText = JsonSerializer.Serialize(newRoutes);
                    using (var sw = new StreamWriter(File.Open(fileName, FileMode.Create)))
                    {
                        sw.Write(routesText);
                    }
                    _routes = newRoutes;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"could not open routes file. {ex.Message}");
                    return false;
                }
            }
            return true;
        }

        public static Page? GetRoute(string route)
        {
            if (!(_routes?.Any() ?? false))
            {
                lock(mutex)
                {
                    if (!(_routes?.Any() ?? false)
                        && File.Exists(fileName))
                    {
                        try
                        {
                            var pageData = File.ReadAllText(fileName);
                            var routes = JsonSerializer.Deserialize<IEnumerable<Route>>(pageData);
                            if (routes?.Any() ?? false)
                                _routes = routes;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"could not open routes file. {ex.Message}");
                        }
                    }
                }
            }
            return _routes
                ?.FirstOrDefault(r => string.Equals(r.Path, route, StringComparison.OrdinalIgnoreCase))
                ?.Page;
        }
    }
}
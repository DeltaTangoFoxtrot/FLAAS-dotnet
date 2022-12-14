using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.models
{
    public static class Routing
    {
        public static IResult Index()
        {
            return Results.Ok("https://github.com/DeltaTangoFoxtrot/FLAAS-dotnet");
        }

        public static IResult RootGet(string route)
        {
            var page = RouteManager.GetRoute(route) ?? new Page();
            page.HtmlEncode();
            
            var body = HtmlGenerator.Generate(page);
            return new HtmlResult(body);
        }

        public static IResult RootPost(string route, Page? page)
        {
            if (page == null)
            {
                return Results.Problem("Body required - see documentation at https://github.com/DeltaTangoFoxtrot/FLAAS-dotnet");
            }
            var model = new Route(route, page);
            RouteManager.AddRoute(model);

            var body = HtmlGenerator.Generate(page);
            return new HtmlResult(body);
        }
    }
}
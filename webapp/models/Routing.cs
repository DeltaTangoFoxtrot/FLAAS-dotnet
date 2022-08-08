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
            return Results.Ok();
        }
        
        public static IResult RootGet(string route)
        {
            return Results.Ok(route);
        }

        public static IResult RootPost(string route)
        {
            return Results.Ok(route);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.models
{
    public class Route
    {
        public Route(string? _path, Page? _page)
        {
            Path = _path ?? "";
            Page = _page ?? new Page();
        }

        public Route()
        {
            Path = "";
            Page = new Page();
        }

        public string Path {get; set;}
        public Page Page {get; set;}
        public readonly DateTime CreatedOn = DateTime.Now;
    }
}
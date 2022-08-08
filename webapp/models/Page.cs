using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.models
{
    public class Page
    {
        public string? Title {get; set;}
        public string? Image {get; set;}
        public string? Description {get; set;}
        public string? Redirect {get; set;}
        public string? Url {get; set;}
        public string? Type {get; set;}
    }
}
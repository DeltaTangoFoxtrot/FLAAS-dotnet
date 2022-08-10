using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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

        public void HtmlEncode()
        {
            Title = HttpUtility.HtmlEncode(Title);
            Image = HttpUtility.HtmlEncode(Image);
            Description = HttpUtility.HtmlEncode(Description);
            Redirect = HttpUtility.HtmlEncode(Redirect);
            Url = HttpUtility.HtmlEncode(Url);
            Type = HttpUtility.HtmlEncode(Type);
        }
    }
}
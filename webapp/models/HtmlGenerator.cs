using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapp.models
{
    public static class HtmlGenerator
    {
        private static string PageContent
            => "<img src='https://i.imgur.com/z5ux7q9.png' alt='You fell for it fool' style='max-width: 100vw;max-height: 100vh;' />";
        
        private static string BuildLine(string name, string? value, string fallback = "")
            => $"<meta property='og:{name}' content='{value ?? fallback}' />";

        public static string GenerateHead(Page page)
        {
            var sb = new StringBuilder();

            sb.Append("<head>");
            sb.Append(BuildLine("title", page.Title));
            sb.Append(BuildLine("image", page.Image));
            sb.Append(BuildLine("description", page.Description));
            sb.Append(BuildLine("url", page.Url));
            sb.Append(BuildLine("type", page.Type));
            sb.Append("</head>");

            return sb.ToString();
        }

        public static string GenerateRedirect(string? redirect)
            => (Uri.IsWellFormedUriString(redirect, UriKind.Absolute))
                ? $"<script type=\"text/javascript\"> window.location.replace(\"{redirect}\")  </script>"
                : string.Empty;

        public static string GenerateBody(Page page)
            => $"<body>{PageContent}{GenerateRedirect(page.Redirect)}</body>";

        public static string Generate(Page page)
            => $"<html>{GenerateHead(page)}{GenerateBody(page)}</html>";
    }
}
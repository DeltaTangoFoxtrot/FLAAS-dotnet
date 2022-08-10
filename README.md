# FLAAS-dotnet
Dot Net port of Facebook Link as a Service

## Usage
There are 3 main routes available in the FLAAS implementation. 
The first is an index which displays a link to documentation.
The second is a POST to any subdirectory on the domain.
The third is a corresponding GET to any subdirectory on the domain.

### "/" GET
Retrieves a link to this repository. 

### "/*" POST
Uses the JSON body of the request to populate a page with Open Graph attributes, and the redirect for the page.
{
  "Title" : "string", //og:title
  "Image" : "string", //og:image
  "Description" : "string", //og:description
  "Url" : "string", //og:url
  "Type" : "string" //og:type
  "Redirect" : "string" //javasript window.location redirect on page load
}

### "/*" GET
Retrieves a page with the prefilled Open Graph attributes, and redirects to next page.
Default behavior is empy attributes and no redirect.

using webapp.models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


app.MapGet("/", Routing.Index);
app.MapGet("/{*route}", Routing.RootGet);
app.MapPost("/{*route}", Routing.RootPost);

app.UseHttpsRedirection();
app.UseStaticFiles();

//start routes cache
RouteManager.GetRoute("");

app.Run();

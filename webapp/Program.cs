using webapp.models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.MapGet("/", Routing.Index);
app.MapGet("/{*route}", Routing.RootGet);
app.MapPost("/{*route}", Routing.RootPost);
app.MapDelete("/{*route}", Routing.RootDelete);

//start routes cache
RouteManager.GetRoute("");

app.Run();

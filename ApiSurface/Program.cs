using ApiSurface.Schema;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<Movie>()
    .AddType<Actor>();

var app = builder.Build();

app.MapGraphQL();
app.MapBananaCakePop();

app.Run();

using Hellang.Middleware.ProblemDetails;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvcCore().AddApiExplorer();
builder.Services.AddSwaggerDocument();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.UseProblemDetails();
app.UseOpenApi();
app.UseSwaggerUi3();

app.MapControllers();

app.Run();

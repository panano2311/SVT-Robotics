
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

builder.Services.AddHttpClient<IRobotsClient, RobotsClient>((services, client) =>
{
    client.BaseAddress = services.GetRequiredService<IConfiguration>().GetValue<Uri>("RobotsApiUrl");
});

var app = builder.Build();

app.MapPost("/api/robots/closest", ClosestHandler.HandleAsync);

app.Run();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("yarp"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapReverseProxy();

app.Run();

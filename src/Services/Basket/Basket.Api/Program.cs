using Basket.Api.Data;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});
builder.Services.AddTransient<IBasketRepository, BasketRespository>();
builder.Services.AddSwaggerDoc();
var app = builder.Build();


app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3();
app.Run();

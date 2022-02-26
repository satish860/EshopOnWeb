using Basket.Api.Data;
using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});
builder.Services.AddTransient<IBasketRepository, BasketRespository>();
var app = builder.Build();


app.UseFastEndpoints();
app.Run();

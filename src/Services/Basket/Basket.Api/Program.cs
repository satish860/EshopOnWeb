using Basket.Api.Data;
using FastEndpoints;
using FastEndpoints.Swagger;
using static Discount.Grpc.DiscountProtoService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});
builder.Services.AddTransient<IBasketRepository, BasketRespository>();
builder.Services.AddSwaggerDoc();
builder.Services.AddGrpcClient<DiscountProtoServiceClient>(options =>
{
    options.Address = new Uri(builder.Configuration.GetValue<string>("GrpcSettings:DiscountUrl"));
});
var app = builder.Build();


app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3();
app.Run();

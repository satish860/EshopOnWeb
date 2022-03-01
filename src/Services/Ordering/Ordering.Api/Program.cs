using FastEndpoints;
using Ordering.Api.Data;
using Ordering.Api.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddTransient<IOrderContext, OrderContext>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
var app = builder.Build();

app.UseFastEndpoints();

app.Run();

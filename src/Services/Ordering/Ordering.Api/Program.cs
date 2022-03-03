using EventBus.Messages.Common;
using FastEndpoints;
using MassTransit;
using Ordering.Api.Data;
using Ordering.Api.EventBus.Consumers;
using Ordering.Api.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddTransient<IOrderContext, OrderContext>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<BasketCheckoutEventHandler>();
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration.GetValue<string>("Rabbitmq:HostUrl"));
        cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c => {
            c.ConfigureConsumer<BasketCheckoutEventHandler>(ctx);
        });
    });
});
builder.Services.AddMassTransitHostedService();
var app = builder.Build();

app.UseFastEndpoints();

app.Run();

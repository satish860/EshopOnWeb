using Discount.Domain.Repository;
using FastEndpoints;
using FastEndpoints.Swagger;
using Marten;
using Weasel.Postgresql;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Marten"));
    options.AutoCreateSchemaObjects = AutoCreate.All;
});
builder.Services.AddFastEndpoints();
builder.Services.AddTransient<IDiscountRepository, DiscountRepository>();
builder.Services.AddSwaggerDoc();
var app = builder.Build();

app.UseFastEndpoints();
app.UseOpenApi(); //add this
app.UseSwaggerUi3(s => s.ConfigureDefaults());
app.Run();

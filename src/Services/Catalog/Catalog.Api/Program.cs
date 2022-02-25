using Catalog.Api.Data;
using Catalog.Api.Repositories;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();


app.UseFastEndpoints();

app.Run();

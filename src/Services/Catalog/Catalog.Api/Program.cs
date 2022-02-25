using Catalog.Api.Data;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
var app = builder.Build();


app.UseFastEndpoints();

app.Run();

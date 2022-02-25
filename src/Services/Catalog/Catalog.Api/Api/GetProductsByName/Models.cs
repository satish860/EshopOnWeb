using Catalog.Api.Entities;
using FastEndpoints.Validation;

namespace Api.GetProductsByName
{
    public class Request
    {
        public string Name { get; set; } = string.Empty;
    }

    public class Response
    {
        public List<Product> Products { get; set; }
    }
}
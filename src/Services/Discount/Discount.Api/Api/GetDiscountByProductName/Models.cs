using Discount.Api.Domain;

namespace Discount.Api.Api.GetDiscountByProductName
{
    public class Request
    {
        public string ProductName { get; set; }
    }

    public class Response
    {
        public IEnumerable<Coupon>  Coupons{ get; set; } = Enumerable.Empty<Coupon>();
    }
}

using Discount.Domain;

namespace Discount.Api.Api.UpdateDiscount
{
    public class Request
    {
        public Coupon Coupon { get; set; }
    }

    public class Response
    {
        public Coupon Coupon { get; set; } 
    }
}

using Discount.Domain;

namespace Discount.Api.Api.CreateDiscount
{
    public class Request
    {
        public Coupon? Coupon { get; set; }
    }

    public class Response
    {
        public Coupon? Coupon { set; get; }
    }
}

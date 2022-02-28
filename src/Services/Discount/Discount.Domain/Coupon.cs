namespace Discount.Domain
{
    public class Coupon
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Amount { get; set; }
    }
}

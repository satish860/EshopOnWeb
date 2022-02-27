using Discount.Api.Domain;

namespace Discount.Api.Repository
{
    public interface IRepository
    {
        Task<Coupon> CreateCoupon(Coupon coupon);
    }
}

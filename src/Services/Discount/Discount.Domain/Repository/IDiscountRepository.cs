using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Repository
{
    public interface IDiscountRepository
    {
        Task<Coupon> CreateCoupon(Coupon coupon);

        Task<IEnumerable<Coupon>> GetCouponsByProductName(string productName);

        Task<bool> UpdateCoupon(Coupon coupon);

        Task DeleteCoupon(string ProductName);
    }
}

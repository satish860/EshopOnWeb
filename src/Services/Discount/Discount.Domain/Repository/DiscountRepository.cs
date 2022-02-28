using Marten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IDocumentStore documentStore;

        public DiscountRepository(IDocumentStore documentStore)
        {
            this.documentStore = documentStore;
        }

        public async Task<Coupon> CreateCoupon(Coupon coupon)
        {
            using (var session = documentStore.LightweightSession())
            {
                session.Store(coupon);
                await session.SaveChangesAsync();
            }
            return coupon;
        }

        public async Task DeleteCoupon(string productName)
        {
            using (var session = documentStore.LightweightSession())
            {
                session.DeleteWhere<Coupon>(p => p.ProductName.Equals(productName));
                await session.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Coupon>> GetCouponsByProductName(string productName)
        {
            using (var session = documentStore.QuerySession())
            {
                return session.Query<Coupon>().Where(p => p.ProductName.Equals(productName)).AsEnumerable();
            }
        }

        public async Task<bool> UpdateCoupon(Coupon coupon)
        {
            using (var session = documentStore.LightweightSession())
            {
                session.Update<Coupon>(coupon);
                await session.SaveChangesAsync();
            }
            return true;
        }
    }
}

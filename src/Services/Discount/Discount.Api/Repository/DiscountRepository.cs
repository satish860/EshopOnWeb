using Discount.Api.Domain;
using Marten;
using System.Linq;

namespace Discount.Api.Repository
{
    public class DiscountRepository : IRepository
    {
        private readonly IDocumentStore documentStore;

        public DiscountRepository(IDocumentStore documentStore)
        {
            this.documentStore = documentStore;
        }

        public async Task<Coupon> CreateCoupon(Coupon coupon)
        {
            using (var session=documentStore.LightweightSession())
            {
                session.Store(coupon);
                await session.SaveChangesAsync();
            }
            return coupon;
        }

        public async Task<IEnumerable<Coupon>> GetCouponsByProductName(string productName)
        {
            using (var session = documentStore.QuerySession())
            {
                return session.Query<Coupon>().Where(p => p.ProductName.Equals(productName));
            }
        }
    }
}

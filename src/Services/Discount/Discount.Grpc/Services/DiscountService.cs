using Discount.Domain.Repository;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService:DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            this.discountRepository = discountRepository;
        }
        public override async Task<GetDiscountResponse> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await this.discountRepository.GetBestCouponByProductName(request.ProductName);
            return new GetDiscountResponse
            {
                Id = coupon.Id.ToString(),
                Amount = (int)coupon.Amount,
                Description = coupon.Description,
                ProductName=coupon.ProductName,
            };
        }
    }
}

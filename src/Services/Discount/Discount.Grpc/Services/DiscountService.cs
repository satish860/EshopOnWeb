using Discount.Domain;
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
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found."));
            }
            return new GetDiscountResponse
            {
                Id = coupon.Id.ToString(),
                Amount = (int)coupon.Amount,
                Description = coupon.Description,
                ProductName=coupon.ProductName,
            };
        }

        public override async Task<CouponModel> CreateDiscount(CouponModel request, ServerCallContext context)
        {
            var coupon = await this.discountRepository.CreateCoupon(new Coupon
            {
                ProductName = request.ProductName,
                Amount = request.Amount,
                Description= request.Description,
            });
            request.Id = coupon.Id.ToString();
            return request;
        }

        public override async Task<CouponModel> UpdateDiscount(CouponModel request, ServerCallContext context)
        {
            var coupon = await this.discountRepository.UpdateCoupon(new Coupon
            {
                Id= new Guid(request.Id),
                ProductName = request.ProductName,
                Amount = request.Amount,
                Description = request.Description,
            });
            return request;
        }

        public override async Task<DeleteResponse> DeleteDiscount(DeleteRequest request, ServerCallContext context)
        {
            await this.discountRepository.DeleteCoupon(request.ProductName);
            return new DeleteResponse
            {
                Sucess = true
            };
        }
    }
}

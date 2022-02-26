using Basket.Api.Entities;

namespace Basket.Api.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCart?> GetShoppingCartAsync(string userName);
    }
}

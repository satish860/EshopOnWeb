using Basket.Api.Entities;

namespace Basket.Api.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCart?> GetShoppingCartAsync(string userName);

        Task<ShoppingCart?> UpdateShoppingCart(ShoppingCart? shoppingCart);

        Task DeleteShoppingCart(string userName);
    }
}

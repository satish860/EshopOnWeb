using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.Api.Data
{
    public class BasketRespository : IBasketRepository
    {
        private readonly IDistributedCache distributedCache;

        public BasketRespository(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public async Task<ShoppingCart?> GetShoppingCartAsync(string userName)
        {
            var shoppingCart = await this.distributedCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(shoppingCart))
                return null;
            return JsonSerializer.Deserialize<ShoppingCart>(shoppingCart);
        }

        public async Task<ShoppingCart?> UpdateShoppingCart(ShoppingCart? shoppingCart)
        {
            if (shoppingCart != null)
                await distributedCache
                        .SetStringAsync(shoppingCart.UserName,JsonSerializer.Serialize(shoppingCart));
            return shoppingCart;
        }
    }
}

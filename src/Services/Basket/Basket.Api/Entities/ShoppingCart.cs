namespace Basket.Api.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = string.Empty;

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(x => x.Price * x.Quantity);
            }
        }
    }
}

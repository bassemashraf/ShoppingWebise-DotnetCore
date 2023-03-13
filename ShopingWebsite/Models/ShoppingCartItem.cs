namespace ShopingWebsite.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemID { get; set; }
        public Pie Pie { set; get; } = default;
        public int Amount { get; set;}
        public string? ShoppingCartID { get; set; }
    }
}

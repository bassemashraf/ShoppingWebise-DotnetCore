namespace ShopingWebsite.Models
{

    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}

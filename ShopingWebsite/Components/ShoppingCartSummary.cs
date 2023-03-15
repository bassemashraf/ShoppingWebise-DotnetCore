using Microsoft.AspNetCore.Mvc;
using ShopingWebsite.Models;
using ShopingWebsite.ViewModels;

namespace ShopingWebsite.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;
        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
              _shoppingCart = shoppingCart;
            
        }
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var shoppingcartviewmodel = new ShoppingCartViewModel(_shoppingCart,
                _shoppingCart.GetShoppingCartTotal());
            return View(shoppingcartviewmodel);
            
        }
    }
}

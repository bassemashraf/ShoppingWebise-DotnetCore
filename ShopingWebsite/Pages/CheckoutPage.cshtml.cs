using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopingWebsite.Models;

namespace ShopingWebsite.Pages
{
    public class CheckoutPageModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;
        [BindProperty]
        public Order Order { get; set; }
        public CheckoutPageModel( IShoppingCart shoppingCart, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid) 
            {
                    return Page();
            }
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your Shopping Cart IS Empty Add some Pies First");
            }
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(Order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return Page();
        }

    }
}

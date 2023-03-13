using Microsoft.AspNetCore.Mvc;
using ShopingWebsite.Models;
using ShopingWebsite.ViewModels;

namespace ShopingWebsite.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _PieRepository;
        private readonly IShoppingCart _shoppingCart;
        public ShoppingCartController(IPieRepository pieRepository , IShoppingCart shoppingCart)
        {
            _PieRepository = pieRepository;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var shoppingcartviewmodel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
            return View(shoppingcartviewmodel);
        }
        public RedirectToActionResult AddToShoppingCart(int pieid)
        {
            var selectedPie = _PieRepository.AllPies.FirstOrDefault(p => p.PieId == pieid);
            if (selectedPie != null) 
            {
                _shoppingCart.AddToCart(selectedPie);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveToShoppingCart(int pieid)
        {
            var selectedPie = _PieRepository.AllPies.FirstOrDefault(p => p.PieId == pieid);
            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");
        }

    }
}

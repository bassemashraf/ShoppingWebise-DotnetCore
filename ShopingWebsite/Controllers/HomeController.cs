using Microsoft.AspNetCore.Mvc;
using ShopingWebsite.Models;
using ShopingWebsite.ViewModels;

namespace ShopingWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _PieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            _PieRepository = pieRepository;
            
        }
        public IActionResult Index()
        {
            var piesoftheweek = _PieRepository.PiesOfTheweek;
            var homeviewmodel = new HomeViewModel(piesoftheweek);
            return View(homeviewmodel);
        }
    }
}

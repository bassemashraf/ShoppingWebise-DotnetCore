using Microsoft.AspNetCore.Mvc;
using ShopingWebsite.Models;
using ShopingWebsite.ViewModels;

namespace ShopingWebsite.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _PieRepository;
        private readonly ICategoryRepository _CategoryReposiory;
        public PieController(IPieRepository pieRepository , ICategoryRepository categoryRepository)
        {
            _PieRepository = pieRepository;
            _CategoryReposiory = categoryRepository;
        }
        public IActionResult List() 
        {
            PieListViewModel pieListViewModel = new PieListViewModel
                (_PieRepository.AllPies , "Cheese Cakes");
            return View(pieListViewModel);
        }
    }
}

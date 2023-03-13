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
                (_PieRepository.AllPies , "All Pies");
            return View(pieListViewModel);
        }
        public IActionResult Details(int id)
        {
            var pie = _PieRepository.GetPieById(id);
            if (pie == null) 
                return NotFound(); 
            return View(pie);
        }
    }
}

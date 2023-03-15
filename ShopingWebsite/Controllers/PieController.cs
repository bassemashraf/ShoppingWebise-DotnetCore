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
        public ViewResult List(string Category) 
        {
            IEnumerable<Pie> Pies;
            String? CurrentCategory;
            if (Category == null)
            {
                Pies = _PieRepository.AllPies;
                CurrentCategory = "All Pies";

            }
            else 
            {
                Pies = _PieRepository.AllPies.Where(PI => PI.Category.CategoryName == Category).OrderBy(P => P.PieId);
                CurrentCategory = _CategoryReposiory.AllCategories.FirstOrDefault(ca=> ca.CategoryName== Category)?.CategoryName ;
            }
            
            return View(new PieListViewModel(Pies,CurrentCategory));
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

using Microsoft.AspNetCore.Mvc;
using ShopingWebsite.Models;

namespace ShopingWebsite.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _CategoryReposiory;
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _CategoryReposiory = categoryRepository;
        }
        public IViewComponentResult Invoke() 
          {
            var categories = _CategoryReposiory.AllCategories.OrderBy(cat => cat.CategoryName);
            return View(categories);
        }
    }
}

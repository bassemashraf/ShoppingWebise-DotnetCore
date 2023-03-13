using System.Linq;

namespace ShopingWebsite.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShoppingDBContext _dbContext;
        public CategoryRepository(ShoppingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> AllCategories => _dbContext.Categories.OrderBy(p => p.CategoryName);
    }
}

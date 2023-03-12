using System.Linq;

namespace ShopingWebsite.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopingDBContext _dbContext;
        public CategoryRepository(ShopingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> AllCategories => _dbContext.Categories.OrderBy(p => p.CategoryName);
    }
}

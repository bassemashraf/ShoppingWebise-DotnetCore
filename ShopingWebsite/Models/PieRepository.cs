using Microsoft.EntityFrameworkCore;

namespace ShopingWebsite.Models
{
    public class PieRepository  :IPieRepository
    {
        private readonly ShoppingDBContext _dbContext;
        public PieRepository(ShoppingDBContext dbContext )
        {

            _dbContext = dbContext;

        }

        public IEnumerable<Pie> AllPies 
        {
            get 
            { 
                return _dbContext.Pies.Include( c => c.Category); 
            }
        }

        public IEnumerable<Pie> PiesOfTheweek 
        {
            get
            {
                return _dbContext.Pies.Include(c => c.Category).Where(p =>
            p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int id)
        {
            return _dbContext.Pies.FirstOrDefault(p =>
          p.PieId == id);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _dbContext.Pies.Where(p => p.Name.Contains(searchQuery)); 
        }
    }
}

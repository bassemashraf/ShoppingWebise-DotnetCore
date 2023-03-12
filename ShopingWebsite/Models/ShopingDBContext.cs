using Microsoft.EntityFrameworkCore;

namespace ShopingWebsite.Models
{
    public class ShopingDBContext :DbContext
    {
        public ShopingDBContext(DbContextOptions<ShopingDBContext> 
            options ) : base(options) 
        {
            
        }
        public  DbSet<Pie> Pies { get; set; }
        public  DbSet<Category> Categories { get; set; }
    }
}

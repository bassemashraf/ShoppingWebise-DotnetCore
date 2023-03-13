using Microsoft.EntityFrameworkCore;

namespace ShopingWebsite.Models
{
    public class ShoppingDBContext :DbContext
    {
        public ShoppingDBContext(DbContextOptions<ShoppingDBContext> 
            options ) : base(options) 
        {
            
        }
        public  DbSet<Pie> Pies { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}

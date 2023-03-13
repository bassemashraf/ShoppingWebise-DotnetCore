using ShopingWebsite.Models;

namespace ShopingWebsite.ViewModels
{
    public class HomeViewModel
    {
         public IEnumerable <Pie> PiesOfTheWeek { get; }
        public HomeViewModel(IEnumerable<Pie> piesOfTheWeek )
        {
            PiesOfTheWeek = piesOfTheWeek;
            
        }
    }
}

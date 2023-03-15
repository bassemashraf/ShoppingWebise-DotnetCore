using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopingWebsite.Pages
{
    public class CheckoutCompletePageModelModel : PageModel
    {
        public void OnGet()
        {
            ViewData["CheckoutCompleteMessage"] = "CheckOut Complete , You WIll Enjoy Our Pies";
            
        }
    }
}

 using Microsoft.AspNetCore.Mvc;

namespace ShopingWebsite.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

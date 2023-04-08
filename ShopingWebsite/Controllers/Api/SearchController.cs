using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using ShopingWebsite.Models;

namespace ShopingWebsite.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _PieRepository;
        public SearchController(IPieRepository pieRepository)
        {
            _PieRepository = pieRepository;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var allPies = _PieRepository.AllPies; 
            return Ok(allPies);  
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id) 
        {
            if (!_PieRepository.AllPies.Any(p => p.PieId == id))
                return NotFound();
            return Ok(_PieRepository.AllPies.Where(p => p.PieId == id));

        }
        [HttpPost]
        public IActionResult SearchPies([FromBody]string searchQuery)
        {
            IEnumerable <Pie> pies = new List<Pie>();
            if (!string.IsNullOrEmpty(searchQuery)) 
            {
                pies = _PieRepository.SearchPies(searchQuery);
            }
            return new JsonResult(pies); 
        }
    }
}

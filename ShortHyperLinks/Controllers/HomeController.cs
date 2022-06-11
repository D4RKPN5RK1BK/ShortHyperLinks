using Microsoft.AspNetCore.Mvc;
using ShortHyperLinks.Data;

namespace ShortHyperLinks.Controllers
{
    public class HomeController : Controller
    {
        private readonly SHLContext _context;
        public HomeController(SHLContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}

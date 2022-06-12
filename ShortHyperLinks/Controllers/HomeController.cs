using Microsoft.AspNetCore.Mvc;
using ShortHyperLinks.Data;
using ShortHyperLinks.Models;

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
            IEnumerable<HyperLink> model = _context.HyperLinks;
            return View(model);
        }
    }
}

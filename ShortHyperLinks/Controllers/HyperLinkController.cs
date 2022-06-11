using Microsoft.AspNetCore.Mvc;
using ShortHyperLinks.Data;

namespace ShortHyperLinks.Controllers
{
    public class HyperLinkController : Controller
    {
        private readonly SHLContext _context;
        public HyperLinkController(SHLContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(HyperLink model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            return View();
        }

        [HttpPost]
        public IActionResult Upadate(HyperLink model)
        {

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Read(int id)
        {

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ShortHyperLinks.Data;
using ShortHyperLinks.Models;
using ShortHyperLinks.Models.Abstractions;

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
            IEnumerable<HyperLink> model = _context.HyperLinks;
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create([FromBody]HyperLinkForm model)
        {
            
            if (ModelState.IsValid)
            {
                if (_context.HyperLinks.Any(o => o.Link == model.Link) && _context.HyperLinks.Count() > 0)
                    return PartialView("CreatePartial", _context.HyperLinks.First(o => o.Link == model.Link));

                HyperLink link = new HyperLink();
                link.Clicks = 0;
                link.Link = model.Link;
                link.Hash = Guid.NewGuid().ToString();
                link.ShortLink = $"{Request.Host}/link/{link.Hash}";
                link.Created = DateTime.Now;
                link.Updated = DateTime.Now;

                
                _context.Add(link);
                _context.SaveChanges();
                return PartialView("CreatePartial", link);
            }
            return PartialView("CreatePartial", new HyperLink());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return PartialView(_context.HyperLinks.First(o => o.Id == id));
        }

        [HttpPut]
        public IActionResult Edit([FromBody]HyperLinkForm model)
        {
            HyperLink link = _context.HyperLinks.First(o => o.Id == model.Id);
            if (ModelState.IsValid)
            {
                link.Link = model.Link;
                link.Hash = Guid.NewGuid().ToString();
                link.ShortLink = $"{Request.Host}/link/{link.Hash}";
                link.Updated = DateTime.Now;
                link.Clicks = 0;
                _context.HyperLinks.Update(link);
                _context.SaveChanges();
            }
            return PartialView(link);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]int id)
        {
            if (_context.HyperLinks.Any(o => o.Id == id))
            {
                _context.HyperLinks.Remove(_context.HyperLinks.First(o => o.Id == id));
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Read(int id)
        {
            if (_context.HyperLinks.Any(o => o.Id == id))
            {
                return PartialView(_context.HyperLinks.First(o => o.Id == id));
            }
            return NotFound();
        }

        [Route("/link/{id?}")]
        public IActionResult RedirectToURL(string id)
        {
            if (_context.HyperLinks.Any(o => o.Hash == id))
            {
                HyperLink link = _context.HyperLinks.First(o => o.Hash == id);
                link.Clicks++;
                _context.Update(link);
                _context.SaveChanges();
                return Redirect(link.Link);
            }
            else
            {
                return NotFound();
            }
        }

    }
}

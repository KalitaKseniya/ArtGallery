using ArtGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Controllers
{
    public class PainterController : Controller
    {
        private readonly RepositoryContext db;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreatePainter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePainter(Painter painter)
        {
            if (ModelState.IsValid)
            {
                db.Painters.Add(painter);
                db.SaveChanges();
                return RedirectToAction("Painters");
            }
            return View(painter);
        }

        public async Task<ViewResult> Painters()
        {
            IEnumerable<Painter> painters = await db.Painters.OrderBy(p => p.LastName).ToListAsync();
            return View(painters);
        }
    }
}

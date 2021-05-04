using ArtGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Controllers
{
  //  [ApiController]
    //[Route("Painter")]
    public class PainterController : Controller
    {
        private readonly RepositoryContext db;

        public PainterController(RepositoryContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Painter p)
        {
            if (ModelState.IsValid)
            {
                await db.Painters.AddAsync(p);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Painter> ps = await db.Painters.ToListAsync();
            return View(ps);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var p = await db.Painters.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Painter p)
        {
            if (ModelState.IsValid)
            {
                db.Painters.Update(p);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var p = db.Painters.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            db.Painters.Remove(p);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

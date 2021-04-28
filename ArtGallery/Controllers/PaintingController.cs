using ArtGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ArtGallery.Controllers
{//public class ArtList
//    {
//        public SelectList ArtMovementList { get; set; }
//        public List<int> SelectedArtMovementIds { get; set; }
//    }
    public class PaintingController : Controller
    {
        private readonly RepositoryContext db;

        public PaintingController(RepositoryContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var painters = db.Painters.ToList();
            ViewBag.Painters = new SelectList(painters, "Id", "LastName");
            var arts = db.ArtMovements.ToList();
            ViewBag.ArtMovements = new MultiSelectList(arts, "Id", "Name");//doesn't work - can't write multiple values in List<ArtMovement>
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Painting p)
        {
            if (ModelState.IsValid)
            {
                await db.Paintings.AddAsync(p);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Painting> ps = await db.Paintings.ToListAsync();
            return View(ps);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var p = await db.Paintings.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }
            var painters = db.Painters.ToList();
            ViewBag.Painters = new SelectList(painters, "Id", "LastName");
            var arts = db.ArtMovements.ToList();
            ViewBag.ArtMovements = new MultiSelectList(arts, "Id", "Name");//doesn't work - can't write multiple values in List<ArtMovement>

            return View(p);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Painting p)
        {
            if (ModelState.IsValid)
            {
                db.Paintings.Update(p);
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
            var p = db.Paintings.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            db.Paintings.Remove(p);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

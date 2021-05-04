using ArtGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Controllers
{
    [Route("[controller]/[action]")]
    public class ArtMovementController : Controller
    {
        private readonly RepositoryContext db;

        public ArtMovementController(RepositoryContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArtMovement art)
        {
            if (ModelState.IsValid)
            {
                await db.ArtMovements.AddAsync(art);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(art);
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ArtMovement> arts = await db.ArtMovements.ToListAsync();
            return View(arts);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var art = await db.ArtMovements.FindAsync(id);
            if (art == null)
            {
                return NotFound();
            }
            return View(art);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ArtMovement art)
        {
            if (ModelState.IsValid)
            {
                db.ArtMovements.Update(art);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(art);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var art = db.ArtMovements.Find(id);
            if (art == null)
            {
                return NotFound();
            }
            db.ArtMovements.Remove(art);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

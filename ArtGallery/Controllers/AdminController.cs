using ArtGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Controllers
{
    public class AdminController : Controller
    {
        private readonly RepositoryContext db;

        public AdminController(RepositoryContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                await db.Admins.AddAsync(admin);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Admin> admins = await db.Admins.ToListAsync();
            return View(admins);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            var admin = await db.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Update(admin);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var admin = db.Admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }
            db.Admins.Remove(admin);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

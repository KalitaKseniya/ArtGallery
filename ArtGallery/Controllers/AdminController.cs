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
        public IActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                await db.Admins.AddAsync(admin);
                await db.SaveChangesAsync();
                return RedirectToAction("Admins");
            }
            return View(admin);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var adminDB = db.Admins.Where(a => a.Login == admin.Login && a.Password == admin.Password).FirstOrDefault();
            if (adminDB == null)
            {
                return Content("Admin not found");
            }
            string authData = $"Admin found: Login: {admin.Login}, password {admin.Password}";
            return Content(authData);
        }
        public async Task<ViewResult> Painters()
        {
            IEnumerable<Painter> painters = await db.Painters.OrderBy(p => p.LastName).ToListAsync();
            return View(painters);
        }
        //get for create
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

        public async Task<IActionResult> Admins()
        {
            IEnumerable<Admin> admins = await db.Admins.ToListAsync();
            return View(admins);
        }

      
        [HttpGet]
        public IActionResult EditAdmin(int? id)
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
            return View(admin);
        }
        [HttpPost]
        public IActionResult EditAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Update(admin);
                db.SaveChanges();
                return RedirectToAction("Admins");
            }
            return View(admin);
        }

        [HttpGet]
        public IActionResult DeleteAdmin(int? id)
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
            return View(admin);
        }
        [HttpPost]
        public IActionResult DeletePostAdmin(int? id)
        {
            var admin = db.Admins.Find(id);
            if(admin == null)
            {
                return NotFound();
            }
            db.Admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Admins");
        }

    }
}

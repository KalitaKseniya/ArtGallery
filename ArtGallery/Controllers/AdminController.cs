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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var adminDB = db.Admins.Where(a => a.Login == admin.Login && a.Password == admin.Password).FirstOrDefault();
            if(adminDB == null)
            {
                return Content("Admin not found");
            }
            string authData = $"Admin found: Login: {admin.Login}, password {admin.Password}";
            return Content(authData);
        }
       // public IEnumerable<Painter> painters { get; set; }
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
            if(ModelState.IsValid)
            {
                db.Painters.Add(painter);
                db.SaveChanges();
                return RedirectToPage("Painters");
            }
            
            return View(painter);
        }
    }
}

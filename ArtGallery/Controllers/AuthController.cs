using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtGallery.Models;

namespace ArtGallery.Controllers
{
    public class AuthController : Controller
    {
        private readonly RepositoryContext db;
        public IActionResult Index()
        {
            return View();
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
    }
}

using ArtGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Controllers
{
    public class Geometry
    {
        public int Altitude { get; set; } // основание
        public int Height { get; set; } // высота

        public double GetArea() // вычисление площади треугольника
        {
            return Altitude * Height / 2;
        }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RepositoryContext db;

        public HomeController(RepositoryContext _db)
        {
            db = _db;
        }
        
        public IActionResult Painters()
        {
            return View(db.Painters.OrderBy(p => p.LastName).ToList());
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

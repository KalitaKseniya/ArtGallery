using ArtGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        public IActionResult painters_list()
        {
            return View(db.Painters.OrderBy(p => p.LastName).ToList());
        }
        [HttpGet]
        public IActionResult paintings_list()
        {
            var paintings = db.Paintings.ToList();
            return View(paintings);
        }
        [HttpGet]
        public async Task<IActionResult> artMovements_list()
        {
            var arts =await db.ArtMovements.ToListAsync();
            return View(arts);
        }
        
        [HttpGet("{id}")]
        public IActionResult painting(int? id)
        {
            var painting = db.Paintings.Find(id);
            if(painting == null)
            {
                return NotFound();
            }
            List<Painting> p = db.Paintings.ToList();
            var cnt = db.Paintings.Count();
            ViewBag.Next = (id == cnt)? 1 : (id + 1);
            ViewBag.Prev = (id == 1)? cnt : (id - 1);
            return View(painting);
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

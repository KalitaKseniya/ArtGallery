using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Controllers
{
    public class ArtMovementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

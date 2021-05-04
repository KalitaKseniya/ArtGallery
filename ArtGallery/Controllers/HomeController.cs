using ArtGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;

namespace ArtGallery.Controllers
{
    [Route("{action=Index}")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RepositoryContext db;
        public HomeController(RepositoryContext _db)
        {
            db = _db;
        }

        [HttpGet("{id}")]
        public ActionResult PainterReport(int? id)
        {
            var p = db.Painters.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text
            string str = $"Имя: {p.FirstName}.\nФамилия: {p.LastName}.\n Отчество: {p.FathersName}.\n " +
                $"Возраст: {p.Age}.\n Место рождения: {p.BirthPlace}.\n Дата рождения: {p.BirthDate.Value.ToLongDateString()}.\n " +
                $"Страна: {p.Country}.\n Дата смерти: {p.DeathDate.Value.ToLongDateString()}.\n Место смерти: {p.DeathPlace}.\n Картины: ";
            foreach(var painting in p.Paintings) 
            {
                str += $"\n\t\"{painting.Name}\"";
            }
            str += ".";
            string str1 = Translit(str);//cyrillic ->latin
            graphics.DrawString(str1, font, PdfBrushes.Black, new PointF(0, 0));

            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = $"Report {Translit($"{p.LastName}")}.pdf";
            return fileStreamResult;

        }

        public static string Translit(string str)
        {
            string[] lat_up = { "A", "B", "V", "G", "D", "E", "Yo", "Zh", "Z", "I", "Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "Kh", "Ts", "Ch", "Sh", "Shch", "\"", "Y", "'", "E", "Yu", "Ya" };
            string[] lat_low = { "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "ts", "ch", "sh", "shch", "\"", "y", "'", "e", "yu", "ya" };
            string[] rus_up = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
            string[] rus_low = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            for (int i = 0; i <= 32; i++)
            {
                str = str.Replace(rus_up[i], lat_up[i]);
                str = str.Replace(rus_low[i], lat_low[i]);
            }
            return str;
        }
      
      
        [HttpGet]
        public IActionResult Painters()
        {
            return View(db.Painters.OrderBy(p => p.LastName).ToList());
        }
        [HttpGet]
        public IActionResult Paintings()
        {
            var paintings = db.Paintings.ToList();
            return View(paintings);
        }
        [HttpGet]
        public async Task<IActionResult> ArtMovements()
        {
            var arts = await db.ArtMovements.ToListAsync();
            return View(arts);
        }
        [HttpGet("{id}")]
        public IActionResult Painting(int? id)
        {
            var painting = db.Paintings.Find(id);
            if(painting == null)
            {
                return NotFound();
            }
            //List<Painting> p = db.Paintings.ToList();
            var cnt = db.Paintings.Count();
            ViewBag.Next = (id == cnt)? 1 : (id + 1);
            ViewBag.Prev = (id == 1)? cnt : (id - 1);
            return View(painting);
        }

        [HttpGet("{id}")]
        public ActionResult PaintingReport(int? id)
        {
            var p = db.Paintings.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text
            string str = $"Название: {p.Name}.\nХудожник: {p.Painter.FirstName} {p.Painter.LastName}.\n Материал: {p.Medium}.\n " +
                $"Год написания: {p.Year}.\n Размер: {p.Size_x} см x {p.Size_y} см.";
            foreach (var am in p.ArtMovements)
            {
                str += $"\n\t\"{am.Name}\"";
            }
            str += ".";
            string str1 = Translit(str);//cyrillic ->latin
            graphics.DrawString(str1, font, PdfBrushes.Black, new PointF(0, 0));

            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = $"Report \"{Translit($"{p.Name}")} \".pdf";
            return fileStreamResult;

        }
        [Route("")]
        //[Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

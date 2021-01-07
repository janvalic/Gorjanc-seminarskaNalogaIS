using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gorjanc.Data;
using Gorjanc.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace Gorjanc.Controllers
{
    public class VrhoviController : Controller
    {
        private readonly GorjancContext _context;

        private IWebHostEnvironment Environment;

        public VrhoviController(GorjancContext context, IWebHostEnvironment _enviroment)
        {
            _context = context;
            Environment = _enviroment;
        }

        // GET: Vrhovi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vrhovi.ToListAsync());
        }

        // GET: Vrhovi/Vrh/5
        public async Task<IActionResult> Vrh(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vrh = await _context.Vrhovi
                .FirstOrDefaultAsync(m => m.VrhId == id);
            if (vrh == null)
            {
                return NotFound();
            }

            return View(vrh);
        }
        private bool VrhExists(int id)
        {
            return _context.Vrhovi.Any(e => e.VrhId == id);
        }
        public IActionResult Slike_add()
        {
            return RedirectToAction("Index", "Vrhovi");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Obisk_add(string oseba, int foreignKey)
        {
            var novObisk = new Obisk()
            {
                OsebaId = oseba,
                VrhId = foreignKey,
                Datum = DateTime.Now
            };

            _context.Obiskani.Add(novObisk);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Vrhovi");
        }

        [HttpPost]
        public IActionResult Slike(IFormFile files, int foreignKey)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            string fileName = Path.GetFileName(files.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                files.CopyTo(stream);
                ViewBag.Message = "File uploaded";
                var novaslika = new Slika()
                    {
                        Ime = fileName,
        	            VrhId = foreignKey,
                        DatumSlike = DateTime.Now
                    };
                _context.Slike.Add(novaslika);
                _context.SaveChanges();
            }
            return View();
        }
    }
}

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

namespace Gorjanc.Controllers
{
    public class VrhoviController : Controller
    {
        private readonly GorjancContext _context;

        public VrhoviController(GorjancContext context)
        {
            _context = context;
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

        // GET: Vrhovi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vrhovi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VrhId,Ime,Visina,KoordinateS,KoordinateD")] Vrh vrh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vrh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        public IActionResult Slike_add(IFormFile files, int foreignKey)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    
                    var novaslika = new Slika()
                    {
                        Ime = fileName,
        	            VrhId = foreignKey,
                        DatumSlike = DateTime.Now
                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        novaslika.Img = target.ToArray();
                    }

                    _context.Slike.Add(novaslika);
                    _context.SaveChanges();

                }
            }
            return View();
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
    }
}

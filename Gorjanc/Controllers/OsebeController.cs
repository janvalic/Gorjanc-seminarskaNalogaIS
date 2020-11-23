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

namespace Gorjanc.Controllers
{
    public class OsebeController : Controller
    {
        private readonly GorjancContext _context;

        public OsebeController(GorjancContext context)
        {
            _context = context;
        }

        // GET: Osebe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Osebe.ToListAsync());
        }

        public async Task<IActionResult> Obiskani(String id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oseba = await _context.Osebe
                .Include(o => o.Obiskani)
                    .ThenInclude(v => v.Vrh)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oseba == null)
            {
                return NotFound();
            }

            return View(oseba);
        }

        [HttpPost]
        public IActionResult Slike_add(IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    
                    var objfiles = new Slika()
                    {
                        Ime = fileName,
        	            VrhId = 2,
                        DatumSlike = DateTime.Now
                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.Img = target.ToArray();
                    }

                    _context.Slike.Add(objfiles);
                    _context.SaveChanges();

                }
            }
            return View();
        }
    }
}

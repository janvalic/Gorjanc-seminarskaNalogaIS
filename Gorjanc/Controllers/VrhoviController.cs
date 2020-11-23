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

        public async Task<IActionResult> Test(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vrh = await _context.Vrhovi
                .Include(v => v.Obiskani)
                    .ThenInclude(o => o.Oseba)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.VrhId == id);
            if (vrh == null)
            {
                return NotFound();
            }

            return View(vrh);
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

        // GET: Vrhovi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vrh = await _context.Vrhovi.FindAsync(id);
            if (vrh == null)
            {
                return NotFound();
            }
            return View(vrh);
        }

        // POST: Vrhovi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VrhId,Ime,Visina,KoordinateS,KoordinateD")] Vrh vrh)
        {
            if (id != vrh.VrhId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vrh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VrhExists(vrh.VrhId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vrh);
        }

        // GET: Vrhovi/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Vrhovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vrh = await _context.Vrhovi.FindAsync(id);
            _context.Vrhovi.Remove(vrh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VrhExists(int id)
        {
            return _context.Vrhovi.Any(e => e.VrhId == id);
        }
        public IActionResult Slike_add()
        {
            return View();
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

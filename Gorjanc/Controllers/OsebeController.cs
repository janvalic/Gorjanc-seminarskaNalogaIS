using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gorjanc.Data;
using Gorjanc.Models;

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

        // GET: Osebe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oseba = await _context.Osebe
                .FirstOrDefaultAsync(m => m.OsebaId == id);
            if (oseba == null)
            {
                return NotFound();
            }

            return View(oseba);
        }

        // GET: Osebe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Osebe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OsebaId,Ime,Priimek")] Oseba oseba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oseba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oseba);
        }

        // GET: Osebe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oseba = await _context.Osebe.FindAsync(id);
            if (oseba == null)
            {
                return NotFound();
            }
            return View(oseba);
        }

        // POST: Osebe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OsebaId,Ime,Priimek")] Oseba oseba)
        {
            if (id != oseba.OsebaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oseba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OsebaExists(oseba.OsebaId))
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
            return View(oseba);
        }

        // GET: Osebe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oseba = await _context.Osebe
                .FirstOrDefaultAsync(m => m.OsebaId == id);
            if (oseba == null)
            {
                return NotFound();
            }

            return View(oseba);
        }

        // POST: Osebe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oseba = await _context.Osebe.FindAsync(id);
            _context.Osebe.Remove(oseba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsebaExists(int id)
        {
            return _context.Osebe.Any(e => e.OsebaId == id);
        }
    }
}

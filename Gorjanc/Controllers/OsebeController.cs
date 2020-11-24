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
    public class OsebeController : Controller
    {
        private readonly GorjancContext _context;

        public OsebeController(GorjancContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Obiskani(string id)
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

    }
}

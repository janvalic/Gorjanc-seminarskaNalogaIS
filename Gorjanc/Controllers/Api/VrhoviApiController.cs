using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gorjanc.Data;
using Gorjanc.Models;
using Gorjanc.Filters;

namespace Gorjanc.Controllers_Api
{
    [Route("api/v1/Vrh")]
    [ApiController]
    
    public class VrhoviApiController : ControllerBase
    {
        private readonly GorjancContext _context;

        public VrhoviApiController(GorjancContext context)
        {
            _context = context;
        }

        // GET: api/VrhoviApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vrh>>> GetVrhovi()
        {
            return await _context.Vrhovi.ToListAsync();
        }

        // GET: api/VrhoviApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vrh>> GetVrh(int id)
        {
            var vrh = await _context.Vrhovi.FindAsync(id);

            if (vrh == null)
            {
                return NotFound();
            }

            return vrh;
        }

        // PUT: api/VrhoviApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVrh(int id, Vrh vrh)
        {
            if (id != vrh.VrhId)
            {
                return BadRequest();
            }

            _context.Entry(vrh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VrhExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VrhoviApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vrh>> PostVrh(Vrh vrh)
        {
            _context.Vrhovi.Add(vrh);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVrh", new { id = vrh.VrhId }, vrh);
        }

        // DELETE: api/VrhoviApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vrh>> DeleteVrh(int id)
        {
            var vrh = await _context.Vrhovi.FindAsync(id);
            if (vrh == null)
            {
                return NotFound();
            }

            _context.Vrhovi.Remove(vrh);
            await _context.SaveChangesAsync();

            return vrh;
        }

        private bool VrhExists(int id)
        {
            return _context.Vrhovi.Any(e => e.VrhId == id);
        }
    }
}

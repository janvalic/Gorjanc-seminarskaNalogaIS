using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gorjanc.Data;
using Gorjanc.Models;

namespace Gorjanc.Controllers_Api
{
    [Route("api/v1/Slika")]
    [ApiController]
    public class SlikeApiController : ControllerBase
    {
        private readonly GorjancContext _context;

        public SlikeApiController(GorjancContext context)
        {
            _context = context;
        }

        // GET: api/SlikeApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slika>>> GetSlike()
        {
            return await _context.Slike.ToListAsync();
        }

        // GET: api/SlikeApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Slika>> GetSlika(int id)
        {
            var slika = await _context.Slike.FindAsync(id);

            if (slika == null)
            {
                return NotFound();
            }

            return slika;
        }

        // PUT: api/SlikeApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSlika(int id, Slika slika)
        {
            if (id != slika.SlikaId)
            {
                return BadRequest();
            }

            _context.Entry(slika).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlikaExists(id))
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

        // POST: api/SlikeApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Slika>> PostSlika(Slika slika)
        {
            _context.Slike.Add(slika);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSlika", new { id = slika.SlikaId }, slika);
        }

        // DELETE: api/SlikeApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Slika>> DeleteSlika(int id)
        {
            var slika = await _context.Slike.FindAsync(id);
            if (slika == null)
            {
                return NotFound();
            }

            _context.Slike.Remove(slika);
            await _context.SaveChangesAsync();

            return slika;
        }

        private bool SlikaExists(int id)
        {
            return _context.Slike.Any(e => e.SlikaId == id);
        }
    }
}

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
    [Route("api/v1/Oseba")]
    [ApiController]
    public class OsebeApiController : ControllerBase
    {
        private readonly GorjancContext _context;

        public OsebeApiController(GorjancContext context)
        {
            _context = context;
        }

        // GET: api/OsebeApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oseba>>> GetOsebe()
        {
            return await _context.Osebe.ToListAsync();
        }

        // GET: api/OsebeApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oseba>> GetOseba(string id)
        {
            var oseba = await _context.Osebe.FindAsync(id);

            if (oseba == null)
            {
                return NotFound();
            }

            return oseba;
        }

        // PUT: api/OsebeApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOseba(string id, Oseba oseba)
        {
            if (id != oseba.Id)
            {
                return BadRequest();
            }

            _context.Entry(oseba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OsebaExists(id))
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

        // POST: api/OsebeApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Oseba>> PostOseba(Oseba oseba)
        {
            _context.Osebe.Add(oseba);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OsebaExists(oseba.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOseba", new { id = oseba.Id }, oseba);
        }

        // DELETE: api/OsebeApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Oseba>> DeleteOseba(string id)
        {
            var oseba = await _context.Osebe.FindAsync(id);
            if (oseba == null)
            {
                return NotFound();
            }

            _context.Osebe.Remove(oseba);
            await _context.SaveChangesAsync();

            return oseba;
        }

        private bool OsebaExists(string id)
        {
            return _context.Osebe.Any(e => e.Id == id);
        }
    }
}

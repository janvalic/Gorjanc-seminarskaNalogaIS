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
    [Route("api/v1/Obisk")]
    [ApiController]
    public class ObiskaniApiController : ControllerBase
    {
        private readonly GorjancContext _context;

        public ObiskaniApiController(GorjancContext context)
        {
            _context = context;
        }

        // GET: api/ObiskaniApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Obisk>>> GetObiskani()
        {
            return await _context.Obiskani.ToListAsync();
        }

        // GET: api/ObiskaniApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Obisk>> GetObisk(int id)
        {
            var obisk = await _context.Obiskani.FindAsync(id);

            if (obisk == null)
            {
                return NotFound();
            }

            return obisk;
        }

        // PUT: api/ObiskaniApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObisk(int id, Obisk obisk)
        {
            if (id != obisk.Id)
            {
                return BadRequest();
            }

            _context.Entry(obisk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObiskExists(id))
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

        // POST: api/ObiskaniApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Obisk>> PostObisk(Obisk obisk)
        {
            _context.Obiskani.Add(obisk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObisk", new { id = obisk.Id }, obisk);
        }

        // DELETE: api/ObiskaniApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Obisk>> DeleteObisk(int id)
        {
            var obisk = await _context.Obiskani.FindAsync(id);
            if (obisk == null)
            {
                return NotFound();
            }

            _context.Obiskani.Remove(obisk);
            await _context.SaveChangesAsync();

            return obisk;
        }

        private bool ObiskExists(int id)
        {
            return _context.Obiskani.Any(e => e.Id == id);
        }
    }
}

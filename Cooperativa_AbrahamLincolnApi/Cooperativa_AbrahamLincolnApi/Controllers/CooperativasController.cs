using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cooperativa_AbrahamLincolnApi.Models;

namespace Cooperativa_AbrahamLincolnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CooperativasController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public CooperativasController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/Cooperativas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cooperativa>>> GetCooperativas()
        {
          if (_context.Cooperativas == null)
          {
              return NotFound();
          }
            return await _context.Cooperativas.ToListAsync();
        }

        // GET: api/Cooperativas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cooperativa>> GetCooperativa(int id)
        {
          if (_context.Cooperativas == null)
          {
              return NotFound();
          }
            var cooperativa = await _context.Cooperativas.FindAsync(id);

            if (cooperativa == null)
            {
                return NotFound();
            }

            return cooperativa;
        }

        // PUT: api/Cooperativas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCooperativa(int id, Cooperativa cooperativa)
        {
            if (id != cooperativa.Id)
            {
                return BadRequest();
            }

            _context.Entry(cooperativa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CooperativaExists(id))
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

        // POST: api/Cooperativas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cooperativa>> PostCooperativa(Cooperativa cooperativa)
        {
          if (_context.Cooperativas == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.Cooperativas'  is null.");
          }
            _context.Cooperativas.Add(cooperativa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCooperativa", new { id = cooperativa.Id }, cooperativa);
        }

        // DELETE: api/Cooperativas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCooperativa(int id)
        {
            if (_context.Cooperativas == null)
            {
                return NotFound();
            }
            var cooperativa = await _context.Cooperativas.FindAsync(id);
            if (cooperativa == null)
            {
                return NotFound();
            }

            _context.Cooperativas.Remove(cooperativa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CooperativaExists(int id)
        {
            return (_context.Cooperativas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

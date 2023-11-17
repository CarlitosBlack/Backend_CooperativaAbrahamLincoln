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
    public class TalleresInduccionsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public TalleresInduccionsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/TalleresInduccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TalleresInduccion>>> GetTalleresInduccions()
        {
          if (_context.TalleresInduccions == null)
          {
              return NotFound();
          }
            return await _context.TalleresInduccions.ToListAsync();
        }

        // GET: api/TalleresInduccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TalleresInduccion>> GetTalleresInduccion(int id)
        {
          if (_context.TalleresInduccions == null)
          {
              return NotFound();
          }
            var talleresInduccion = await _context.TalleresInduccions.FindAsync(id);

            if (talleresInduccion == null)
            {
                return NotFound();
            }

            return talleresInduccion;
        }

        // PUT: api/TalleresInduccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTalleresInduccion(int id, TalleresInduccion talleresInduccion)
        {
            if (id != talleresInduccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(talleresInduccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TalleresInduccionExists(id))
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

        // POST: api/TalleresInduccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TalleresInduccion>> PostTalleresInduccion(TalleresInduccion talleresInduccion)
        {
          if (_context.TalleresInduccions == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.TalleresInduccions'  is null.");
          }
            _context.TalleresInduccions.Add(talleresInduccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTalleresInduccion", new { id = talleresInduccion.Id }, talleresInduccion);
        }

        // DELETE: api/TalleresInduccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTalleresInduccion(int id)
        {
            if (_context.TalleresInduccions == null)
            {
                return NotFound();
            }
            var talleresInduccion = await _context.TalleresInduccions.FindAsync(id);
            if (talleresInduccion == null)
            {
                return NotFound();
            }

            _context.TalleresInduccions.Remove(talleresInduccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TalleresInduccionExists(int id)
        {
            return (_context.TalleresInduccions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

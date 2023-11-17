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
    public class ColegiosController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ColegiosController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/Colegios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colegio>>> GetColegios()
        {
          if (_context.Colegios == null)
          {
              return NotFound();
          }
            return await _context.Colegios.ToListAsync();
        }

        // GET: api/Colegios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colegio>> GetColegio(int id)
        {
          if (_context.Colegios == null)
          {
              return NotFound();
          }
            var colegio = await _context.Colegios.FindAsync(id);

            if (colegio == null)
            {
                return NotFound();
            }

            return colegio;
        }

        // PUT: api/Colegios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColegio(int id, Colegio colegio)
        {
            if (id != colegio.Id)
            {
                return BadRequest();
            }

            _context.Entry(colegio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColegioExists(id))
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

        // POST: api/Colegios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colegio>> PostColegio(Colegio colegio)
        {
          if (_context.Colegios == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.Colegios'  is null.");
          }
            _context.Colegios.Add(colegio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColegio", new { id = colegio.Id }, colegio);
        }

        // DELETE: api/Colegios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColegio(int id)
        {
            if (_context.Colegios == null)
            {
                return NotFound();
            }
            var colegio = await _context.Colegios.FindAsync(id);
            if (colegio == null)
            {
                return NotFound();
            }

            _context.Colegios.Remove(colegio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColegioExists(int id)
        {
            return (_context.Colegios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

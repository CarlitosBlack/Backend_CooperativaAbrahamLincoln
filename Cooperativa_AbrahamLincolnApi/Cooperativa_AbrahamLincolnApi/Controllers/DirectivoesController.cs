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
    public class DirectivoesController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public DirectivoesController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/Directivoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Directivo>>> GetDirectivos()
        {
          if (_context.Directivos == null)
          {
              return NotFound();
          }
            return await _context.Directivos.ToListAsync();
        }

        // GET: api/Directivoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Directivo>> GetDirectivo(int id)
        {
          if (_context.Directivos == null)
          {
              return NotFound();
          }
            var directivo = await _context.Directivos.FindAsync(id);

            if (directivo == null)
            {
                return NotFound();
            }

            return directivo;
        }

        // PUT: api/Directivoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectivo(int id, Directivo directivo)
        {
            if (id != directivo.Id)
            {
                return BadRequest();
            }

            _context.Entry(directivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectivoExists(id))
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

        // POST: api/Directivoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Directivo>> PostDirectivo(Directivo directivo)
        {
          if (_context.Directivos == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.Directivos'  is null.");
          }
            _context.Directivos.Add(directivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirectivo", new { id = directivo.Id }, directivo);
        }

        // DELETE: api/Directivoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirectivo(int id)
        {
            if (_context.Directivos == null)
            {
                return NotFound();
            }
            var directivo = await _context.Directivos.FindAsync(id);
            if (directivo == null)
            {
                return NotFound();
            }

            _context.Directivos.Remove(directivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectivoExists(int id)
        {
            return (_context.Directivos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

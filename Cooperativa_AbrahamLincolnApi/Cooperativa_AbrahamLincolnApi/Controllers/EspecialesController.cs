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
    public class EspecialesController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public EspecialesController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/Especiales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especiale>>> GetEspeciales()
        {
          if (_context.Especiales == null)
          {
              return NotFound();
          }
            return await _context.Especiales.ToListAsync();
        }

        // GET: api/Especiales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especiale>> GetEspeciale(int id)
        {
          if (_context.Especiales == null)
          {
              return NotFound();
          }
            var especiale = await _context.Especiales.FindAsync(id);

            if (especiale == null)
            {
                return NotFound();
            }

            return especiale;
        }

        // PUT: api/Especiales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspeciale(int id, Especiale especiale)
        {
            if (id != especiale.Id)
            {
                return BadRequest();
            }

            _context.Entry(especiale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialeExists(id))
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

        // POST: api/Especiales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Especiale>> PostEspeciale(Especiale especiale)
        {
          if (_context.Especiales == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.Especiales'  is null.");
          }
            _context.Especiales.Add(especiale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspeciale", new { id = especiale.Id }, especiale);
        }

        // DELETE: api/Especiales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspeciale(int id)
        {
            if (_context.Especiales == null)
            {
                return NotFound();
            }
            var especiale = await _context.Especiales.FindAsync(id);
            if (especiale == null)
            {
                return NotFound();
            }

            _context.Especiales.Remove(especiale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecialeExists(int id)
        {
            return (_context.Especiales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

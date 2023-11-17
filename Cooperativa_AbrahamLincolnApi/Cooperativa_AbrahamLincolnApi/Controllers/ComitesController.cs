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
    public class ComitesController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ComitesController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/Comites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comite>>> GetComites()
        {
          if (_context.Comites == null)
          {
              return NotFound();
          }
            return await _context.Comites.ToListAsync();
        }

        // GET: api/Comites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comite>> GetComite(int id)
        {
          if (_context.Comites == null)
          {
              return NotFound();
          }
            var comite = await _context.Comites.FindAsync(id);

            if (comite == null)
            {
                return NotFound();
            }

            return comite;
        }

        // PUT: api/Comites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComite(int id, Comite comite)
        {
            if (id != comite.Id)
            {
                return BadRequest();
            }

            _context.Entry(comite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComiteExists(id))
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

        // POST: api/Comites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comite>> PostComite(Comite comite)
        {
          if (_context.Comites == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.Comites'  is null.");
          }
            _context.Comites.Add(comite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComite", new { id = comite.Id }, comite);
        }

        // DELETE: api/Comites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComite(int id)
        {
            if (_context.Comites == null)
            {
                return NotFound();
            }
            var comite = await _context.Comites.FindAsync(id);
            if (comite == null)
            {
                return NotFound();
            }

            _context.Comites.Remove(comite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComiteExists(int id)
        {
            return (_context.Comites?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

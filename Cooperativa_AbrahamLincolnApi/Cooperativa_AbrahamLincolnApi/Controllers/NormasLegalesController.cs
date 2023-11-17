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
    public class NormasLegalesController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public NormasLegalesController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/NormasLegales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NormasLegale>>> GetNormasLegales()
        {
          if (_context.NormasLegales == null)
          {
              return NotFound();
          }
            return await _context.NormasLegales.ToListAsync();
        }

        // GET: api/NormasLegales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NormasLegale>> GetNormasLegale(int id)
        {
          if (_context.NormasLegales == null)
          {
              return NotFound();
          }
            var normasLegale = await _context.NormasLegales.FindAsync(id);

            if (normasLegale == null)
            {
                return NotFound();
            }

            return normasLegale;
        }

        // PUT: api/NormasLegales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNormasLegale(int id, NormasLegale normasLegale)
        {
            if (id != normasLegale.Id)
            {
                return BadRequest();
            }

            _context.Entry(normasLegale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NormasLegaleExists(id))
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

        // POST: api/NormasLegales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NormasLegale>> PostNormasLegale(NormasLegale normasLegale)
        {
          if (_context.NormasLegales == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.NormasLegales'  is null.");
          }
            _context.NormasLegales.Add(normasLegale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNormasLegale", new { id = normasLegale.Id }, normasLegale);
        }

        // DELETE: api/NormasLegales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNormasLegale(int id)
        {
            if (_context.NormasLegales == null)
            {
                return NotFound();
            }
            var normasLegale = await _context.NormasLegales.FindAsync(id);
            if (normasLegale == null)
            {
                return NotFound();
            }

            _context.NormasLegales.Remove(normasLegale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NormasLegaleExists(int id)
        {
            return (_context.NormasLegales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

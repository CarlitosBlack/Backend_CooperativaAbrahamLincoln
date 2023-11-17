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
    public class NormasInternasController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public NormasInternasController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/NormasInternas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NormasInterna>>> GetNormasInternas()
        {
          if (_context.NormasInternas == null)
          {
              return NotFound();
          }
            return await _context.NormasInternas.ToListAsync();
        }

        // GET: api/NormasInternas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NormasInterna>> GetNormasInterna(int id)
        {
          if (_context.NormasInternas == null)
          {
              return NotFound();
          }
            var normasInterna = await _context.NormasInternas.FindAsync(id);

            if (normasInterna == null)
            {
                return NotFound();
            }

            return normasInterna;
        }

        // PUT: api/NormasInternas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNormasInterna(int id, NormasInterna normasInterna)
        {
            if (id != normasInterna.Id)
            {
                return BadRequest();
            }

            _context.Entry(normasInterna).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NormasInternaExists(id))
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

        // POST: api/NormasInternas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NormasInterna>> PostNormasInterna(NormasInterna normasInterna)
        {
          if (_context.NormasInternas == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.NormasInternas'  is null.");
          }
            _context.NormasInternas.Add(normasInterna);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNormasInterna", new { id = normasInterna.Id }, normasInterna);
        }

        // DELETE: api/NormasInternas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNormasInterna(int id)
        {
            if (_context.NormasInternas == null)
            {
                return NotFound();
            }
            var normasInterna = await _context.NormasInternas.FindAsync(id);
            if (normasInterna == null)
            {
                return NotFound();
            }

            _context.NormasInternas.Remove(normasInterna);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NormasInternaExists(int id)
        {
            return (_context.NormasInternas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

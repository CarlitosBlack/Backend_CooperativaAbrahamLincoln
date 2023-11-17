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
    public class RevisionEstructurasController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public RevisionEstructurasController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/RevisionEstructuras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RevisionEstructura>>> GetRevisionEstructuras()
        {
          if (_context.RevisionEstructuras == null)
          {
              return NotFound();
          }
            return await _context.RevisionEstructuras.ToListAsync();
        }

        // GET: api/RevisionEstructuras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RevisionEstructura>> GetRevisionEstructura(int id)
        {
          if (_context.RevisionEstructuras == null)
          {
              return NotFound();
          }
            var revisionEstructura = await _context.RevisionEstructuras.FindAsync(id);

            if (revisionEstructura == null)
            {
                return NotFound();
            }

            return revisionEstructura;
        }

        // PUT: api/RevisionEstructuras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRevisionEstructura(int id, RevisionEstructura revisionEstructura)
        {
            if (id != revisionEstructura.Id)
            {
                return BadRequest();
            }

            _context.Entry(revisionEstructura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RevisionEstructuraExists(id))
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

        // POST: api/RevisionEstructuras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RevisionEstructura>> PostRevisionEstructura(RevisionEstructura revisionEstructura)
        {
          if (_context.RevisionEstructuras == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.RevisionEstructuras'  is null.");
          }
            _context.RevisionEstructuras.Add(revisionEstructura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRevisionEstructura", new { id = revisionEstructura.Id }, revisionEstructura);
        }

        // DELETE: api/RevisionEstructuras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRevisionEstructura(int id)
        {
            if (_context.RevisionEstructuras == null)
            {
                return NotFound();
            }
            var revisionEstructura = await _context.RevisionEstructuras.FindAsync(id);
            if (revisionEstructura == null)
            {
                return NotFound();
            }

            _context.RevisionEstructuras.Remove(revisionEstructura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RevisionEstructuraExists(int id)
        {
            return (_context.RevisionEstructuras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

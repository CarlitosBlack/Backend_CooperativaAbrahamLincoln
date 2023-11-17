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
    public class NormasExternasController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public NormasExternasController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/NormasExternas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NormasExterna>>> GetNormasExternas()
        {
          if (_context.NormasExternas == null)
          {
              return NotFound();
          }
            return await _context.NormasExternas.ToListAsync();
        }

        // GET: api/NormasExternas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NormasExterna>> GetNormasExterna(int id)
        {
          if (_context.NormasExternas == null)
          {
              return NotFound();
          }
            var normasExterna = await _context.NormasExternas.FindAsync(id);

            if (normasExterna == null)
            {
                return NotFound();
            }

            return normasExterna;
        }

        // PUT: api/NormasExternas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNormasExterna(int id, NormasExterna normasExterna)
        {
            if (id != normasExterna.Id)
            {
                return BadRequest();
            }

            _context.Entry(normasExterna).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NormasExternaExists(id))
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

        // POST: api/NormasExternas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NormasExterna>> PostNormasExterna(NormasExterna normasExterna)
        {
          if (_context.NormasExternas == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.NormasExternas'  is null.");
          }
            _context.NormasExternas.Add(normasExterna);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNormasExterna", new { id = normasExterna.Id }, normasExterna);
        }

        // DELETE: api/NormasExternas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNormasExterna(int id)
        {
            if (_context.NormasExternas == null)
            {
                return NotFound();
            }
            var normasExterna = await _context.NormasExternas.FindAsync(id);
            if (normasExterna == null)
            {
                return NotFound();
            }

            _context.NormasExternas.Remove(normasExterna);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NormasExternaExists(int id)
        {
            return (_context.NormasExternas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

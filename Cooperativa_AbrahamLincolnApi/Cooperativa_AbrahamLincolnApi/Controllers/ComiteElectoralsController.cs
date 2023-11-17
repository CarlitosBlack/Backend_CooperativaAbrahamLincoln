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
    public class ComiteElectoralsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ComiteElectoralsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/ComiteElectorals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComiteElectoral>>> GetComiteElectorals()
        {
          if (_context.ComiteElectorals == null)
          {
              return NotFound();
          }
            return await _context.ComiteElectorals.ToListAsync();
        }

        // GET: api/ComiteElectorals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComiteElectoral>> GetComiteElectoral(int id)
        {
          if (_context.ComiteElectorals == null)
          {
              return NotFound();
          }
            var comiteElectoral = await _context.ComiteElectorals.FindAsync(id);

            if (comiteElectoral == null)
            {
                return NotFound();
            }

            return comiteElectoral;
        }

        // PUT: api/ComiteElectorals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComiteElectoral(int id, ComiteElectoral comiteElectoral)
        {
            if (id != comiteElectoral.Id)
            {
                return BadRequest();
            }

            _context.Entry(comiteElectoral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComiteElectoralExists(id))
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

        // POST: api/ComiteElectorals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComiteElectoral>> PostComiteElectoral(ComiteElectoral comiteElectoral)
        {
          if (_context.ComiteElectorals == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.ComiteElectorals'  is null.");
          }
            _context.ComiteElectorals.Add(comiteElectoral);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComiteElectoral", new { id = comiteElectoral.Id }, comiteElectoral);
        }

        // DELETE: api/ComiteElectorals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComiteElectoral(int id)
        {
            if (_context.ComiteElectorals == null)
            {
                return NotFound();
            }
            var comiteElectoral = await _context.ComiteElectorals.FindAsync(id);
            if (comiteElectoral == null)
            {
                return NotFound();
            }

            _context.ComiteElectorals.Remove(comiteElectoral);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComiteElectoralExists(int id)
        {
            return (_context.ComiteElectorals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

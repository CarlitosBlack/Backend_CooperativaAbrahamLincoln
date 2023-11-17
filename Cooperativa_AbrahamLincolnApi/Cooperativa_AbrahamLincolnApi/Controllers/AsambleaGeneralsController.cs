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
    public class AsambleaGeneralsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public AsambleaGeneralsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/AsambleaGenerals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsambleaGeneral>>> GetAsambleaGenerals()
        {
          if (_context.AsambleaGenerals == null)
          {
              return NotFound();
          }
            return await _context.AsambleaGenerals.ToListAsync();
        }

        // GET: api/AsambleaGenerals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsambleaGeneral>> GetAsambleaGeneral(int id)
        {
          if (_context.AsambleaGenerals == null)
          {
              return NotFound();
          }
            var asambleaGeneral = await _context.AsambleaGenerals.FindAsync(id);

            if (asambleaGeneral == null)
            {
                return NotFound();
            }

            return asambleaGeneral;
        }

        // PUT: api/AsambleaGenerals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsambleaGeneral(int id, AsambleaGeneral asambleaGeneral)
        {
            if (id != asambleaGeneral.Id)
            {
                return BadRequest();
            }

            _context.Entry(asambleaGeneral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsambleaGeneralExists(id))
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

        // POST: api/AsambleaGenerals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsambleaGeneral>> PostAsambleaGeneral(AsambleaGeneral asambleaGeneral)
        {
          if (_context.AsambleaGenerals == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.AsambleaGenerals'  is null.");
          }
            _context.AsambleaGenerals.Add(asambleaGeneral);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AsambleaGeneralExists(asambleaGeneral.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAsambleaGeneral", new { id = asambleaGeneral.Id }, asambleaGeneral);
        }

        // DELETE: api/AsambleaGenerals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsambleaGeneral(int id)
        {
            if (_context.AsambleaGenerals == null)
            {
                return NotFound();
            }
            var asambleaGeneral = await _context.AsambleaGenerals.FindAsync(id);
            if (asambleaGeneral == null)
            {
                return NotFound();
            }

            _context.AsambleaGenerals.Remove(asambleaGeneral);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsambleaGeneralExists(int id)
        {
            return (_context.AsambleaGenerals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

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
    public class InfoSocioComiteElectoralsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public InfoSocioComiteElectoralsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/InfoSocioComiteElectorals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoSocioComiteElectoral>>> GetInfoSocioComiteElectorals()
        {
          if (_context.InfoSocioComiteElectorals == null)
          {
              return NotFound();
          }
            return await _context.InfoSocioComiteElectorals.ToListAsync();
        }

        // GET: api/InfoSocioComiteElectorals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoSocioComiteElectoral>> GetInfoSocioComiteElectoral(int id)
        {
          if (_context.InfoSocioComiteElectorals == null)
          {
              return NotFound();
          }
            var infoSocioComiteElectoral = await _context.InfoSocioComiteElectorals.FindAsync(id);

            if (infoSocioComiteElectoral == null)
            {
                return NotFound();
            }

            return infoSocioComiteElectoral;
        }

        // PUT: api/InfoSocioComiteElectorals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoSocioComiteElectoral(int id, InfoSocioComiteElectoral infoSocioComiteElectoral)
        {
            if (id != infoSocioComiteElectoral.Id)
            {
                return BadRequest();
            }

            _context.Entry(infoSocioComiteElectoral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoSocioComiteElectoralExists(id))
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

        // POST: api/InfoSocioComiteElectorals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoSocioComiteElectoral>> PostInfoSocioComiteElectoral(InfoSocioComiteElectoral infoSocioComiteElectoral)
        {
          if (_context.InfoSocioComiteElectorals == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.InfoSocioComiteElectorals'  is null.");
          }
            _context.InfoSocioComiteElectorals.Add(infoSocioComiteElectoral);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoSocioComiteElectoral", new { id = infoSocioComiteElectoral.Id }, infoSocioComiteElectoral);
        }

        // DELETE: api/InfoSocioComiteElectorals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoSocioComiteElectoral(int id)
        {
            if (_context.InfoSocioComiteElectorals == null)
            {
                return NotFound();
            }
            var infoSocioComiteElectoral = await _context.InfoSocioComiteElectorals.FindAsync(id);
            if (infoSocioComiteElectoral == null)
            {
                return NotFound();
            }

            _context.InfoSocioComiteElectorals.Remove(infoSocioComiteElectoral);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoSocioComiteElectoralExists(int id)
        {
            return (_context.InfoSocioComiteElectorals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

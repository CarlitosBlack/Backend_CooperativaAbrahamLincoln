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
    public class InfoGeneralsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public InfoGeneralsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/InfoGenerals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoGeneral>>> GetInfoGenerals()
        {
          if (_context.InfoGenerals == null)
          {
              return NotFound();
          }
            return await _context.InfoGenerals.ToListAsync();
        }

        // GET: api/InfoGenerals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoGeneral>> GetInfoGeneral(int id)
        {
          if (_context.InfoGenerals == null)
          {
              return NotFound();
          }
            var infoGeneral = await _context.InfoGenerals.FindAsync(id);

            if (infoGeneral == null)
            {
                return NotFound();
            }

            return infoGeneral;
        }

        // PUT: api/InfoGenerals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoGeneral(int id, InfoGeneral infoGeneral)
        {
            if (id != infoGeneral.Id)
            {
                return BadRequest();
            }

            _context.Entry(infoGeneral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoGeneralExists(id))
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

        // POST: api/InfoGenerals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoGeneral>> PostInfoGeneral(InfoGeneral infoGeneral)
        {
          if (_context.InfoGenerals == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.InfoGenerals'  is null.");
          }
            _context.InfoGenerals.Add(infoGeneral);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoGeneral", new { id = infoGeneral.Id }, infoGeneral);
        }

        // DELETE: api/InfoGenerals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoGeneral(int id)
        {
            if (_context.InfoGenerals == null)
            {
                return NotFound();
            }
            var infoGeneral = await _context.InfoGenerals.FindAsync(id);
            if (infoGeneral == null)
            {
                return NotFound();
            }

            _context.InfoGenerals.Remove(infoGeneral);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoGeneralExists(int id)
        {
            return (_context.InfoGenerals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

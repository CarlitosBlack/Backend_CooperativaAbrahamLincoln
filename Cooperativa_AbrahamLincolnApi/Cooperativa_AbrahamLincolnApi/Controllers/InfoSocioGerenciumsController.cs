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
    public class InfoSocioGerenciumsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public InfoSocioGerenciumsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/InfoSocioGerenciums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoSocioGerencium>>> GetInfoSocioGerencia()
        {
          if (_context.InfoSocioGerencia == null)
          {
              return NotFound();
          }
            return await _context.InfoSocioGerencia.ToListAsync();
        }

        // GET: api/InfoSocioGerenciums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoSocioGerencium>> GetInfoSocioGerencium(int id)
        {
          if (_context.InfoSocioGerencia == null)
          {
              return NotFound();
          }
            var infoSocioGerencium = await _context.InfoSocioGerencia.FindAsync(id);

            if (infoSocioGerencium == null)
            {
                return NotFound();
            }

            return infoSocioGerencium;
        }

        // PUT: api/InfoSocioGerenciums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoSocioGerencium(int id, InfoSocioGerencium infoSocioGerencium)
        {
            if (id != infoSocioGerencium.Id)
            {
                return BadRequest();
            }

            _context.Entry(infoSocioGerencium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoSocioGerenciumExists(id))
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

        // POST: api/InfoSocioGerenciums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoSocioGerencium>> PostInfoSocioGerencium(InfoSocioGerencium infoSocioGerencium)
        {
          if (_context.InfoSocioGerencia == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.InfoSocioGerencia'  is null.");
          }
            _context.InfoSocioGerencia.Add(infoSocioGerencium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoSocioGerencium", new { id = infoSocioGerencium.Id }, infoSocioGerencium);
        }

        // DELETE: api/InfoSocioGerenciums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoSocioGerencium(int id)
        {
            if (_context.InfoSocioGerencia == null)
            {
                return NotFound();
            }
            var infoSocioGerencium = await _context.InfoSocioGerencia.FindAsync(id);
            if (infoSocioGerencium == null)
            {
                return NotFound();
            }

            _context.InfoSocioGerencia.Remove(infoSocioGerencium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoSocioGerenciumExists(int id)
        {
            return (_context.InfoSocioGerencia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

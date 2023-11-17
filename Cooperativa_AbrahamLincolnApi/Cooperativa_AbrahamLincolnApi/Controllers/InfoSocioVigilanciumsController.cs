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
    public class InfoSocioVigilanciumsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public InfoSocioVigilanciumsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/InfoSocioVigilanciums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoSocioVigilancium>>> GetInfoSocioVigilancia()
        {
          if (_context.InfoSocioVigilancia == null)
          {
              return NotFound();
          }
            return await _context.InfoSocioVigilancia.ToListAsync();
        }

        // GET: api/InfoSocioVigilanciums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoSocioVigilancium>> GetInfoSocioVigilancium(int id)
        {
          if (_context.InfoSocioVigilancia == null)
          {
              return NotFound();
          }
            var infoSocioVigilancium = await _context.InfoSocioVigilancia.FindAsync(id);

            if (infoSocioVigilancium == null)
            {
                return NotFound();
            }

            return infoSocioVigilancium;
        }

        // PUT: api/InfoSocioVigilanciums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoSocioVigilancium(int id, InfoSocioVigilancium infoSocioVigilancium)
        {
            if (id != infoSocioVigilancium.Id)
            {
                return BadRequest();
            }

            _context.Entry(infoSocioVigilancium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoSocioVigilanciumExists(id))
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

        // POST: api/InfoSocioVigilanciums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoSocioVigilancium>> PostInfoSocioVigilancium(InfoSocioVigilancium infoSocioVigilancium)
        {
          if (_context.InfoSocioVigilancia == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.InfoSocioVigilancia'  is null.");
          }
            _context.InfoSocioVigilancia.Add(infoSocioVigilancium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoSocioVigilancium", new { id = infoSocioVigilancium.Id }, infoSocioVigilancium);
        }

        // DELETE: api/InfoSocioVigilanciums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoSocioVigilancium(int id)
        {
            if (_context.InfoSocioVigilancia == null)
            {
                return NotFound();
            }
            var infoSocioVigilancium = await _context.InfoSocioVigilancia.FindAsync(id);
            if (infoSocioVigilancium == null)
            {
                return NotFound();
            }

            _context.InfoSocioVigilancia.Remove(infoSocioVigilancium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoSocioVigilanciumExists(int id)
        {
            return (_context.InfoSocioVigilancia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

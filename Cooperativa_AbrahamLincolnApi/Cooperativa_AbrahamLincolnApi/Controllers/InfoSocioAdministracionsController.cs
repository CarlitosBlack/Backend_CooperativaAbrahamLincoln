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
    public class InfoSocioAdministracionsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public InfoSocioAdministracionsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/InfoSocioAdministracions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoSocioAdministracion>>> GetInfoSocioAdministracions()
        {
          if (_context.InfoSocioAdministracions == null)
          {
              return NotFound();
          }
            return await _context.InfoSocioAdministracions.ToListAsync();
        }

        // GET: api/InfoSocioAdministracions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoSocioAdministracion>> GetInfoSocioAdministracion(int id)
        {
          if (_context.InfoSocioAdministracions == null)
          {
              return NotFound();
          }
            var infoSocioAdministracion = await _context.InfoSocioAdministracions.FindAsync(id);

            if (infoSocioAdministracion == null)
            {
                return NotFound();
            }

            return infoSocioAdministracion;
        }

        // PUT: api/InfoSocioAdministracions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoSocioAdministracion(int id, InfoSocioAdministracion infoSocioAdministracion)
        {
            if (id != infoSocioAdministracion.Id)
            {
                return BadRequest();
            }

            _context.Entry(infoSocioAdministracion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoSocioAdministracionExists(id))
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

        // POST: api/InfoSocioAdministracions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoSocioAdministracion>> PostInfoSocioAdministracion(InfoSocioAdministracion infoSocioAdministracion)
        {
          if (_context.InfoSocioAdministracions == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.InfoSocioAdministracions'  is null.");
          }
            _context.InfoSocioAdministracions.Add(infoSocioAdministracion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoSocioAdministracion", new { id = infoSocioAdministracion.Id }, infoSocioAdministracion);
        }

        // DELETE: api/InfoSocioAdministracions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoSocioAdministracion(int id)
        {
            if (_context.InfoSocioAdministracions == null)
            {
                return NotFound();
            }
            var infoSocioAdministracion = await _context.InfoSocioAdministracions.FindAsync(id);
            if (infoSocioAdministracion == null)
            {
                return NotFound();
            }

            _context.InfoSocioAdministracions.Remove(infoSocioAdministracion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoSocioAdministracionExists(int id)
        {
            return (_context.InfoSocioAdministracions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

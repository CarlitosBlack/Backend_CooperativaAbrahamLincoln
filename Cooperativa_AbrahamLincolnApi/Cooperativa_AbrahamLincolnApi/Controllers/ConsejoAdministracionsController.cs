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
    public class ConsejoAdministracionsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ConsejoAdministracionsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/ConsejoAdministracions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsejoAdministracion>>> GetConsejoAdministracions()
        {
          if (_context.ConsejoAdministracions == null)
          {
              return NotFound();
          }
            return await _context.ConsejoAdministracions.ToListAsync();
        }

        // GET: api/ConsejoAdministracions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsejoAdministracion>> GetConsejoAdministracion(int id)
        {
          if (_context.ConsejoAdministracions == null)
          {
              return NotFound();
          }
            var consejoAdministracion = await _context.ConsejoAdministracions.FindAsync(id);

            if (consejoAdministracion == null)
            {
                return NotFound();
            }

            return consejoAdministracion;
        }

        // PUT: api/ConsejoAdministracions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsejoAdministracion(int id, ConsejoAdministracion consejoAdministracion)
        {
            if (id != consejoAdministracion.Id)
            {
                return BadRequest();
            }

            _context.Entry(consejoAdministracion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsejoAdministracionExists(id))
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

        // POST: api/ConsejoAdministracions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsejoAdministracion>> PostConsejoAdministracion(ConsejoAdministracion consejoAdministracion)
        {
          if (_context.ConsejoAdministracions == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.ConsejoAdministracions'  is null.");
          }
            _context.ConsejoAdministracions.Add(consejoAdministracion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsejoAdministracion", new { id = consejoAdministracion.Id }, consejoAdministracion);
        }

        // DELETE: api/ConsejoAdministracions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsejoAdministracion(int id)
        {
            if (_context.ConsejoAdministracions == null)
            {
                return NotFound();
            }
            var consejoAdministracion = await _context.ConsejoAdministracions.FindAsync(id);
            if (consejoAdministracion == null)
            {
                return NotFound();
            }

            _context.ConsejoAdministracions.Remove(consejoAdministracion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsejoAdministracionExists(int id)
        {
            return (_context.ConsejoAdministracions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

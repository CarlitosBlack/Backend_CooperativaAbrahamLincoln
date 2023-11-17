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
    public class ActaSesionesAdministracionsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ActaSesionesAdministracionsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/ActaSesionesAdministracions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActaSesionesAdministracion>>> GetActaSesionesAdministracions()
        {
          if (_context.ActaSesionesAdministracions == null)
          {
              return NotFound();
          }
            return await _context.ActaSesionesAdministracions.ToListAsync();
        }

        // GET: api/ActaSesionesAdministracions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActaSesionesAdministracion>> GetActaSesionesAdministracion(int id)
        {
          if (_context.ActaSesionesAdministracions == null)
          {
              return NotFound();
          }
            var actaSesionesAdministracion = await _context.ActaSesionesAdministracions.FindAsync(id);

            if (actaSesionesAdministracion == null)
            {
                return NotFound();
            }

            return actaSesionesAdministracion;
        }

        // PUT: api/ActaSesionesAdministracions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActaSesionesAdministracion(int id, ActaSesionesAdministracion actaSesionesAdministracion)
        {
            if (id != actaSesionesAdministracion.Id)
            {
                return BadRequest();
            }

            _context.Entry(actaSesionesAdministracion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActaSesionesAdministracionExists(id))
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

        // POST: api/ActaSesionesAdministracions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActaSesionesAdministracion>> PostActaSesionesAdministracion(ActaSesionesAdministracion actaSesionesAdministracion)
        {
          if (_context.ActaSesionesAdministracions == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.ActaSesionesAdministracions'  is null.");
          }
            _context.ActaSesionesAdministracions.Add(actaSesionesAdministracion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActaSesionesAdministracion", new { id = actaSesionesAdministracion.Id }, actaSesionesAdministracion);
        }

        // DELETE: api/ActaSesionesAdministracions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActaSesionesAdministracion(int id)
        {
            if (_context.ActaSesionesAdministracions == null)
            {
                return NotFound();
            }
            var actaSesionesAdministracion = await _context.ActaSesionesAdministracions.FindAsync(id);
            if (actaSesionesAdministracion == null)
            {
                return NotFound();
            }

            _context.ActaSesionesAdministracions.Remove(actaSesionesAdministracion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActaSesionesAdministracionExists(int id)
        {
            return (_context.ActaSesionesAdministracions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

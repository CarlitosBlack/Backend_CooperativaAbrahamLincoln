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
    public class InfraestructuraProyectoesController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public InfraestructuraProyectoesController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/InfraestructuraProyectoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfraestructuraProyecto>>> GetInfraestructuraProyectos()
        {
          if (_context.InfraestructuraProyectos == null)
          {
              return NotFound();
          }
            return await _context.InfraestructuraProyectos.ToListAsync();
        }

        // GET: api/InfraestructuraProyectoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfraestructuraProyecto>> GetInfraestructuraProyecto(int id)
        {
          if (_context.InfraestructuraProyectos == null)
          {
              return NotFound();
          }
            var infraestructuraProyecto = await _context.InfraestructuraProyectos.FindAsync(id);

            if (infraestructuraProyecto == null)
            {
                return NotFound();
            }

            return infraestructuraProyecto;
        }

        // PUT: api/InfraestructuraProyectoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfraestructuraProyecto(int id, InfraestructuraProyecto infraestructuraProyecto)
        {
            if (id != infraestructuraProyecto.Id)
            {
                return BadRequest();
            }

            _context.Entry(infraestructuraProyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfraestructuraProyectoExists(id))
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

        // POST: api/InfraestructuraProyectoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfraestructuraProyecto>> PostInfraestructuraProyecto(InfraestructuraProyecto infraestructuraProyecto)
        {
          if (_context.InfraestructuraProyectos == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.InfraestructuraProyectos'  is null.");
          }
            _context.InfraestructuraProyectos.Add(infraestructuraProyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfraestructuraProyecto", new { id = infraestructuraProyecto.Id }, infraestructuraProyecto);
        }

        // DELETE: api/InfraestructuraProyectoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfraestructuraProyecto(int id)
        {
            if (_context.InfraestructuraProyectos == null)
            {
                return NotFound();
            }
            var infraestructuraProyecto = await _context.InfraestructuraProyectos.FindAsync(id);
            if (infraestructuraProyecto == null)
            {
                return NotFound();
            }

            _context.InfraestructuraProyectos.Remove(infraestructuraProyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfraestructuraProyectoExists(int id)
        {
            return (_context.InfraestructuraProyectos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

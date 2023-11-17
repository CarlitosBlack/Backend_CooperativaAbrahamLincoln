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
    public class PedagogicosProyectoesController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public PedagogicosProyectoesController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/PedagogicosProyectoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedagogicosProyecto>>> GetPedagogicosProyectos()
        {
          if (_context.PedagogicosProyectos == null)
          {
              return NotFound();
          }
            return await _context.PedagogicosProyectos.ToListAsync();
        }

        // GET: api/PedagogicosProyectoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedagogicosProyecto>> GetPedagogicosProyecto(int id)
        {
          if (_context.PedagogicosProyectos == null)
          {
              return NotFound();
          }
            var pedagogicosProyecto = await _context.PedagogicosProyectos.FindAsync(id);

            if (pedagogicosProyecto == null)
            {
                return NotFound();
            }

            return pedagogicosProyecto;
        }

        // PUT: api/PedagogicosProyectoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedagogicosProyecto(int id, PedagogicosProyecto pedagogicosProyecto)
        {
            if (id != pedagogicosProyecto.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedagogicosProyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedagogicosProyectoExists(id))
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

        // POST: api/PedagogicosProyectoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PedagogicosProyecto>> PostPedagogicosProyecto(PedagogicosProyecto pedagogicosProyecto)
        {
          if (_context.PedagogicosProyectos == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.PedagogicosProyectos'  is null.");
          }
            _context.PedagogicosProyectos.Add(pedagogicosProyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedagogicosProyecto", new { id = pedagogicosProyecto.Id }, pedagogicosProyecto);
        }

        // DELETE: api/PedagogicosProyectoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedagogicosProyecto(int id)
        {
            if (_context.PedagogicosProyectos == null)
            {
                return NotFound();
            }
            var pedagogicosProyecto = await _context.PedagogicosProyectos.FindAsync(id);
            if (pedagogicosProyecto == null)
            {
                return NotFound();
            }

            _context.PedagogicosProyectos.Remove(pedagogicosProyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedagogicosProyectoExists(int id)
        {
            return (_context.PedagogicosProyectos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

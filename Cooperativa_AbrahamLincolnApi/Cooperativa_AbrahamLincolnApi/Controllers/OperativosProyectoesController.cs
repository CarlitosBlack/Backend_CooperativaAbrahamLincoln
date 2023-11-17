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
    public class OperativosProyectoesController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public OperativosProyectoesController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/OperativosProyectoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperativosProyecto>>> GetOperativosProyectos()
        {
          if (_context.OperativosProyectos == null)
          {
              return NotFound();
          }
            return await _context.OperativosProyectos.ToListAsync();
        }

        // GET: api/OperativosProyectoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperativosProyecto>> GetOperativosProyecto(int id)
        {
          if (_context.OperativosProyectos == null)
          {
              return NotFound();
          }
            var operativosProyecto = await _context.OperativosProyectos.FindAsync(id);

            if (operativosProyecto == null)
            {
                return NotFound();
            }

            return operativosProyecto;
        }

        // PUT: api/OperativosProyectoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperativosProyecto(int id, OperativosProyecto operativosProyecto)
        {
            if (id != operativosProyecto.Id)
            {
                return BadRequest();
            }

            _context.Entry(operativosProyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperativosProyectoExists(id))
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

        // POST: api/OperativosProyectoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OperativosProyecto>> PostOperativosProyecto(OperativosProyecto operativosProyecto)
        {
          if (_context.OperativosProyectos == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.OperativosProyectos'  is null.");
          }
            _context.OperativosProyectos.Add(operativosProyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperativosProyecto", new { id = operativosProyecto.Id }, operativosProyecto);
        }

        // DELETE: api/OperativosProyectoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperativosProyecto(int id)
        {
            if (_context.OperativosProyectos == null)
            {
                return NotFound();
            }
            var operativosProyecto = await _context.OperativosProyectos.FindAsync(id);
            if (operativosProyecto == null)
            {
                return NotFound();
            }

            _context.OperativosProyectos.Remove(operativosProyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperativosProyectoExists(int id)
        {
            return (_context.OperativosProyectos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

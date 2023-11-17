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
    public class ProcesoesController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ProcesoesController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/Procesoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proceso>>> GetProcesos()
        {
          if (_context.Procesos == null)
          {
              return NotFound();
          }
            return await _context.Procesos.ToListAsync();
        }

        // GET: api/Procesoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proceso>> GetProceso(int id)
        {
          if (_context.Procesos == null)
          {
              return NotFound();
          }
            var proceso = await _context.Procesos.FindAsync(id);

            if (proceso == null)
            {
                return NotFound();
            }

            return proceso;
        }

        // PUT: api/Procesoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProceso(int id, Proceso proceso)
        {
            if (id != proceso.Id)
            {
                return BadRequest();
            }

            _context.Entry(proceso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcesoExists(id))
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

        // POST: api/Procesoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proceso>> PostProceso(Proceso proceso)
        {
          if (_context.Procesos == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.Procesos'  is null.");
          }
            _context.Procesos.Add(proceso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProceso", new { id = proceso.Id }, proceso);
        }

        // DELETE: api/Procesoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProceso(int id)
        {
            if (_context.Procesos == null)
            {
                return NotFound();
            }
            var proceso = await _context.Procesos.FindAsync(id);
            if (proceso == null)
            {
                return NotFound();
            }

            _context.Procesos.Remove(proceso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcesoExists(int id)
        {
            return (_context.Procesos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

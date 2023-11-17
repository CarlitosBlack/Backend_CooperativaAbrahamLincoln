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
    public class ContratosAdquisicionesController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ContratosAdquisicionesController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/ContratosAdquisiciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContratosAdquisicione>>> GetContratosAdquisiciones()
        {
          if (_context.ContratosAdquisiciones == null)
          {
              return NotFound();
          }
            return await _context.ContratosAdquisiciones.ToListAsync();
        }

        // GET: api/ContratosAdquisiciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContratosAdquisicione>> GetContratosAdquisicione(int id)
        {
          if (_context.ContratosAdquisiciones == null)
          {
              return NotFound();
          }
            var contratosAdquisicione = await _context.ContratosAdquisiciones.FindAsync(id);

            if (contratosAdquisicione == null)
            {
                return NotFound();
            }

            return contratosAdquisicione;
        }

        // PUT: api/ContratosAdquisiciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContratosAdquisicione(int id, ContratosAdquisicione contratosAdquisicione)
        {
            if (id != contratosAdquisicione.Id)
            {
                return BadRequest();
            }

            _context.Entry(contratosAdquisicione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratosAdquisicioneExists(id))
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

        // POST: api/ContratosAdquisiciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContratosAdquisicione>> PostContratosAdquisicione(ContratosAdquisicione contratosAdquisicione)
        {
          if (_context.ContratosAdquisiciones == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.ContratosAdquisiciones'  is null.");
          }
            _context.ContratosAdquisiciones.Add(contratosAdquisicione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContratosAdquisicione", new { id = contratosAdquisicione.Id }, contratosAdquisicione);
        }

        // DELETE: api/ContratosAdquisiciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContratosAdquisicione(int id)
        {
            if (_context.ContratosAdquisiciones == null)
            {
                return NotFound();
            }
            var contratosAdquisicione = await _context.ContratosAdquisiciones.FindAsync(id);
            if (contratosAdquisicione == null)
            {
                return NotFound();
            }

            _context.ContratosAdquisiciones.Remove(contratosAdquisicione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContratosAdquisicioneExists(int id)
        {
            return (_context.ContratosAdquisiciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

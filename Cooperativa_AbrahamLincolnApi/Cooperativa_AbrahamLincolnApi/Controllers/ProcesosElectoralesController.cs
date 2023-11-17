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
    public class ProcesosElectoralesController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ProcesosElectoralesController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/ProcesosElectorales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcesosElectorale>>> GetProcesosElectorales()
        {
          if (_context.ProcesosElectorales == null)
          {
              return NotFound();
          }
            return await _context.ProcesosElectorales.ToListAsync();
        }

        // GET: api/ProcesosElectorales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcesosElectorale>> GetProcesosElectorale(int id)
        {
          if (_context.ProcesosElectorales == null)
          {
              return NotFound();
          }
            var procesosElectorale = await _context.ProcesosElectorales.FindAsync(id);

            if (procesosElectorale == null)
            {
                return NotFound();
            }

            return procesosElectorale;
        }

        // PUT: api/ProcesosElectorales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcesosElectorale(int id, ProcesosElectorale procesosElectorale)
        {
            if (id != procesosElectorale.Id)
            {
                return BadRequest();
            }

            _context.Entry(procesosElectorale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcesosElectoraleExists(id))
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

        // POST: api/ProcesosElectorales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProcesosElectorale>> PostProcesosElectorale(ProcesosElectorale procesosElectorale)
        {
          if (_context.ProcesosElectorales == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.ProcesosElectorales'  is null.");
          }
            _context.ProcesosElectorales.Add(procesosElectorale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcesosElectorale", new { id = procesosElectorale.Id }, procesosElectorale);
        }

        // DELETE: api/ProcesosElectorales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcesosElectorale(int id)
        {
            if (_context.ProcesosElectorales == null)
            {
                return NotFound();
            }
            var procesosElectorale = await _context.ProcesosElectorales.FindAsync(id);
            if (procesosElectorale == null)
            {
                return NotFound();
            }

            _context.ProcesosElectorales.Remove(procesosElectorale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcesosElectoraleExists(int id)
        {
            return (_context.ProcesosElectorales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

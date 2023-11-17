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
    public class EstructuraGobiernoesController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public EstructuraGobiernoesController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/EstructuraGobiernoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstructuraGobierno>>> GetEstructuraGobiernos()
        {
          if (_context.EstructuraGobiernos == null)
          {
              return NotFound();
          }
            return await _context.EstructuraGobiernos.ToListAsync();
        }

        // GET: api/EstructuraGobiernoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstructuraGobierno>> GetEstructuraGobierno(int id)
        {
          if (_context.EstructuraGobiernos == null)
          {
              return NotFound();
          }
            var estructuraGobierno = await _context.EstructuraGobiernos.FindAsync(id);

            if (estructuraGobierno == null)
            {
                return NotFound();
            }

            return estructuraGobierno;
        }

        // PUT: api/EstructuraGobiernoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstructuraGobierno(int id, EstructuraGobierno estructuraGobierno)
        {
            if (id != estructuraGobierno.Id)
            {
                return BadRequest();
            }

            _context.Entry(estructuraGobierno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstructuraGobiernoExists(id))
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

        // POST: api/EstructuraGobiernoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstructuraGobierno>> PostEstructuraGobierno(EstructuraGobierno estructuraGobierno)
        {
          if (_context.EstructuraGobiernos == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.EstructuraGobiernos'  is null.");
          }
            _context.EstructuraGobiernos.Add(estructuraGobierno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstructuraGobierno", new { id = estructuraGobierno.Id }, estructuraGobierno);
        }

        // DELETE: api/EstructuraGobiernoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstructuraGobierno(int id)
        {
            if (_context.EstructuraGobiernos == null)
            {
                return NotFound();
            }
            var estructuraGobierno = await _context.EstructuraGobiernos.FindAsync(id);
            if (estructuraGobierno == null)
            {
                return NotFound();
            }

            _context.EstructuraGobiernos.Remove(estructuraGobierno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstructuraGobiernoExists(int id)
        {
            return (_context.EstructuraGobiernos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

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
    public class AsambleasController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public AsambleasController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/Asambleas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asamblea>>> GetAsambleas()
        {
          if (_context.Asambleas == null)
          {
              return NotFound();
          }
            return await _context.Asambleas.ToListAsync();
        }

        // GET: api/Asambleas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asamblea>> GetAsamblea(int id)
        {
          if (_context.Asambleas == null)
          {
              return NotFound();
          }
            var asamblea = await _context.Asambleas.FindAsync(id);

            if (asamblea == null)
            {
                return NotFound();
            }

            return asamblea;
        }

        // PUT: api/Asambleas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsamblea(int id, Asamblea asamblea)
        {
            if (id != asamblea.Id)
            {
                return BadRequest();
            }

            _context.Entry(asamblea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsambleaExists(id))
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

        // POST: api/Asambleas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asamblea>> PostAsamblea(Asamblea asamblea)
        {
          if (_context.Asambleas == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.Asambleas'  is null.");
          }
            _context.Asambleas.Add(asamblea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsamblea", new { id = asamblea.Id }, asamblea);
        }

        // DELETE: api/Asambleas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsamblea(int id)
        {
            if (_context.Asambleas == null)
            {
                return NotFound();
            }
            var asamblea = await _context.Asambleas.FindAsync(id);
            if (asamblea == null)
            {
                return NotFound();
            }

            _context.Asambleas.Remove(asamblea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsambleaExists(int id)
        {
            return (_context.Asambleas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

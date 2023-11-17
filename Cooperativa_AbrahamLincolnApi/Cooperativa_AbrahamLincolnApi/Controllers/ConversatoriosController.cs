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
    public class ConversatoriosController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ConversatoriosController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/Conversatorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conversatorio>>> GetConversatorios()
        {
          if (_context.Conversatorios == null)
          {
              return NotFound();
          }
            return await _context.Conversatorios.ToListAsync();
        }

        // GET: api/Conversatorios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conversatorio>> GetConversatorio(int id)
        {
          if (_context.Conversatorios == null)
          {
              return NotFound();
          }
            var conversatorio = await _context.Conversatorios.FindAsync(id);

            if (conversatorio == null)
            {
                return NotFound();
            }

            return conversatorio;
        }

        // PUT: api/Conversatorios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConversatorio(int id, Conversatorio conversatorio)
        {
            if (id != conversatorio.Id)
            {
                return BadRequest();
            }

            _context.Entry(conversatorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConversatorioExists(id))
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

        // POST: api/Conversatorios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conversatorio>> PostConversatorio(Conversatorio conversatorio)
        {
          if (_context.Conversatorios == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.Conversatorios'  is null.");
          }
            _context.Conversatorios.Add(conversatorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConversatorio", new { id = conversatorio.Id }, conversatorio);
        }

        // DELETE: api/Conversatorios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConversatorio(int id)
        {
            if (_context.Conversatorios == null)
            {
                return NotFound();
            }
            var conversatorio = await _context.Conversatorios.FindAsync(id);
            if (conversatorio == null)
            {
                return NotFound();
            }

            _context.Conversatorios.Remove(conversatorio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConversatorioExists(int id)
        {
            return (_context.Conversatorios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

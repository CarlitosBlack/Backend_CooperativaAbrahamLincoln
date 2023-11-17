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
    public class ConsejoVigilanciumsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ConsejoVigilanciumsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/ConsejoVigilanciums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsejoVigilancium>>> GetConsejoVigilancia()
        {
          if (_context.ConsejoVigilancia == null)
          {
              return NotFound();
          }
            return await _context.ConsejoVigilancia.ToListAsync();
        }

        // GET: api/ConsejoVigilanciums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsejoVigilancium>> GetConsejoVigilancium(int id)
        {
          if (_context.ConsejoVigilancia == null)
          {
              return NotFound();
          }
            var consejoVigilancium = await _context.ConsejoVigilancia.FindAsync(id);

            if (consejoVigilancium == null)
            {
                return NotFound();
            }

            return consejoVigilancium;
        }

        // PUT: api/ConsejoVigilanciums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsejoVigilancium(int id, ConsejoVigilancium consejoVigilancium)
        {
            if (id != consejoVigilancium.Id)
            {
                return BadRequest();
            }

            _context.Entry(consejoVigilancium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsejoVigilanciumExists(id))
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

        // POST: api/ConsejoVigilanciums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsejoVigilancium>> PostConsejoVigilancium(ConsejoVigilancium consejoVigilancium)
        {
          if (_context.ConsejoVigilancia == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.ConsejoVigilancia'  is null.");
          }
            _context.ConsejoVigilancia.Add(consejoVigilancium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsejoVigilancium", new { id = consejoVigilancium.Id }, consejoVigilancium);
        }

        // DELETE: api/ConsejoVigilanciums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsejoVigilancium(int id)
        {
            if (_context.ConsejoVigilancia == null)
            {
                return NotFound();
            }
            var consejoVigilancium = await _context.ConsejoVigilancia.FindAsync(id);
            if (consejoVigilancium == null)
            {
                return NotFound();
            }

            _context.ConsejoVigilancia.Remove(consejoVigilancium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsejoVigilanciumExists(int id)
        {
            return (_context.ConsejoVigilancia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

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
    public class ComiteEduCoopsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ComiteEduCoopsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/ComiteEduCoops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComiteEduCoop>>> GetComiteEduCoops()
        {
          if (_context.ComiteEduCoops == null)
          {
              return NotFound();
          }
            return await _context.ComiteEduCoops.ToListAsync();
        }

        // GET: api/ComiteEduCoops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComiteEduCoop>> GetComiteEduCoop(int id)
        {
          if (_context.ComiteEduCoops == null)
          {
              return NotFound();
          }
            var comiteEduCoop = await _context.ComiteEduCoops.FindAsync(id);

            if (comiteEduCoop == null)
            {
                return NotFound();
            }

            return comiteEduCoop;
        }

        // PUT: api/ComiteEduCoops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComiteEduCoop(int id, ComiteEduCoop comiteEduCoop)
        {
            if (id != comiteEduCoop.Id)
            {
                return BadRequest();
            }

            _context.Entry(comiteEduCoop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComiteEduCoopExists(id))
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

        // POST: api/ComiteEduCoops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComiteEduCoop>> PostComiteEduCoop(ComiteEduCoop comiteEduCoop)
        {
          if (_context.ComiteEduCoops == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.ComiteEduCoops'  is null.");
          }
            _context.ComiteEduCoops.Add(comiteEduCoop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComiteEduCoop", new { id = comiteEduCoop.Id }, comiteEduCoop);
        }

        // DELETE: api/ComiteEduCoops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComiteEduCoop(int id)
        {
            if (_context.ComiteEduCoops == null)
            {
                return NotFound();
            }
            var comiteEduCoop = await _context.ComiteEduCoops.FindAsync(id);
            if (comiteEduCoop == null)
            {
                return NotFound();
            }

            _context.ComiteEduCoops.Remove(comiteEduCoop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComiteEduCoopExists(int id)
        {
            return (_context.ComiteEduCoops?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

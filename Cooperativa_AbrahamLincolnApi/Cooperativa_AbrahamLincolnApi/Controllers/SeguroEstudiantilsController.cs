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
    public class SeguroEstudiantilsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public SeguroEstudiantilsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/SeguroEstudiantils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeguroEstudiantil>>> GetSeguroEstudiantils()
        {
          if (_context.SeguroEstudiantils == null)
          {
              return NotFound();
          }
            return await _context.SeguroEstudiantils.ToListAsync();
        }

        // GET: api/SeguroEstudiantils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeguroEstudiantil>> GetSeguroEstudiantil(int id)
        {
          if (_context.SeguroEstudiantils == null)
          {
              return NotFound();
          }
            var seguroEstudiantil = await _context.SeguroEstudiantils.FindAsync(id);

            if (seguroEstudiantil == null)
            {
                return NotFound();
            }

            return seguroEstudiantil;
        }

        // PUT: api/SeguroEstudiantils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeguroEstudiantil(int id, SeguroEstudiantil seguroEstudiantil)
        {
            if (id != seguroEstudiantil.Id)
            {
                return BadRequest();
            }

            _context.Entry(seguroEstudiantil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguroEstudiantilExists(id))
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

        // POST: api/SeguroEstudiantils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeguroEstudiantil>> PostSeguroEstudiantil(SeguroEstudiantil seguroEstudiantil)
        {
          if (_context.SeguroEstudiantils == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.SeguroEstudiantils'  is null.");
          }
            _context.SeguroEstudiantils.Add(seguroEstudiantil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeguroEstudiantil", new { id = seguroEstudiantil.Id }, seguroEstudiantil);
        }

        // DELETE: api/SeguroEstudiantils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeguroEstudiantil(int id)
        {
            if (_context.SeguroEstudiantils == null)
            {
                return NotFound();
            }
            var seguroEstudiantil = await _context.SeguroEstudiantils.FindAsync(id);
            if (seguroEstudiantil == null)
            {
                return NotFound();
            }

            _context.SeguroEstudiantils.Remove(seguroEstudiantil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeguroEstudiantilExists(int id)
        {
            return (_context.SeguroEstudiantils?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

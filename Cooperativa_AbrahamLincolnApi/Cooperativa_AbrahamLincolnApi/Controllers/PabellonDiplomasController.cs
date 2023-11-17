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
    public class PabellonDiplomasController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public PabellonDiplomasController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/PabellonDiplomas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PabellonDiploma>>> GetPabellonDiplomas()
        {
          if (_context.PabellonDiplomas == null)
          {
              return NotFound();
          }
            return await _context.PabellonDiplomas.ToListAsync();
        }

        // GET: api/PabellonDiplomas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PabellonDiploma>> GetPabellonDiploma(int id)
        {
          if (_context.PabellonDiplomas == null)
          {
              return NotFound();
          }
            var pabellonDiploma = await _context.PabellonDiplomas.FindAsync(id);

            if (pabellonDiploma == null)
            {
                return NotFound();
            }

            return pabellonDiploma;
        }

        // PUT: api/PabellonDiplomas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPabellonDiploma(int id, PabellonDiploma pabellonDiploma)
        {
            if (id != pabellonDiploma.Id)
            {
                return BadRequest();
            }

            _context.Entry(pabellonDiploma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PabellonDiplomaExists(id))
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

        // POST: api/PabellonDiplomas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PabellonDiploma>> PostPabellonDiploma(PabellonDiploma pabellonDiploma)
        {
          if (_context.PabellonDiplomas == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.PabellonDiplomas'  is null.");
          }
            _context.PabellonDiplomas.Add(pabellonDiploma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPabellonDiploma", new { id = pabellonDiploma.Id }, pabellonDiploma);
        }

        // DELETE: api/PabellonDiplomas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePabellonDiploma(int id)
        {
            if (_context.PabellonDiplomas == null)
            {
                return NotFound();
            }
            var pabellonDiploma = await _context.PabellonDiplomas.FindAsync(id);
            if (pabellonDiploma == null)
            {
                return NotFound();
            }

            _context.PabellonDiplomas.Remove(pabellonDiploma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PabellonDiplomaExists(int id)
        {
            return (_context.PabellonDiplomas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

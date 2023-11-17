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
    public class ApoyoesController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ApoyoesController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/Apoyoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apoyo>>> GetApoyos()
        {
          if (_context.Apoyos == null)
          {
              return NotFound();
          }
            return await _context.Apoyos.ToListAsync();
        }

        // GET: api/Apoyoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apoyo>> GetApoyo(int id)
        {
          if (_context.Apoyos == null)
          {
              return NotFound();
          }
            var apoyo = await _context.Apoyos.FindAsync(id);

            if (apoyo == null)
            {
                return NotFound();
            }

            return apoyo;
        }

        // PUT: api/Apoyoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApoyo(int id, Apoyo apoyo)
        {
            if (id != apoyo.Id)
            {
                return BadRequest();
            }

            _context.Entry(apoyo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApoyoExists(id))
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

        // POST: api/Apoyoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Apoyo>> PostApoyo(Apoyo apoyo)
        {
          if (_context.Apoyos == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.Apoyos'  is null.");
          }
            _context.Apoyos.Add(apoyo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApoyo", new { id = apoyo.Id }, apoyo);
        }

        // DELETE: api/Apoyoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApoyo(int id)
        {
            if (_context.Apoyos == null)
            {
                return NotFound();
            }
            var apoyo = await _context.Apoyos.FindAsync(id);
            if (apoyo == null)
            {
                return NotFound();
            }

            _context.Apoyos.Remove(apoyo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApoyoExists(int id)
        {
            return (_context.Apoyos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

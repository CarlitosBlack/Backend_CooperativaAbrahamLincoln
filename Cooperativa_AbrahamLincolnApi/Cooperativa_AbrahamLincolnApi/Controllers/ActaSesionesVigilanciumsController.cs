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
    public class ActaSesionesVigilanciumsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ActaSesionesVigilanciumsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/ActaSesionesVigilanciums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActaSesionesVigilancium>>> GetActaSesionesVigilancia()
        {
          if (_context.ActaSesionesVigilancia == null)
          {
              return NotFound();
          }
            return await _context.ActaSesionesVigilancia.ToListAsync();
        }

        // GET: api/ActaSesionesVigilanciums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActaSesionesVigilancium>> GetActaSesionesVigilancium(int id)
        {
          if (_context.ActaSesionesVigilancia == null)
          {
              return NotFound();
          }
            var actaSesionesVigilancium = await _context.ActaSesionesVigilancia.FindAsync(id);

            if (actaSesionesVigilancium == null)
            {
                return NotFound();
            }

            return actaSesionesVigilancium;
        }

        // PUT: api/ActaSesionesVigilanciums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActaSesionesVigilancium(int id, ActaSesionesVigilancium actaSesionesVigilancium)
        {
            if (id != actaSesionesVigilancium.Id)
            {
                return BadRequest();
            }

            _context.Entry(actaSesionesVigilancium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActaSesionesVigilanciumExists(id))
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

        // POST: api/ActaSesionesVigilanciums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActaSesionesVigilancium>> PostActaSesionesVigilancium(ActaSesionesVigilancium actaSesionesVigilancium)
        {
          if (_context.ActaSesionesVigilancia == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.ActaSesionesVigilancia'  is null.");
          }
            _context.ActaSesionesVigilancia.Add(actaSesionesVigilancium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActaSesionesVigilancium", new { id = actaSesionesVigilancium.Id }, actaSesionesVigilancium);
        }

        // DELETE: api/ActaSesionesVigilanciums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActaSesionesVigilancium(int id)
        {
            if (_context.ActaSesionesVigilancia == null)
            {
                return NotFound();
            }
            var actaSesionesVigilancium = await _context.ActaSesionesVigilancia.FindAsync(id);
            if (actaSesionesVigilancium == null)
            {
                return NotFound();
            }

            _context.ActaSesionesVigilancia.Remove(actaSesionesVigilancium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActaSesionesVigilanciumExists(int id)
        {
            return (_context.ActaSesionesVigilancia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

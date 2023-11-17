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
    public class ComedorsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public ComedorsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/Comedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comedor>>> GetComedors()
        {
          if (_context.Comedors == null)
          {
              return NotFound();
          }
            return await _context.Comedors.ToListAsync();
        }

        // GET: api/Comedors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comedor>> GetComedor(int id)
        {
          if (_context.Comedors == null)
          {
              return NotFound();
          }
            var comedor = await _context.Comedors.FindAsync(id);

            if (comedor == null)
            {
                return NotFound();
            }

            return comedor;
        }

        // PUT: api/Comedors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComedor(int id, Comedor comedor)
        {
            if (id != comedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(comedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComedorExists(id))
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

        // POST: api/Comedors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comedor>> PostComedor(Comedor comedor)
        {
          if (_context.Comedors == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.Comedors'  is null.");
          }
            _context.Comedors.Add(comedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComedor", new { id = comedor.Id }, comedor);
        }

        // DELETE: api/Comedors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComedor(int id)
        {
            if (_context.Comedors == null)
            {
                return NotFound();
            }
            var comedor = await _context.Comedors.FindAsync(id);
            if (comedor == null)
            {
                return NotFound();
            }

            _context.Comedors.Remove(comedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComedorExists(int id)
        {
            return (_context.Comedors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

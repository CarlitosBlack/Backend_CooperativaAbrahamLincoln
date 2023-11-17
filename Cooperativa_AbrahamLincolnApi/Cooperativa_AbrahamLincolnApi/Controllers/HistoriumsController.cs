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
    public class HistoriumsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public HistoriumsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/Historiums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historium>>> GetHistoria()
        {
          if (_context.Historia == null)
          {
              return NotFound();
          }
            return await _context.Historia.ToListAsync();
        }

        // GET: api/Historiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historium>> GetHistorium(int id)
        {
          if (_context.Historia == null)
          {
              return NotFound();
          }
            var historium = await _context.Historia.FindAsync(id);

            if (historium == null)
            {
                return NotFound();
            }

            return historium;
        }

        // PUT: api/Historiums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorium(int id, Historium historium)
        {
            if (id != historium.Id)
            {
                return BadRequest();
            }

            _context.Entry(historium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriumExists(id))
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

        // POST: api/Historiums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Historium>> PostHistorium(Historium historium)
        {
          if (_context.Historia == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.Historia'  is null.");
          }
            _context.Historia.Add(historium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorium", new { id = historium.Id }, historium);
        }

        // DELETE: api/Historiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorium(int id)
        {
            if (_context.Historia == null)
            {
                return NotFound();
            }
            var historium = await _context.Historia.FindAsync(id);
            if (historium == null)
            {
                return NotFound();
            }

            _context.Historia.Remove(historium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoriumExists(int id)
        {
            return (_context.Historia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

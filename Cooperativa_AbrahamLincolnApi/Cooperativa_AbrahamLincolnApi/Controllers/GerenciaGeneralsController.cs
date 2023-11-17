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
    public class GerenciaGeneralsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public GerenciaGeneralsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/GerenciaGenerals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GerenciaGeneral>>> GetGerenciaGenerals()
        {
          if (_context.GerenciaGenerals == null)
          {
              return NotFound();
          }
            return await _context.GerenciaGenerals.ToListAsync();
        }

        // GET: api/GerenciaGenerals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GerenciaGeneral>> GetGerenciaGeneral(int id)
        {
          if (_context.GerenciaGenerals == null)
          {
              return NotFound();
          }
            var gerenciaGeneral = await _context.GerenciaGenerals.FindAsync(id);

            if (gerenciaGeneral == null)
            {
                return NotFound();
            }

            return gerenciaGeneral;
        }

        // PUT: api/GerenciaGenerals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGerenciaGeneral(int id, GerenciaGeneral gerenciaGeneral)
        {
            if (id != gerenciaGeneral.Id)
            {
                return BadRequest();
            }

            _context.Entry(gerenciaGeneral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GerenciaGeneralExists(id))
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

        // POST: api/GerenciaGenerals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GerenciaGeneral>> PostGerenciaGeneral(GerenciaGeneral gerenciaGeneral)
        {
          if (_context.GerenciaGenerals == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.GerenciaGenerals'  is null.");
          }
            _context.GerenciaGenerals.Add(gerenciaGeneral);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGerenciaGeneral", new { id = gerenciaGeneral.Id }, gerenciaGeneral);
        }

        // DELETE: api/GerenciaGenerals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGerenciaGeneral(int id)
        {
            if (_context.GerenciaGenerals == null)
            {
                return NotFound();
            }
            var gerenciaGeneral = await _context.GerenciaGenerals.FindAsync(id);
            if (gerenciaGeneral == null)
            {
                return NotFound();
            }

            _context.GerenciaGenerals.Remove(gerenciaGeneral);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GerenciaGeneralExists(int id)
        {
            return (_context.GerenciaGenerals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

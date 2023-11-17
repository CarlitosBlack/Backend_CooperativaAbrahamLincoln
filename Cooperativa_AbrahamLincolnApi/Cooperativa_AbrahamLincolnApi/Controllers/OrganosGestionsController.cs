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
    public class OrganosGestionsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public OrganosGestionsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/OrganosGestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganosGestion>>> GetOrganosGestions()
        {
          if (_context.OrganosGestions == null)
          {
              return NotFound();
          }
            return await _context.OrganosGestions.ToListAsync();
        }

        // GET: api/OrganosGestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganosGestion>> GetOrganosGestion(int id)
        {
          if (_context.OrganosGestions == null)
          {
              return NotFound();
          }
            var organosGestion = await _context.OrganosGestions.FindAsync(id);

            if (organosGestion == null)
            {
                return NotFound();
            }

            return organosGestion;
        }

        // PUT: api/OrganosGestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganosGestion(int id, OrganosGestion organosGestion)
        {
            if (id != organosGestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(organosGestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganosGestionExists(id))
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

        // POST: api/OrganosGestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrganosGestion>> PostOrganosGestion(OrganosGestion organosGestion)
        {
          if (_context.OrganosGestions == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.OrganosGestions'  is null.");
          }
            _context.OrganosGestions.Add(organosGestion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrganosGestionExists(organosGestion.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrganosGestion", new { id = organosGestion.Id }, organosGestion);
        }

        // DELETE: api/OrganosGestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganosGestion(int id)
        {
            if (_context.OrganosGestions == null)
            {
                return NotFound();
            }
            var organosGestion = await _context.OrganosGestions.FindAsync(id);
            if (organosGestion == null)
            {
                return NotFound();
            }

            _context.OrganosGestions.Remove(organosGestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganosGestionExists(int id)
        {
            return (_context.OrganosGestions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

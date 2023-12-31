﻿using System;
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
    public class OrganizacionsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public OrganizacionsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/Organizacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizacion>>> GetOrganizacions()
        {
          if (_context.Organizacions == null)
          {
              return NotFound();
          }
            return await _context.Organizacions.ToListAsync();
        }

        // GET: api/Organizacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organizacion>> GetOrganizacion(int id)
        {
          if (_context.Organizacions == null)
          {
              return NotFound();
          }
            var organizacion = await _context.Organizacions.FindAsync(id);

            if (organizacion == null)
            {
                return NotFound();
            }

            return organizacion;
        }

        // PUT: api/Organizacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizacion(int id, Organizacion organizacion)
        {
            if (id != organizacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(organizacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizacionExists(id))
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

        // POST: api/Organizacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Organizacion>> PostOrganizacion(Organizacion organizacion)
        {
          if (_context.Organizacions == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.Organizacions'  is null.");
          }
            _context.Organizacions.Add(organizacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrganizacionExists(organizacion.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrganizacion", new { id = organizacion.Id }, organizacion);
        }

        // DELETE: api/Organizacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizacion(int id)
        {
            if (_context.Organizacions == null)
            {
                return NotFound();
            }
            var organizacion = await _context.Organizacions.FindAsync(id);
            if (organizacion == null)
            {
                return NotFound();
            }

            _context.Organizacions.Remove(organizacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizacionExists(int id)
        {
            return (_context.Organizacions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

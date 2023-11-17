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
    public class UsuarioControlsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public UsuarioControlsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioControls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioControl>>> GetUsuarioControls()
        {
          if (_context.UsuarioControls == null)
          {
              return NotFound();
          }
            return await _context.UsuarioControls.ToListAsync();
        }

        // GET: api/UsuarioControls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioControl>> GetUsuarioControl(int id)
        {
          if (_context.UsuarioControls == null)
          {
              return NotFound();
          }
            var usuarioControl = await _context.UsuarioControls.FindAsync(id);

            if (usuarioControl == null)
            {
                return NotFound();
            }

            return usuarioControl;
        }

        // PUT: api/UsuarioControls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioControl(int id, UsuarioControl usuarioControl)
        {
            if (id != usuarioControl.IdDescarga)
            {
                return BadRequest();
            }

            _context.Entry(usuarioControl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioControlExists(id))
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

        // POST: api/UsuarioControls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioControl>> PostUsuarioControl(UsuarioControl usuarioControl)
        {
          if (_context.UsuarioControls == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.UsuarioControls'  is null.");
          }
            _context.UsuarioControls.Add(usuarioControl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioControl", new { id = usuarioControl.IdDescarga }, usuarioControl);
        }

        // DELETE: api/UsuarioControls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioControl(int id)
        {
            if (_context.UsuarioControls == null)
            {
                return NotFound();
            }
            var usuarioControl = await _context.UsuarioControls.FindAsync(id);
            if (usuarioControl == null)
            {
                return NotFound();
            }

            _context.UsuarioControls.Remove(usuarioControl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioControlExists(int id)
        {
            return (_context.UsuarioControls?.Any(e => e.IdDescarga == id)).GetValueOrDefault();
        }
    }
}

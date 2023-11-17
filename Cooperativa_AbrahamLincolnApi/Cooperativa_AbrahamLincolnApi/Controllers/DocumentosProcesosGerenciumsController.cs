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
    public class DocumentosProcesosGerenciumsController : ControllerBase
    {
        private readonly Cooperativa_AbrahamLincolnContext _context;

        public DocumentosProcesosGerenciumsController(Cooperativa_AbrahamLincolnContext context)
        {
            _context = context;
        }

        // GET: api/DocumentosProcesosGerenciums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentosProcesosGerencium>>> GetDocumentosProcesosGerencia()
        {
          if (_context.DocumentosProcesosGerencia == null)
          {
              return NotFound();
          }
            return await _context.DocumentosProcesosGerencia.ToListAsync();
        }

        // GET: api/DocumentosProcesosGerenciums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentosProcesosGerencium>> GetDocumentosProcesosGerencium(int id)
        {
          if (_context.DocumentosProcesosGerencia == null)
          {
              return NotFound();
          }
            var documentosProcesosGerencium = await _context.DocumentosProcesosGerencia.FindAsync(id);

            if (documentosProcesosGerencium == null)
            {
                return NotFound();
            }

            return documentosProcesosGerencium;
        }

        // PUT: api/DocumentosProcesosGerenciums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentosProcesosGerencium(int id, DocumentosProcesosGerencium documentosProcesosGerencium)
        {
            if (id != documentosProcesosGerencium.Id)
            {
                return BadRequest();
            }

            _context.Entry(documentosProcesosGerencium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentosProcesosGerenciumExists(id))
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

        // POST: api/DocumentosProcesosGerenciums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocumentosProcesosGerencium>> PostDocumentosProcesosGerencium(DocumentosProcesosGerencium documentosProcesosGerencium)
        {
          if (_context.DocumentosProcesosGerencia == null)
          {
              return Problem("Entity set 'Cooperativa_AbrahamLincolnContext.DocumentosProcesosGerencia'  is null.");
          }
            _context.DocumentosProcesosGerencia.Add(documentosProcesosGerencium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumentosProcesosGerencium", new { id = documentosProcesosGerencium.Id }, documentosProcesosGerencium);
        }

        // DELETE: api/DocumentosProcesosGerenciums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentosProcesosGerencium(int id)
        {
            if (_context.DocumentosProcesosGerencia == null)
            {
                return NotFound();
            }
            var documentosProcesosGerencium = await _context.DocumentosProcesosGerencia.FindAsync(id);
            if (documentosProcesosGerencium == null)
            {
                return NotFound();
            }

            _context.DocumentosProcesosGerencia.Remove(documentosProcesosGerencium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentosProcesosGerenciumExists(int id)
        {
            return (_context.DocumentosProcesosGerencia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

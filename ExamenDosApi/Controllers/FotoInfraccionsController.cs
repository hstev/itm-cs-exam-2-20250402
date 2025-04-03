using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenDosApi.Models;

namespace ExamenDosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotoInfraccionsController : ControllerBase
    {
        private readonly DbexamenContext _context;

        public FotoInfraccionsController(DbexamenContext context)
        {
            _context = context;
        }

        // GET: api/FotoInfraccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FotoInfraccion>>> GetFotoInfraccions()
        {
            return await _context.FotoInfraccions.ToListAsync();
        }

        // GET: api/FotoInfraccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FotoInfraccion>> GetFotoInfraccion(int id)
        {
            var fotoInfraccion = await _context.FotoInfraccions.FindAsync(id);

            if (fotoInfraccion == null)
            {
                return NotFound();
            }

            return fotoInfraccion;
        }

        // PUT: api/FotoInfraccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFotoInfraccion(int id, FotoInfraccion fotoInfraccion)
        {
            if (id != fotoInfraccion.IdFoto)
            {
                return BadRequest();
            }

            _context.Entry(fotoInfraccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotoInfraccionExists(id))
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

        // POST: api/FotoInfraccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FotoInfraccion>> PostFotoInfraccion(FotoInfraccion fotoInfraccion)
        {
            _context.FotoInfraccions.Add(fotoInfraccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFotoInfraccion", new { id = fotoInfraccion.IdFoto }, fotoInfraccion);
        }

        // DELETE: api/FotoInfraccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFotoInfraccion(int id)
        {
            var fotoInfraccion = await _context.FotoInfraccions.FindAsync(id);
            if (fotoInfraccion == null)
            {
                return NotFound();
            }

            _context.FotoInfraccions.Remove(fotoInfraccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FotoInfraccionExists(int id)
        {
            return _context.FotoInfraccions.Any(e => e.IdFoto == id);
        }
    }
}

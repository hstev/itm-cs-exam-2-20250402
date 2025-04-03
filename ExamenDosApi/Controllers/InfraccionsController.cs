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
    public class InfraccionsController : ControllerBase
    {
        private readonly DbexamenContext _context;

        public InfraccionsController(DbexamenContext context)
        {
            _context = context;
        }

        // GET: api/Infraccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Infraccion>>> GetInfraccions()
        {
            return await _context.Infraccions.ToListAsync();
        }

        // GET: api/Infraccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Infraccion>> GetInfraccion(int id)
        {
            var infraccion = await _context.Infraccions.FindAsync(id);

            if (infraccion == null)
            {
                return NotFound();
            }

            return infraccion;
        }

        // PUT: api/Infraccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfraccion(int id, Infraccion infraccion)
        {
            if (id != infraccion.IdFotoMulta)
            {
                return BadRequest();
            }

            _context.Entry(infraccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfraccionExists(id))
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

        // POST: api/Infraccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Infraccion>> PostInfraccion(Infraccion infraccion)
        {
            _context.Infraccions.Add(infraccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfraccion", new { id = infraccion.IdFotoMulta }, infraccion);
        }

        // DELETE: api/Infraccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfraccion(int id)
        {
            var infraccion = await _context.Infraccions.FindAsync(id);
            if (infraccion == null)
            {
                return NotFound();
            }

            _context.Infraccions.Remove(infraccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfraccionExists(int id)
        {
            return _context.Infraccions.Any(e => e.IdFotoMulta == id);
        }
    }
}

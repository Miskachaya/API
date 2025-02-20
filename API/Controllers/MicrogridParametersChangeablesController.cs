using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Configurations;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MicrogridParametersChangeablesController : ControllerBase
    {
        private readonly StandContext _context;

        public MicrogridParametersChangeablesController(StandContext context)
        {
            _context = context;
        }

        // GET: api/MicrogridParametersChangeables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MicrogridParametersChangeable>>> GetMicrogridParametersChangeables()
        {
            return await _context.MicrogridParametersChangeables.ToListAsync();
        }

        // GET: api/MicrogridParametersChangeables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MicrogridParametersChangeable>> GetMicrogridParametersChangeable(int id)
        {
            var microgridParametersChangeable = await _context.MicrogridParametersChangeables.FindAsync(id);

            if (microgridParametersChangeable == null)
            {
                return NotFound();
            }

            return microgridParametersChangeable;
        }

        // PUT: api/MicrogridParametersChangeables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMicrogridParametersChangeable(int id, MicrogridParametersChangeable microgridParametersChangeable)
        {
            if (id != microgridParametersChangeable.BlockId)
            {
                return BadRequest();
            }

            _context.Entry(microgridParametersChangeable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MicrogridParametersChangeableExists(id))
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

        // POST: api/MicrogridParametersChangeables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MicrogridParametersChangeable>> PostMicrogridParametersChangeable(MicrogridParametersChangeable microgridParametersChangeable)
        {
            _context.MicrogridParametersChangeables.Add(microgridParametersChangeable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMicrogridParametersChangeable", new { id = microgridParametersChangeable.BlockId }, microgridParametersChangeable);
        }

        // DELETE: api/MicrogridParametersChangeables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMicrogridParametersChangeable(int id)
        {
            var microgridParametersChangeable = await _context.MicrogridParametersChangeables.FindAsync(id);
            if (microgridParametersChangeable == null)
            {
                return NotFound();
            }

            _context.MicrogridParametersChangeables.Remove(microgridParametersChangeable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MicrogridParametersChangeableExists(int id)
        {
            return _context.MicrogridParametersChangeables.Any(e => e.BlockId == id);
        }
    }
}

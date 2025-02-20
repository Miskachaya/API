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
    public class MicrogridParametersMeasureChangeablesController : ControllerBase
    {
        private readonly StandContext _context;

        public MicrogridParametersMeasureChangeablesController(StandContext context)
        {
            _context = context;
        }

        // GET: api/MicrogridParametersMeasureChangeables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MicrogridParametersMeasureChangeable>>> GetMicrogridParametersMeasureChangeables()
        {
            return await _context.MicrogridParametersMeasureChangeables.ToListAsync();
        }

        // GET: api/MicrogridParametersMeasureChangeables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MicrogridParametersMeasureChangeable>> GetMicrogridParametersMeasureChangeable(int id)
        {
            var microgridParametersMeasureChangeable = await _context.MicrogridParametersMeasureChangeables.FindAsync(id);

            if (microgridParametersMeasureChangeable == null)
            {
                return NotFound();
            }

            return microgridParametersMeasureChangeable;
        }

        [HttpGet("ls")]
        public async Task<ActionResult<MicrogridParametersMeasureChangeable>> GetMicrogridParametersMeasureChangeable()
        {
            var microgridParametersMeasureChangeable = await _context.MicrogridParametersMeasureChangeables.FindAsync(1);

            if (microgridParametersMeasureChangeable == null)
            {
                return NotFound();
            }

            return microgridParametersMeasureChangeable;
        }
        // PUT: api/MicrogridParametersMeasureChangeables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMicrogridParametersMeasureChangeable(int id, MicrogridParametersMeasureChangeable microgridParametersMeasureChangeable)
        {
            if (id != microgridParametersMeasureChangeable.BlockId)
            {
                return BadRequest();
            }

            _context.Entry(microgridParametersMeasureChangeable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MicrogridParametersMeasureChangeableExists(id))
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

        // POST: api/MicrogridParametersMeasureChangeables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MicrogridParametersMeasureChangeable>> PostMicrogridParametersMeasureChangeable(MicrogridParametersMeasureChangeable microgridParametersMeasureChangeable)
        {
            _context.MicrogridParametersMeasureChangeables.Add(microgridParametersMeasureChangeable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMicrogridParametersMeasureChangeable", new { id = microgridParametersMeasureChangeable.BlockId }, microgridParametersMeasureChangeable);
        }

        // DELETE: api/MicrogridParametersMeasureChangeables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMicrogridParametersMeasureChangeable(int id)
        {
            var microgridParametersMeasureChangeable = await _context.MicrogridParametersMeasureChangeables.FindAsync(id);
            if (microgridParametersMeasureChangeable == null)
            {
                return NotFound();
            }

            _context.MicrogridParametersMeasureChangeables.Remove(microgridParametersMeasureChangeable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MicrogridParametersMeasureChangeableExists(int id)
        {
            return _context.MicrogridParametersMeasureChangeables.Any(e => e.BlockId == id);
        }
    }
}

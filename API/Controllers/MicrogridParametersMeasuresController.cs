using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Configurations;
using API.Models;

namespace API.Controller
    //3->1 5->2
{
    [Route("api/[controller]")]
    [ApiController]
    public class MicrogridParametersMeasuresController : ControllerBase
    {
        private readonly StandContext _context;

        public MicrogridParametersMeasuresController(StandContext context)
        {
            _context = context;
        }

        // GET: api/MicrogridParametersMeasures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MicrogridParametersMeasure>>> GetMicrogridParametersMeasures()
        {
            return await _context.MicrogridParametersMeasures.ToListAsync();
        }

        // GET: api/MicrogridParametersMeasures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MicrogridParametersMeasure>> GetMicrogridParametersMeasure(int id)
        {
            var microgridParametersMeasure = await _context.MicrogridParametersMeasures.FindAsync(id);

            if (microgridParametersMeasure == null)
            {
                return NotFound();
            }

            return microgridParametersMeasure;
        }

        // PUT: api/MicrogridParametersMeasures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMicrogridParametersMeasure(int id, MicrogridParametersMeasure microgridParametersMeasure)
        {
            if (id != microgridParametersMeasure.BlockId)
            {
                return BadRequest();
            }

            _context.Entry(microgridParametersMeasure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MicrogridParametersMeasureExists(id))
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

        // POST: api/MicrogridParametersMeasures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MicrogridParametersMeasure>> PostMicrogridParametersMeasure(MicrogridParametersMeasure microgridParametersMeasure)
        {
            _context.MicrogridParametersMeasures.Add(microgridParametersMeasure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMicrogridParametersMeasure", new { id = microgridParametersMeasure.BlockId }, microgridParametersMeasure);
        }

        // DELETE: api/MicrogridParametersMeasures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMicrogridParametersMeasure(int id)
        {
            var microgridParametersMeasure = await _context.MicrogridParametersMeasures.FindAsync(id);
            if (microgridParametersMeasure == null)
            {
                return NotFound();
            }

            _context.MicrogridParametersMeasures.Remove(microgridParametersMeasure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MicrogridParametersMeasureExists(int id)
        {
            return _context.MicrogridParametersMeasures.Any(e => e.BlockId == id);
        }
    }
}

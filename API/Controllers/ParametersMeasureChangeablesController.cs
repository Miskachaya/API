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
    public class ParametersMeasureChangeablesController : ControllerBase
    {
        private readonly StandContext _context;

        public ParametersMeasureChangeablesController(StandContext context)
        {
            _context = context;
        }

        // GET: api/ParametersMeasureChangeables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParametersMeasureChangeable>>> GetParametersMeasureChangeables()
        {
            return await _context.ParametersMeasureChangeables.ToListAsync();
        }

        // GET: api/ParametersMeasureChangeables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParametersMeasureChangeable>> GetParametersMeasureChangeable(int id)
        {
            var parametersMeasureChangeable = await _context.ParametersMeasureChangeables.FindAsync(id);

            if (parametersMeasureChangeable == null)
            {
                return NotFound();
            }

            return parametersMeasureChangeable;
        }
        // GET: api/ParametersMeasures/lv
        [HttpGet("lv")]
        public async Task<ActionResult<List<ParametersMeasureChangeable>>> GetParametersMeasure()
        {
            List<ParametersMeasureChangeable> parametersMeasureChangeableList = new List<ParametersMeasureChangeable>();
            var BlockId = _context.ParametersMeasureChangeables.AsNoTracking().GroupBy(x => x.BlockId);
            foreach (var block in BlockId)
            {
                parametersMeasureChangeableList.Add(block.OrderBy(x => x.Id).Last());
            }
            if (parametersMeasureChangeableList == null)
            {
                return NotFound();
            }

            return parametersMeasureChangeableList;
        }
        // PUT: api/ParametersMeasureChangeables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParametersMeasureChangeable(int id, ParametersMeasureChangeable parametersMeasureChangeable)
        {
            if (id != parametersMeasureChangeable.Id)
            {
                return BadRequest();
            }

            _context.Entry(parametersMeasureChangeable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParametersMeasureChangeableExists(id))
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

        // POST: api/ParametersMeasureChangeables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParametersMeasureChangeable>> PostParametersMeasureChangeable(ParametersMeasureChangeable parametersMeasureChangeable)
        {
            _context.ParametersMeasureChangeables.Add(parametersMeasureChangeable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParametersMeasureChangeable", new { id = parametersMeasureChangeable.Id }, parametersMeasureChangeable);
        }

        // DELETE: api/ParametersMeasureChangeables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParametersMeasureChangeable(int id)
        {
            var parametersMeasureChangeable = await _context.ParametersMeasureChangeables.FindAsync(id);
            if (parametersMeasureChangeable == null)
            {
                return NotFound();
            }

            _context.ParametersMeasureChangeables.Remove(parametersMeasureChangeable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParametersMeasureChangeableExists(int id)
        {
            return _context.ParametersMeasureChangeables.Any(e => e.Id == id);
        }
    }
}

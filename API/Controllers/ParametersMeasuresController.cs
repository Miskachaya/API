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
    public class ParametersMeasuresController : ControllerBase
    {
        private readonly StandContext _context;

        public ParametersMeasuresController(StandContext context)
        {
            _context = context;
        }

        // GET: api/ParametersMeasures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParametersMeasure>>> GetParametersMeasures()
        {
            return await _context.ParametersMeasures.ToListAsync();
        }

        // GET: api/ParametersMeasures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParametersMeasure>> GetParametersMeasure(int id)
        {
            var parametersMeasure = await _context.ParametersMeasures.FindAsync(id);

            if (parametersMeasure == null)
            {
                return NotFound();
            }

            return parametersMeasure;
        }
        // GET: api/ParametersMeasures/lv
        [HttpGet("lv")]
        public async Task<ActionResult<List<ParametersMeasure>>> GetParametersMeasure()
        {
            List<ParametersMeasure> parametersMeasureList = new List<ParametersMeasure>();
            var BlockId = _context.ParametersMeasures.AsNoTracking().GroupBy(x => x.BlockId);
            foreach (var block in BlockId)
            {
                parametersMeasureList.Add(block.OrderBy(x => x.Id).Last());
            }
            if (parametersMeasureList == null)
            {
                return NotFound();
            }

            return parametersMeasureList;
        }

        // PUT: api/ParametersMeasures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParametersMeasure(int id, ParametersMeasure parametersMeasure)
        {
            if (id != parametersMeasure.Id)
            {
                return BadRequest();
            }

            _context.Entry(parametersMeasure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParametersMeasureExists(id))
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

        // POST: api/ParametersMeasures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParametersMeasure>> PostParametersMeasure(ParametersMeasure parametersMeasure)
        {
            _context.ParametersMeasures.Add(parametersMeasure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParametersMeasure", new { id = parametersMeasure.Id }, parametersMeasure);
        }

        // DELETE: api/ParametersMeasures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParametersMeasure(int id)
        {
            var parametersMeasure = await _context.ParametersMeasures.FindAsync(id);
            if (parametersMeasure == null)
            {
                return NotFound();
            }

            _context.ParametersMeasures.Remove(parametersMeasure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParametersMeasureExists(int id)
        {
            return _context.ParametersMeasures.Any(e => e.Id == id);
        }
    }
}

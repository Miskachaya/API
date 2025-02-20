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
    public class ParametersChangeablesController : ControllerBase
    {
        private readonly StandContext _context;

        public ParametersChangeablesController(StandContext context)
        {
            _context = context;
        }

        // GET: api/ParametersChangeables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParametersChangeable>>> GetParametersChangeables()
        {
            return await _context.ParametersChangeables.ToListAsync();
        }

        // GET: api/ParametersChangeables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParametersChangeable>> GetParametersChangeable(int id)
        {
            var parametersChangeable = await _context.ParametersChangeables.FindAsync(id);

            if (parametersChangeable == null)
            {
                return NotFound();
            }

            return parametersChangeable;
        }
        // GET: api/ParametersChangeables/lv
        [HttpGet("lv")]
        public async Task<ActionResult<List<ParametersChangeable>>> GetParametersMeasure()
        {
            List<ParametersChangeable> parametersChangeableList = new List<ParametersChangeable>();
            var BlockId = _context.ParametersChangeables.AsNoTracking().GroupBy(x => x.BlockId);
            foreach (var block in BlockId)
            {
                parametersChangeableList.Add(block.OrderBy(x => x.Id).Last());
            }
            if (parametersChangeableList == null)
            {
                return NotFound();
            }

            return parametersChangeableList;
        }
        // PUT: api/ParametersChangeables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParametersChangeable(int id, ParametersChangeable parametersChangeable)
        {
            if (id != parametersChangeable.Id)
            {
                return BadRequest();
            }

            _context.Entry(parametersChangeable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParametersChangeableExists(id))
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

        // POST: api/ParametersChangeables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParametersChangeable>> PostParametersChangeable(ParametersChangeable parametersChangeable)
        {
            _context.ParametersChangeables.Add(parametersChangeable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParametersChangeable", new { id = parametersChangeable.Id }, parametersChangeable);
        }

        // DELETE: api/ParametersChangeables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParametersChangeable(int id)
        {
            var parametersChangeable = await _context.ParametersChangeables.FindAsync(id);
            if (parametersChangeable == null)
            {
                return NotFound();
            }

            _context.ParametersChangeables.Remove(parametersChangeable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParametersChangeableExists(int id)
        {
            return _context.ParametersChangeables.Any(e => e.Id == id);
        }
    }
}

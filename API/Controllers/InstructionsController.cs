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
    public class InstructionsController : ControllerBase
    {
        private readonly StandContext _context;

        public InstructionsController(StandContext context)
        {
            _context = context;
        }

        // GET: api/Instructions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructions>>> GetInstructions()
        {
            return await _context.Instructions.ToListAsync();
        }

        // GET: api/Instructions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instructions>> GetInstructions(int id)
        {
            var instructions = await _context.Instructions.FindAsync(id);

            if (instructions == null)
            {
                return NotFound();
            }

            return instructions;
        }

        // PUT: api/Instructions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructions(int id, Instructions instructions)
        {
            if (id != instructions.InstructionID)
            {
                return BadRequest();
            }

            _context.Entry(instructions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructionsExists(id))
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

        // POST: api/Instructions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Instructions>> PostInstructions(Instructions instructions)
        {
            _context.Instructions.Add(instructions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstructions", new { id = instructions.InstructionID }, instructions);
        }

        // DELETE: api/Instructions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructions(int id)
        {
            var instructions = await _context.Instructions.FindAsync(id);
            if (instructions == null)
            {
                return NotFound();
            }

            _context.Instructions.Remove(instructions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstructionsExists(int id)
        {
            return _context.Instructions.Any(e => e.InstructionID == id);
        }
    }
}

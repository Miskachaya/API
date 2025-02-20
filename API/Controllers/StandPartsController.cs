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
    public class StandPartsController : ControllerBase
    {
        private readonly StandContext _context;

        public StandPartsController(StandContext context)
        {
            _context = context;
        }

        // GET: api/StandParts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StandPart>>> GetStandParts()
        {
            return await _context.StandParts.ToListAsync();
        }

        // GET: api/StandParts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StandPart>> GetStandPart(int id)
        {
            var standPart = await _context.StandParts.FindAsync(id);

            if (standPart == null)
            {
                return NotFound();
            }

            return standPart;
        }

        // PUT: api/StandParts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStandPart(int id, StandPart standPart)
        {
            if (id != standPart.StandId)
            {
                return BadRequest();
            }

            _context.Entry(standPart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandPartExists(id))
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

        // POST: api/StandParts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StandPart>> PostStandPart(StandPart standPart)
        {
            _context.StandParts.Add(standPart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStandPart", new { id = standPart.StandId }, standPart);
        }
        //public string Get()
        //{
        //    return "fff";
        //}


        // DELETE: api/StandParts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStandPart(int id)
        {
            var standPart = await _context.StandParts.FindAsync(id);
            if (standPart == null)
            {
                return NotFound();
            }

            _context.StandParts.Remove(standPart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StandPartExists(int id)
        {
            return _context.StandParts.Any(e => e.StandId == id);
        }
    }
}

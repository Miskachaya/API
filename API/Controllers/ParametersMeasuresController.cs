using API.Configurations;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

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
            return await _context.ParametersMeasure.ToListAsync();
        }

        // GET: api/ParametersMeasures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParametersMeasure>> GetParametersMeasure(int id)
        {
            var parametersMeasure = await _context.ParametersMeasure.FindAsync(id);

            if (parametersMeasure == null)
            {
                return NotFound();
            }

            return parametersMeasure;
        }
        // GET: api/ParametersMeasures/цфlv
        [HttpGet("lv")]
        public async Task<ActionResult<List<ParametersMeasure>>> GetParametersMeasure()
        {
            List<ParametersMeasure> parametersMeasureList = new List<ParametersMeasure>();
            var BlockId = _context.ParametersMeasure.
                AsNoTracking().
                GroupBy(x => x.BlockId);
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
        // GET: api/ParametersMeasures/lv
        [HttpGet("l")]
        public async Task<ActionResult<IEnumerable<ParametersMeasure>>> GetParametersMeajsure()
        {
            List<ParametersMeasure> parametersMeasureList = new List<ParametersMeasure>();
            var BlockId = _context.ParametersMeasure.
                AsNoTracking().
                GroupBy(x => x.BlockId);
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
        // GET: api/ParametersMeasures/{}
        //[HttpGet("{a}d{b}p{par}")]
        //public async Task<ActionResult<IEnumerable<ParametersMeasure>>> GetParametersMeasureDate(DateTime a, DateTime b, string par)
        //{
        //    switch (par)
        //    {
        //        case "Voltage":
        //        var BlockId = await _context.ParametersMeasure
        //        .AsNoTracking()
        //        .Where(x => x.Time.Value > a && x.Time.Value < b)
        //        .ToListAsync();
        //        return BlockId;
        //    }
            
        //}

        // PUT: api/ParametersMeasures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{time}h{cur_val}")]
        public async Task<IActionResult> PutParametersMeasure(DateTime time,double cur_val)
        {
            ParametersMeasure obj = await _context.ParametersMeasure
                .AsNoTracking()
                .FirstOrDefaultAsync(x=> 
                                      x.Time.Value.Hour ==  time.Hour
                                      && x.Time.Value.Minute == time.Minute
                                      && x.Time.Value.Second == time.Second);
            //if (time != obj.Time)
            //{
            //    return BadRequest();
            //}

            
            _context.Entry(obj).State = EntityState.Modified;
            obj.CurrentValue = cur_val;
            await _context.SaveChangesAsync();
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch ()
            //{
            //    //if (!ParametersMeasureExists(time))
            //    //{
            //    //    return NotFound();
            //    //}
            //    //else
            //    //{
            //    //    throw;
            //    //}
            //}

            return NoContent();
        }

        // POST: api/ParametersMeasures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParametersMeasure>> PostParametersMeasure(ParametersMeasure parametersMeasure)
        {
            _context.ParametersMeasure.Add(parametersMeasure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParametersMeasure", new { id = parametersMeasure.Id }, parametersMeasure);
        }

        // DELETE: api/ParametersMeasures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParametersMeasure(int id)
        {
            var parametersMeasure = await _context.ParametersMeasure.FindAsync(id);
            if (parametersMeasure == null)
            {
                return NotFound();
            }

            _context.ParametersMeasure.Remove(parametersMeasure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParametersMeasureExists(int id)
        {
            return _context.ParametersMeasure.Any(e => e.Id == id);
        }
    }
}

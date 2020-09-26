using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Codie2.Models;

namespace Codie2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesCodiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TimesCodiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TimesCodies
        [HttpGet]
        public IEnumerable<TimesCodie> GetTimesCodies()
        {
            return _context.Times;
        }

        // GET: api/TimesCodies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimesCodie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timesCodie = await _context.Times.FindAsync(id);

            if (timesCodie == null)
            {
                return NotFound();
            }

            return Ok(timesCodie);
        }

        // PUT: api/TimesCodies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimesCodie([FromRoute] int id, [FromBody] TimesCodie timesCodie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timesCodie.TimeID)
            {
                return BadRequest();
            }

            _context.Entry(timesCodie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimesCodieExists(id))
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

        // POST: api/TimesCodies
        [HttpPost]
        public async Task<IActionResult> PostTimesCodie([FromBody] TimesCodie timesCodie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Times.Add(timesCodie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimesCodie", new { id = timesCodie.TimeID }, timesCodie);
        }

        // DELETE: api/TimesCodies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimesCodie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timesCodie = await _context.Times.FindAsync(id);
            if (timesCodie == null)
            {
                return NotFound();
            }

            _context.Times.Remove(timesCodie);
            await _context.SaveChangesAsync();

            return Ok(timesCodie);
        }

        private bool TimesCodieExists(int id)
        {
            return _context.Times.Any(e => e.TimeID == id);
        }
    }
}
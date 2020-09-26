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
    public class CargosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CargosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cargos
        [HttpGet]
        public IEnumerable<Cargo> GetCargo()
        {
            return _context.Cargo;
        }

        // GET: api/Cargos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cargo = await _context.Cargo.FindAsync(id);

            if (cargo == null)
            {
                return NotFound();
            }

            return Ok(cargo);
        }

        // PUT: api/Cargos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargo([FromRoute] int id, [FromBody] Cargo cargo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cargo.CargoID)
            {
                return BadRequest();
            }

            _context.Entry(cargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(id))
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

        // POST: api/Cargos
        [HttpPost]
        public async Task<IActionResult> PostCargo([FromBody] Cargo cargo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cargo.Add(cargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCargo", new { id = cargo.CargoID }, cargo);
        }

        // DELETE: api/Cargos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cargo = await _context.Cargo.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }

            _context.Cargo.Remove(cargo);
            await _context.SaveChangesAsync();

            return Ok(cargo);
        }

        private bool CargoExists(int id)
        {
            return _context.Cargo.Any(e => e.CargoID == id);
        }
    }
}
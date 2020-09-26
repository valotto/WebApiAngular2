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
    public class ColaboradorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColaboradorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Colaboradors
        [HttpGet]
        public IEnumerable<Colaborador> GetColaborador()
        {
            return _context.Colaborador;
        }

        // GET: api/Colaboradors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetColaborador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var colaborador = await _context.Colaborador.FindAsync(id);

            if (colaborador == null)
            {
                return NotFound();
            }

            return Ok(colaborador);
        }

        // PUT: api/Colaboradors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColaborador([FromRoute] int id, [FromBody] Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colaborador.ID)
            {
                return BadRequest();
            }

            _context.Entry(colaborador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboradorExists(id))
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

        // POST: api/Colaboradors
        [HttpPost]
        public async Task<IActionResult> PostColaborador([FromBody] Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Colaborador.Add(colaborador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColaborador", new { id = colaborador.ID }, colaborador);
        }

        // DELETE: api/Colaboradors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaborador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var colaborador = await _context.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            _context.Colaborador.Remove(colaborador);
            await _context.SaveChangesAsync();

            return Ok(colaborador);
        }

        private bool ColaboradorExists(int id)
        {
            return _context.Colaborador.Any(e => e.ID == id);
        }
    }
}
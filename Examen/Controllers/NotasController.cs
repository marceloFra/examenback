using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen.Models;
using Microsoft.AspNetCore.Cors;

namespace Examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Politica")]


    public class NotasController : ControllerBase
    {
        private readonly BDExamenContext _context;

        public NotasController(BDExamenContext context)
        {
            _context = context;
        }

        // GET: api/Notas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nota>>> GetNota()
        {
            return await _context.Nota.ToListAsync();
        }

        // GET: api/Notas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nota>> GetNota(int id)
        {
            var nota = await _context.Nota.FindAsync(id);

            if (nota == null)
            {
                return NotFound();
            }

            return nota;
        }

        // PUT: api/Notas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNota(int id, Nota nota)
        {
            nota.IdAlumnoNavigation = null;
            nota.IdCursoNavigation = null;
            nota.Promedio = (nota.PracticaA + nota.PracticaB + nota.PracticaC) / 3;
            nota.Promedio = decimal.Round(nota.Promedio, 2);
            if (id != nota.IdNota)
            {
                return BadRequest();
            }

            _context.Entry(nota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaExists(id))
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

        // POST: api/Notas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nota>> PostNota(Nota nota)
        {
            nota.IdNota = null;
            nota.IdAlumnoNavigation = null;
            nota.IdCursoNavigation = null;
            nota.Promedio = (nota.PracticaA + nota.PracticaB + nota.PracticaC) / 3;
            nota.Promedio = decimal.Round(nota.Promedio, 2);
            _context.Nota.Add(nota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNota", new { id = nota.IdNota }, nota);
        }

        // DELETE: api/Notas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            var nota = await _context.Nota.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }

            _context.Nota.Remove(nota);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotaExists(int id)
        {
            return _context.Nota.Any(e => e.IdNota == id);
        }
    }
}

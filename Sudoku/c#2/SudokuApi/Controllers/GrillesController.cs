using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Grilles.Models.GrilleData;
using sudokuData;

namespace SudokuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrillesController : ControllerBase
    {
        private readonly GrilleDbContext _context;

        public GrillesController()
        {
            _context = new GrilleDbContext();
        }

        // GET: api/Grilles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grille>>> GetGrille()
        {
          if (_context.Grille == null)
          {
              return NotFound();
          }
            return await _context.Grille.ToListAsync();
        }

        // GET: api/Grilles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grille>> GetGrille(int id)
        {
          if (_context.Grille == null)
          {
              return NotFound();
          }
            var grille = await _context.Grille.FindAsync(id);

            if (grille == null)
            {
                return NotFound();
            }

            return grille;
        }

        // PUT: api/Grilles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrille(int id, Grille grille)
        {
            if (id != grille.Id)
            {
                return BadRequest();
            }

            _context.Entry(grille).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrilleExists(id))
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

        // POST: api/Grilles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grille>> PostGrille(Grille grille)
        {
          if (_context.Grille == null)
          {
              return Problem("Entity set 'GrilleDbContext.Grille'  is null.");
          }
            _context.Grille.Add(grille);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrille", new { id = grille.Id }, grille);
        }

        // DELETE: api/Grilles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrille(int id)
        {
            if (_context.Grille == null)
            {
                return NotFound();
            }
            var grille = await _context.Grille.FindAsync(id);
            if (grille == null)
            {
                return NotFound();
            }

            _context.Grille.Remove(grille);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrilleExists(int id)
        {
            return (_context.Grille?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

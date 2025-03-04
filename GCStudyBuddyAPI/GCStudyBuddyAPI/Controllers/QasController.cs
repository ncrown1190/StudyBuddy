using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCStudyBuddyAPI.Entities;

namespace GCStudyBuddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QasController : ControllerBase
    {
        private readonly GcstudyBuddyDbContext _context;

        public QasController(GcstudyBuddyDbContext context)
        {
            _context = context;
        }

        // GET: api/Qas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qa>>> GetQas()
        {
            return await _context.Qas.ToListAsync();
        }

        // GET: api/Qas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Qa>> GetQa(int id)
        {
            var qa = await _context.Qas.FindAsync(id);

            if (qa == null)
            {
                return NotFound();
            }

            return qa;
        }

        // PUT: api/Qas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQa(int id, Qa qa)
        {
            if (id != qa.Id)
            {
                return BadRequest();
            }

            _context.Entry(qa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QaExists(id))
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

        // POST: api/Qas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Qa>> PostQa(Qa qa)
        {
            _context.Qas.Add(qa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQa", new { id = qa.Id }, qa);
        }

        // DELETE: api/Qas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQa(int id)
        {
            var qa = await _context.Qas.FindAsync(id);
            if (qa == null)
            {
                return NotFound();
            }

            _context.Qas.Remove(qa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QaExists(int id)
        {
            return _context.Qas.Any(e => e.Id == id);
        }
    }
}

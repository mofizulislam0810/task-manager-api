using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taskmanagerAPI.Models;

namespace taskmanagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlTasksController : ControllerBase
    {
        private readonly KaratoaDbDevContext _context;

        public BlTasksController(KaratoaDbDevContext context)
        {
            _context = context;
        }

        // GET: api/BlTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlTask>>> GetBlTasks()
        {
            return await _context.BlTasks.ToListAsync();
        }

        // GET: api/BlTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlTask>> GetBlTask(int id)
        {
            var blTask = await _context.BlTasks.FindAsync(id);

            if (blTask == null)
            {
                return NotFound();
            }

            return blTask;
        }

        // PUT: api/BlTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlTask(int id, BlTask blTask)
        {
            if (id != blTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(blTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlTaskExists(id))
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

        // POST: api/BlTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlTask>> PostBlTask(BlTask blTask)
        {
            _context.BlTasks.Add(blTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlTask", new { id = blTask.Id }, blTask);
        }

        // DELETE: api/BlTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlTask(int id)
        {
            var blTask = await _context.BlTasks.FindAsync(id);
            if (blTask == null)
            {
                return NotFound();
            }

            _context.BlTasks.Remove(blTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlTaskExists(int id)
        {
            return _context.BlTasks.Any(e => e.Id == id);
        }
    }
}

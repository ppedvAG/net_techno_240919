using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HalloASP.Models;

namespace HalloASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PillenAPIController : ControllerBase
    {
        private readonly HalloASPContext _context;

        public PillenAPIController(HalloASPContext context)
        {
            _context = context;
        }

        // GET: api/PillenAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pille>>> GetPille()
        {
            return await _context.Pille.ToListAsync();
        }

        // GET: api/PillenAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pille>> GetPille(int id)
        {
            var pille = await _context.Pille.FindAsync(id);

            if (pille == null)
            {
                return NotFound();
            }

            return pille;
        }

        // PUT: api/PillenAPI/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPille(int id, Pille pille)
        {
            if (id != pille.Id)
            {
                return BadRequest();
            }

            _context.Entry(pille).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PilleExists(id))
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

        // POST: api/PillenAPI
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pille>> PostPille(Pille pille)
        {
            _context.Pille.Add(pille);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPille", new { id = pille.Id }, pille);
        }

        // DELETE: api/PillenAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pille>> DeletePille(int id)
        {
            var pille = await _context.Pille.FindAsync(id);
            if (pille == null)
            {
                return NotFound();
            }

            _context.Pille.Remove(pille);
            await _context.SaveChangesAsync();

            return pille;
        }

        private bool PilleExists(int id)
        {
            return _context.Pille.Any(e => e.Id == id);
        }
    }
}

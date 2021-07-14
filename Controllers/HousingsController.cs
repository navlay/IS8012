using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Homes365.Data;
using Homes365.Models;

namespace Homes365.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousingsController : ControllerBase
    {
        private readonly Homes365Context _context;

        public HousingsController(Homes365Context context)
        {
            _context = context;
        }

        // GET: api/Housings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Housing>>> GetHousing()
        {
            return await _context.Housing.ToListAsync();
        }

        // GET: api/Housings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Housing>> GetHousing(int id)
        {
            var housing = await _context.Housing.FindAsync(id);

            if (housing == null)
            {
                return NotFound();
            }

            return housing;
        }

        // PUT: api/Housings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHousing(int id, Housing housing)
        {
            if (id != housing.Id)
            {
                return BadRequest();
            }

            _context.Entry(housing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HousingExists(id))
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

        // POST: api/Housings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Housing>> PostHousing(Housing housing)
        {
            _context.Housing.Add(housing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHousing", new { id = housing.Id }, housing);
        }

        // DELETE: api/Housings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Housing>> DeleteHousing(int id)
        {
            var housing = await _context.Housing.FindAsync(id);
            if (housing == null)
            {
                return NotFound();
            }

            _context.Housing.Remove(housing);
            await _context.SaveChangesAsync();

            return housing;
        }

        private bool HousingExists(int id)
        {
            return _context.Housing.Any(e => e.Id == id);
        }
    }
}

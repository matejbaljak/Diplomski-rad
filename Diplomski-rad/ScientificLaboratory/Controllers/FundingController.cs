using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientificLaboratory.Data;
using ScientificLaboratory.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificLaboratory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FundingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetFundings()
        {
            var fundings = await _context.Fundings.ToListAsync();
            return Ok(fundings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFunding(int id)
        {
            var funding = await _context.Fundings.FindAsync(id);

            if (funding == null)
            {
                return NotFound();
            }

            return Ok(funding);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFunding([FromBody] Funding funding)
        {
            if (ModelState.IsValid)
            {
                _context.Fundings.Add(funding);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetFunding), new { id = funding.FundingId }, funding);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFunding(int id, [FromBody] Funding funding)
        {
            if (id != funding.FundingId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(funding).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Fundings.Any(f => f.FundingId == id))
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

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFunding(int id)
        {
            var funding = await _context.Fundings.FindAsync(id);
            if (funding == null)
            {
                return NotFound();
            }

            _context.Fundings.Remove(funding);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

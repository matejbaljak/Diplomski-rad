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
    public class FundingByYearController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FundingByYearController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetFundingByYears()
        {
            var fundingByYears = await _context.FundingByYears.ToListAsync();
            return Ok(fundingByYears);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFundingByYear(int id)
        {
            var fundingByYear = await _context.FundingByYears.FindAsync(id);

            if (fundingByYear == null)
            {
                return NotFound();
            }

            return Ok(fundingByYear);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFundingByYear([FromBody] FundingByYear fundingByYear)
        {
            if (ModelState.IsValid)
            {
                _context.FundingByYears.Add(fundingByYear);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetFundingByYear), new { id = fundingByYear.Id }, fundingByYear);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFundingByYear(int id, [FromBody] FundingByYear fundingByYear)
        {
            if (id != fundingByYear.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(fundingByYear).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.FundingByYears.Any(fy => fy.Id == id))
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
        public async Task<IActionResult> DeleteFundingByYear(int id)
        {
            var fundingByYear = await _context.FundingByYears.FindAsync(id);
            if (fundingByYear == null)
            {
                return NotFound();
            }

            _context.FundingByYears.Remove(fundingByYear);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

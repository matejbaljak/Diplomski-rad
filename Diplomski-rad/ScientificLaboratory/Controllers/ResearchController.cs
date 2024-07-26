using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientificLaboratory.Data;
using ScientificLaboratory.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificLaboratory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResearcherController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResearcherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Researcher
        [HttpGet]
        public async Task<IActionResult> GetResearchers()
        {
            var researchers = await _context.Researchers.ToListAsync();
            return Ok(researchers);
        }

        // GET: api/Researcher/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResearcher(int id)
        {
            var researcher = await _context.Researchers.FindAsync(id);

            if (researcher == null)
            {
                return NotFound();
            }

            return Ok(researcher);
        }

        // POST: api/Researcher
        [HttpPost]
        public async Task<IActionResult> CreateResearcher(Researcher researcher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Researchers.Add(researcher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResearcher), new { id = researcher.ResearcherId }, researcher);
        }

        // PUT: api/Researcher/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResearcher(int id, Researcher researcher)
        {
            if (id != researcher.ResearcherId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingResearcher = await _context.Researchers.FindAsync(id);
            if (existingResearcher == null)
            {
                return NotFound();
            }

            existingResearcher.Name = researcher.Name;
            existingResearcher.Institution = researcher.Institution;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Researcher/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResearcher(int id)
        {
            var researcher = await _context.Researchers.FindAsync(id);
            if (researcher == null)
            {
                return NotFound();
            }

            _context.Researchers.Remove(researcher);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

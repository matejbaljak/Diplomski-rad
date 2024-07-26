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
    public class ProjectResearcherController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectResearcherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectResearcher
        [HttpGet]
        public async Task<IActionResult> GetProjectResearchers()
        {
            var projectResearchers = await _context.ProjectResearchers
                .Include(pr => pr.Project)
                .Include(pr => pr.Researcher)
                .ToListAsync();
            return Ok(projectResearchers);
        }

        // GET: api/ProjectResearcher/Project/5
        [HttpGet("Project/{projectId}")]
        public async Task<IActionResult> GetResearchersForProject(int projectId)
        {
            var projectResearchers = await _context.ProjectResearchers
                .Where(pr => pr.ProjectId == projectId)
                .Include(pr => pr.Researcher)
                .ToListAsync();

            if (!projectResearchers.Any())
            {
                return NotFound();
            }

            return Ok(projectResearchers);
        }

        // GET: api/ProjectResearcher/Researcher/5
        [HttpGet("Researcher/{researcherId}")]
        public async Task<IActionResult> GetProjectsForResearcher(int researcherId)
        {
            var projectResearchers = await _context.ProjectResearchers
                .Where(pr => pr.ResearcherId == researcherId)
                .Include(pr => pr.Project)
                .ToListAsync();

            if (!projectResearchers.Any())
            {
                return NotFound();
            }

            return Ok(projectResearchers);
        }

        // POST: api/ProjectResearcher
        [HttpPost]
        public async Task<IActionResult> CreateProjectResearcher(ProjectResearcher projectResearcher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectResearchers.Add(projectResearcher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProjectResearchers), new { projectId = projectResearcher.ProjectId, researcherId = projectResearcher.ResearcherId }, projectResearcher);
        }

        // DELETE: api/ProjectResearcher/5/5
        [HttpDelete("{projectId}/{researcherId}")]
        public async Task<IActionResult> DeleteProjectResearcher(int projectId, int researcherId)
        {
            var projectResearcher = await _context.ProjectResearchers
                .FirstOrDefaultAsync(pr => pr.ProjectId == projectId && pr.ResearcherId == researcherId);

            if (projectResearcher == null)
            {
                return NotFound();
            }

            _context.ProjectResearchers.Remove(projectResearcher);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

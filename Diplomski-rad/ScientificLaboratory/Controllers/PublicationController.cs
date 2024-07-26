using Microsoft.AspNetCore.Mvc;
using ScientificLaboratory.Data;
using ScientificLaboratory.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ScientificLaboratory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PublicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Publication
        [HttpGet]
        public async Task<IActionResult> GetPublications()
        {
            var publications = await _context.Publications.ToListAsync();
            return Ok(publications);
        }

        // GET: api/Publication/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublication(int id)
        {
            var publication = await _context.Publications.FindAsync(id);

            if (publication == null)
            {
                return NotFound();
            }

            return Ok(publication);
        }

        // POST: api/Publication
        [HttpPost]
        public async Task<IActionResult> PostPublication([FromBody] Publication publication)
        {
            _context.Publications.Add(publication);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPublication), new { id = publication.Id }, publication);
        }

        // PUT: api/Publication/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublication(int id, [FromBody] Publication publication)
        {
            if (id != publication.Id)
            {
                return BadRequest();
            }

            _context.Entry(publication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Publications.Any(e => e.Id == id))
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

        // DELETE: api/Publication/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublication(int id)
        {
            var publication = await _context.Publications.FindAsync(id);
            if (publication == null)
            {
                return NotFound();
            }

            _context.Publications.Remove(publication);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
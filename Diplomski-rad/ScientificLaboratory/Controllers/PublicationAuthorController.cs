
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientificLaboratory.Data;
using ScientificLaboratory.Models;

[Route("api/[controller]")]
[ApiController]
public class PublicationAuthorController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PublicationAuthorController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: api/PublicationAuthor
    [HttpPost]
    public async Task<IActionResult> AddAuthorToPublication([FromBody] PublicationAuthor publicationAuthor)
    {
        if (_context.Publications.Any(p => p.Id == publicationAuthor.PublicationId) &&
            _context.Authors.Any(a => a.AuthorId == publicationAuthor.AuthorId))
        {
            _context.PublicationAuthors.Add(publicationAuthor);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPublicationAuthor", new { id = publicationAuthor.PublicationId }, publicationAuthor);
        }
        return NotFound("Publication or Author not found.");
    }

    // GET: api/PublicationAuthor/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthorsByPublication(int id)
    {
        var authors = await _context.PublicationAuthors
                                     .Where(pa => pa.PublicationId == id)
                                     .Include(pa => pa.Author)
                                     .Select(pa => pa.Author)
                                     .ToListAsync();

        if (!authors.Any())
        {
            return NotFound("No authors found for this publication.");
        }

        return Ok(authors);
    }

    // DELETE: api/PublicationAuthor/5/10
    [HttpDelete("{publicationId}/{authorId}")]
    public async Task<IActionResult> RemoveAuthorFromPublication(int publicationId, int authorId)
    {
        var publicationAuthor = await _context.PublicationAuthors
                                              .FirstOrDefaultAsync(pa => pa.PublicationId == publicationId && pa.AuthorId == authorId);

        if (publicationAuthor == null)
        {
            return NotFound("Link between publication and author not found.");
        }

        _context.PublicationAuthors.Remove(publicationAuthor);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

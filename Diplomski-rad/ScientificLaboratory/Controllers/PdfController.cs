using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientificLaboratory.Data;
using ScientificLaboratory.Models;
using System.IO;
using System.Threading.Tasks;

namespace ScientificLaboratory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PdfController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST api/pdf/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadPdf(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var pdfFile = new Pdf
                    {
                        FileName = file.FileName,
                        Content = memoryStream.ToArray()
                    };

                    _context.PdfFiles.Add(pdfFile);
                    await _context.SaveChangesAsync();
                    return Ok(new { pdfFile.Id });
                }
            }

            return BadRequest("No file uploaded.");
        }

        // GET api/pdf/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPdf(int id)
        {
            var pdfFile = await _context.PdfFiles.FindAsync(id);
            if (pdfFile == null)
            {
                return NotFound();
            }

            return File(pdfFile.Content, "application/pdf", pdfFile.FileName);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePdf(int id)
        {
            var pdfFile = await _context.PdfFiles.FindAsync(id);
            if (pdfFile == null)
            {
                return NotFound();
            }

            _context.PdfFiles.Remove(pdfFile);
            await _context.SaveChangesAsync();

            return Ok($"PDF with ID {id} deleted successfully.");
        }
    }
}

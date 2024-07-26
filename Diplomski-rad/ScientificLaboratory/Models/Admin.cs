using System.ComponentModel.DataAnnotations;

namespace ScientificLaboratory.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        public string? Email { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow; 
    }
}

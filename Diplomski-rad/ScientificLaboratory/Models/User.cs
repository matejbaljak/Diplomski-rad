using System.ComponentModel.DataAnnotations;

namespace ScientificLaboratory.Models
{
    public class User
    {
        public int Id { get; set; } // Id follows convention, no need for [Key]

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

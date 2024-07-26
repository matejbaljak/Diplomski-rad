using System.ComponentModel.DataAnnotations;

namespace ScientificLaboratory.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public int StartTime { get; set; }

        [Required]
        public int EndTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }



        // Foreign key for Project Leader
        public int ProjectLeaderId { get; set; }
        public Researcher ProjectLeader { get; set; }  // Navigation property to Project Leader

        // Navigation property for many-to-many relationship with Researchers
        public List<ProjectResearcher> ProjectResearchers { get; set; }

    }
}

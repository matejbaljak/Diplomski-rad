namespace ScientificLaboratory.Models
{

    // Join table for many-to-many relationship between Projects and Researchers

    public class ProjectResearcher
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int ResearcherId { get; set; }
        public Researcher Researcher { get; set; }
    }
}

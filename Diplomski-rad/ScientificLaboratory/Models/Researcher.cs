namespace ScientificLaboratory.Models
{
    public class Researcher
    {
        public int ResearcherId { get; set; }
        public string Name { get; set; }

        public string? Institution { get; set; }


        // Navigation property for many-to-many relationship with Projects
        public List<ProjectResearcher> ProjectResearchers { get; set; }
    }
}

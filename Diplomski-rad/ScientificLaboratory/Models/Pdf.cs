namespace ScientificLaboratory.Models
{
    public class Pdf
    {
        public int Id { get; set; }

        public string? FileName { get; set; }


        public byte[] Content { get; set; }

        // Navigation property
        public Publication Publication { get; set; }

        // Foreign key
        public int PublicationId { get; set; }
    }
}

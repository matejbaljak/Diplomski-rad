namespace ScientificLaboratory.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public string? Institution { get; set; }


        public List<PublicationAuthor> PublicationAuthors { get; set; }


    }
}

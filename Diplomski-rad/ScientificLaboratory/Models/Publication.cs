using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ScientificLaboratory.Models
{
    public class Publication
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }
        
        public string Field { get; set; }

        public int Year { get; set; }

        public int? Pages { get; set; }

        public string? ISSN { get; set; }

        public string? DOI { get; set; }



        public int PdfId { get; set; }  

        public Pdf Pdf { get; set; }


        public List<PublicationAuthor> PublicationAuthors { get; set; }

    }
}

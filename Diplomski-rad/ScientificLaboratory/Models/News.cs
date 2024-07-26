using System.ComponentModel.DataAnnotations;

namespace ScientificLaboratory.Models
{
    public class News
    {

        public int Id { get; set; } // Primary key

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; } // Title of the news article

        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; } // Full news content

        [Required(ErrorMessage = "Publish date is required")]
        public DateTime PublishDate { get; set; } // Date of publication

        [Required(ErrorMessage = "Category is required")]
        [StringLength(100, ErrorMessage = "Category name cannot be longer than 100 characters")]
        public string Category { get; set; } // Category of the news

    }
}


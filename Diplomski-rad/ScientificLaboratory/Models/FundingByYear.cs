using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ScientificLaboratory.Models
{
    public class FundingByYear
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Amount { get; set; }


        [ForeignKey("Funding")]
        public int FundingId { get; set; }

        public Funding Funding { get; set; }
    }
}

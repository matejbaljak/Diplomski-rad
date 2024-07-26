using System.ComponentModel.DataAnnotations;

namespace ScientificLaboratory.Models
{
    public class Funding
    {
        [Key]
        public int FundingId { get; set; }

        [Required]
        public string Source { get; set; }

        public string SponsorName { get; set; }  

        public decimal TotalAmount { get; set; }

        public List<FundingByYear> FundingbyYears { get; set; }
    }
}

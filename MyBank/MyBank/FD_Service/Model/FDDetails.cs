using MyBank.Model;
using System.ComponentModel.DataAnnotations;

namespace FD_Service.Model
{
    public class FDDetails
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "FD Plan is required")]
        public string FDPlan { get; set; }
        
        [Required(ErrorMessage = "Year is required")]
        public double Year{ get; set; }

        [Required(ErrorMessage = "Percentage is required")]
        public decimal Percentage { get; set; }

        public ICollection<CustomerFDDetails> CustomerFDDetails{ get; set; }

    }
}

using MyBank.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FD_Service.Model
{
    public class CustomerFDDetails
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "AccountId is required")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public double Amount { get; set; }

        [ForeignKey("FDPlan")]
        [Required(ErrorMessage = "Plan is required")]
       // public PlanType Plan { get; set; }
        public string Plan { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        public double MaturityAmount { get; set; }

        [Required]
        public double TotalAmount { get; set; }
    }
    //public enum PlanType
    //{
    //    A,
    //    B,
    //    C
    //}
}

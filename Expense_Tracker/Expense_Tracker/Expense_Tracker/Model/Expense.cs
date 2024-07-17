using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Model
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PersonId")]
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Amount{ get; set; }

        [ForeignKey("CategoryId")]
        [Required]
        public int CategoryId{ get; set; }
        public Category Category { get; set; }

        [Required]
        public DateOnly ExpenseDate{ get; set; }

    }
}

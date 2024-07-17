using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Model
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email{ get; set; }
        public ICollection<Expense> Expense { get; set; }

    }
}

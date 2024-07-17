using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name{ get; set; }

        public ICollection<Expense> Expense { get; set; }
    }
}

namespace Expense_Tracker.Model.Dto
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        public DateOnly ExpenseDate { get; set; }
    }
}

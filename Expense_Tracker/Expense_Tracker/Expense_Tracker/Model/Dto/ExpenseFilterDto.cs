namespace Expense_Tracker.Model.Dto
{
    public class ExpenseFilterDto
    {
        public DateOnly? StartDate { get; set; } //2024-07-19
        public DateOnly? EndDate { get; set; } //2024-07-19
        public ExpenseType? ExpenseType { get; set; }
    }

    public enum ExpenseType
    {
        Pastweek,
        Lastmonth,
        Last3months,
        Custom
    }
}

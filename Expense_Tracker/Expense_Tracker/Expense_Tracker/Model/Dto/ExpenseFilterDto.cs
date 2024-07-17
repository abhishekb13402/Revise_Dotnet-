namespace Expense_Tracker.Model.Dto
{
    public class ExpenseFilterDto
    {
        public ExpenseType ExpenseType { get; set; }
    }

    public enum ExpenseType
    {
        Pastweek,
        Lastmonth,
        Last3months,
        Custom
    }
}

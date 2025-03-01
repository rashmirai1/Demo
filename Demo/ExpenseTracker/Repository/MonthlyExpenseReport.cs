namespace ExpenseTracker.Repository
{
    internal class MonthlyExpenseReport
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalAmount { get; set; }
        public int ExpenseCount { get; set; }
    }
}
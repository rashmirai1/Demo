using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Interface

{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> GetAll();
        Expense GetById(int id);
        void Add(Expense expense);
        void Update(Expense expense);
        void Delete(int id);
        IEnumerable<Expense> GetExpensesByCategory(int categoryId);
        Dictionary<string, decimal> GetMonthlyReport();
    }
}


using ExpenseTracker.Data;
using ExpenseTracker.Interface;
using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseDBContext _context;

        public ExpenseRepository(ExpenseDBContext context)
        {
            _context = context;
        }

        public void Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Expense> GetAll()
        {
            return _context.Expenses.Include("Category").ToList();

        }

        public Expense GetById(int id)
        {
            return _context.Expenses.Include("Category").FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Expense> GetExpensesByCategory(int categoryId)
        {
            return _context.Expenses
       .Include(e => e.Category)  // Ensure Category data is loaded
       .Where(e => e.CategoryId == categoryId) // Filter by Category
       .OrderByDescending(e => e.Date) // Sort by Date (latest first)
       .ToList();
        }

        public Dictionary<string, decimal> GetMonthlyReport()
        {
            return _context.Expenses
                    .GroupBy(e => new { Year = e.Date.Year, Month = e.Date.Month }) // Group by Year & Month
        .Select(g => new MonthlyExpenseReport
        {
            Year = g.Key.Year,
            Month = g.Key.Month,
            TotalAmount = g.Sum(e => e.Amount), // Sum the expenses
            ExpenseCount = g.Count() // Count number of expenses
        })
        .OrderByDescending(g => g.Year).ThenByDescending(g => g.Month) // Order by latest
        .ToList();

        }

        public void Update(Expense expense)
        {
            _context.Entry(expense).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        

        
    }
}
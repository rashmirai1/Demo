using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseTracker.Models;
using System.Data.Entity;

namespace ExpenseTracker.Data
{
    public class ExpenseDBContext :DbContext
    {
        public ExpenseDBContext() : base("ExpenseDBConnection") { }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
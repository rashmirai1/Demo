using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseTracker.Data;
using ExpenseTracker.Interface;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExpenseDBContext _context;

        public CategoryRepository(ExpenseDBContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll() => _context.Categories.ToList();
        

        public Category GetById(int id) => _context.Categories.Find(id);
        
    }
}
using ExpenseTracker.Interface;
using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ExpenseController(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository)
        {
            _expenseRepository = expenseRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: Expense
        public ActionResult Index()
        {
            var expenses = _expenseRepository.GetAll();
            return View(expenses);
        }

        // GET: Expense/Create
        public ActionResult Create()
        {
            ViewBag.Categories = _categoryRepository.GetAll().ToList();
            return View();
        }

        // POST: Expense/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _expenseRepository.Add(expense);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryRepository.GetAll().ToList();
            return View(expense);
        }

        // GET: Expense/Edit/5
        public ActionResult Edit(int id)
        {
            var expense = _expenseRepository.GetById(id);
            if (expense == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = _categoryRepository.GetAll().ToList();
            return View(expense);
        }

        // POST: Expense/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _expenseRepository.Update(expense);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryRepository.GetAll().ToList();
            return View(expense);
        }

        // GET: Expense/Delete/5
        public ActionResult Delete(int id)
        {
            var expense = _expenseRepository.GetById(id);
            if (expense == null)
            {
                return HttpNotFound();
            }

            return View(expense);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _expenseRepository.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Expense/Report
        public ActionResult Report()
        {
            var reportData = _expenseRepository.GetMonthlyReport();
            return Json(reportData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowByCategory(int? categoryId)
        {
            var expenses = _expenseRepository.GetAll()
                       .Include(e => e.Category)  // Ensure Category is loaded
                      .AsNoTracking()            // Prevent proxy objects
                      .Where(e => !categoryId.HasValue || e.CategoryId == categoryId)
                     .ToList();
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "Id", "Name", categoryId);
            return View(expenses);
        }



    }
}
namespace ExpenseTracker.Migrations
{
    using ExpenseTracker.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExpenseTracker.Data.ExpenseDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExpenseTracker.Data.ExpenseDBContext context)
        {
            context.Categories.AddOrUpdate(
            c => c.Id,
            new Category { Id = 1, Name = "Food" },
            new Category { Id = 2, Name = "Traveling" },
            new Category { Id = 3, Name = "Personal" },
            new Category { Id = 4, Name = "Entertainment" });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

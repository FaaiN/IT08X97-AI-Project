using agent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dieticianAI
{
    class DietDbContext: DbContext
    {
        public DbSet<FoodItem> FoodItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=DieticianDB;Trusted_Connection=True;");
        }
    }
}

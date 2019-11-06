using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstEFSampleApp.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> context) : base(context)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source = .\SQLEXPRESS;initial catalog = AnotherDB;integrated security =True;MultipleActiveResultSets=True;");
            }
        }
        public DbSet<Customer> Customers { get; set; }
    }
}

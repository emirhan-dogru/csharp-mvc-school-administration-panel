using MvcCrudProje.Models.Entities;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MvcCrudProje.Models.Context
{
    public class CrudDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public CrudDbContext()
        {
            Database.Connection.ConnectionString = "Server=EMIRHAN;Database=School;Trusted_Connection=True;";
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Worker> Worker { get; set; }
    }
}
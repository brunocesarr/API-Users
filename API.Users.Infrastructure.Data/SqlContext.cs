using API.Users.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace API.Users.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(){}

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("createdAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("createdAt").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("createdAt").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}

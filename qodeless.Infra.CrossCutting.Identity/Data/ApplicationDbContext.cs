using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using qodeless.domain.Entities;
using qodeless.Infra.CrossCutting.Identity.Entities;

namespace qodeless.Infra.CrossCutting.Identity.Data
{
    public interface IAppDbContext
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IAppDbContext
    {
        public DbSet<Account> Accounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new Account(Guid.Empty).Configure(modelBuilder.Entity<Account>().ToTable("Account"));


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext() { }
    }
}

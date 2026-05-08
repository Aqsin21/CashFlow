using CashFlow.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CashFlow.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Account>()
                .Property(a => a.Balance)
                .HasColumnType("decimal(18,2)");
           
            builder.Entity<Transaction>()
                 .HasOne(t => t.Category)
                 .WithMany(c => c.Transactions)
                 .HasForeignKey(t => t.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}

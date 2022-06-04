using BalanceAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalanceAPI.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }

       
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BalanceAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.AccountId);
                entity.Property(a => a.Name).IsRequired();
            });
           
            builder.Entity<Operation>(entity =>
            {
                entity.HasKey(o => o.OperationId);
                entity.Property(o => o.Value).IsRequired();
                entity.Property(o => o.DateOfOperation).IsRequired();
                entity.Property(o => o.AccountId).IsRequired();
            }
            );

            builder.Entity<Operation>().HasOne<Account>(o => o.Account).WithMany(a => a.Operations).HasForeignKey(a => a.OperationId);

            builder.Entity<User>(entity => {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(25);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(25);
                
                });

            builder.Entity<User>().HasMany<Account>(u => u.Accounts).WithOne(a => a.User).HasForeignKey(a => a.UserId);
        }
    }
}

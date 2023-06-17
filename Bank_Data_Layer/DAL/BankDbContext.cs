using Bank_Data_Layer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bank_Data_Layer.DAL
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CardType>()
            //    .HasOne<Bank>()
            //    .WithMany(c => c.CardTypes)
            //    .HasForeignKey(c => c.BankId);

            //modelBuilder.Entity<Order>()
            //    .HasOne<Customer>()
            //    .WithMany()
            //    .HasForeignKey(c => c.CustomerId);

            //modelBuilder.Entity<Order>()
            //.HasOne<CardType>()
            //.WithMany()
            //.HasForeignKey(c => c.CardTypeId);

            //modelBuilder.Entity<CardUser>()
            //    .HasOne<Customer>()
            //    .WithMany()
            //    .HasForeignKey(c => c.CustomerId);

            //modelBuilder.Entity<CardUser>()
            //    .HasOne<CardType>()
            //    .WithMany()
            //    .HasForeignKey(c => c.CardTypeId);


        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CardUser> CardUsers { get; set; }

    }
}

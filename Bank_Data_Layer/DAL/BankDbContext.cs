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

            modelBuilder.Entity<CustomerRole>()
                .HasKey(cr => new { cr.CustomerId, cr.RoleId });

            modelBuilder.Entity<CustomerRole>()
                .HasOne(cc => cc.Customer)
                .WithMany(c => c.CustomerRoles)
                .HasForeignKey(cc => cc.CustomerId);

            modelBuilder.Entity<CustomerRole>()
                .HasOne(cc => cc.Role)
                .WithMany(c => c.CustomerRoles)
                .HasForeignKey(cc => cc.RoleId);


            modelBuilder.Entity<Bank>()
                .HasData(new Bank()
                {
                    Id = 1,
                    Name = "Kapital Bank"
                });

            modelBuilder.Entity<Role>()
                .HasData(new Role()
                {
                    Id = 1,
                    RoleName = "Admin"
                });
            modelBuilder.Entity<Role>()
                .HasData(new Role()
                {
                    Id = 2,
                    RoleName = "User"
                });

        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CardUser> CardUsers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<CustomerRole> CustomersRoles { get; set; }

    }
}

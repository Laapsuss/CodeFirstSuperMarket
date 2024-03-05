using CodeFirstSupermarket.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSuperMarket.MODEL
{
    public class SUPERMARKETContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=SUPERMARKET;Uid=root;Pwd=\"\"");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasKey(p => new { p.CustomerNumber, p.CheckNumber });

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Customer)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.CustomerNumber);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductCode);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductLine)
                .WithMany(pl => pl.Products)
                .HasForeignKey(p => p.productLine);

            modelBuilder.Entity<ProductLine>()
                .HasKey(pl => pl.productLine);

            modelBuilder.Entity<ProductLine>()
                .HasMany(pl => pl.Products)
                .WithOne(p => p.ProductLine)
                .HasForeignKey(p => p.productLine);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderNumber, od.ProductCode });

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderNumber);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductCode);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerNumber);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.SalesRepEmployee)
                .WithMany(e => e.Customers)
                .HasForeignKey(c => c.SalesRepEmployeeNumber);

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
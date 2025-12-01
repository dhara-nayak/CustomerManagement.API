using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Customer>(builder =>
            {
                builder.HasKey(c => c.Id);
                builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
                builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
                builder.Property(c => c.Email).HasMaxLength(50).IsRequired();
                builder.Property(c => c.Phone).HasMaxLength(20).IsRequired();
                builder.Property(c => c.Address).HasMaxLength(50).IsRequired(false);

            });
            //Many Order <-> OneCustomer
            modelBuilder.Entity<Order>(b =>
            {
                b.HasKey(o => o.Id); //PrimaryKey
                b.HasOne(o => o.Customer)//Each order belongs to one customer
                .WithMany()//Custo,er can have many oirders
                .HasForeignKey(o => o.CustomerId)//fk
                .OnDelete(DeleteBehavior.Cascade); // if Customer deletes -> order deleted
            });

            //Many OrderItem <-> One Order
            modelBuilder.Entity<OrderItem>(b =>
            {
                b.HasKey(oi => oi.Id); //primary key

                b.HasOne(oi => oi.Order) //each orderItem belomgs to one order
                .WithMany(o => o.Items) //one order has many orderitems
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade); //if order deletes - items deleted 

               // One Product -> Many OrderItem
                b.HasOne(oi => oi.Product)//Each product item linked to one product
                .WithMany()// product have amny OrderItems
                .HasForeignKey(oi => oi.ProductId) //FK
                .OnDelete(DeleteBehavior.Restrict); // Restrict - can't delete product if it's in use
            });

        }

    }
}

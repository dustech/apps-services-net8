using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Models;

public partial class NorthwindDb : DbContext
{
    public NorthwindDb()
    {
    }

    public NorthwindDb(DbContextOptions<NorthwindDb> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Customercustomerdemo> Customercustomerdemos { get; set; }

    public virtual DbSet<Customerdemographic> Customerdemographics { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employeeterritory> Employeeterritories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<ShippersTmp> ShippersTmps { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Territory> Territories { get; set; }

    public virtual DbSet<Usstate> Usstates { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("pk_categories");

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("pk_customers");

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Customercustomerdemo>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.CustomerTypeId }).HasName("pk_customercustomerdemo");
        });

        modelBuilder.Entity<Customerdemographic>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeId).HasName("pk_customerdemographics");

            entity.Property(e => e.CustomerTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("pk_employees");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Employeeterritory>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.TerritoryId }).HasName("pk_employeeterritories");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("pk_orders");

            entity.Property(e => e.OrderId).ValueGeneratedNever();
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("pk_order_details");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("pk_products");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("pk_region");

            entity.Property(e => e.RegionId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(e => e.ShipperId).HasName("pk_shippers");

            entity.Property(e => e.ShipperId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ShippersTmp>(entity =>
        {
            entity.HasKey(e => e.ShipperId).HasName("pk_shippers_tmp");

            entity.Property(e => e.ShipperId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("pk_suppliers");

            entity.Property(e => e.SupplierId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Territory>(entity =>
        {
            entity.HasKey(e => e.TerritoryId).HasName("pk_territories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

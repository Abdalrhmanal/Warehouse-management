using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class AamdbMangmentContext : DbContext
{
    public AamdbMangmentContext()
    {
    }

    public AamdbMangmentContext(DbContextOptions<AamdbMangmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BuyOrder> BuyOrders { get; set; }

    public virtual DbSet<BuyOrderDetail> BuyOrderDetails { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Costumer> Costumers { get; set; }

    public virtual DbSet<Emplyee> Emplyees { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SellOrder> SellOrders { get; set; }

    public virtual DbSet<SellOrderDetail> SellOrderDetails { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-VIT25OV\\SQLEXPRESS;Initial Catalog=AAMDbMangment;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BuyOrder>(entity =>
        {
            entity.Property(e => e.OrderDate).HasMaxLength(50);
        });

        modelBuilder.Entity<BuyOrderDetail>(entity =>
        {
            entity.Property(e => e.BorderId).HasColumnName("BOrderId");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.CityName).HasMaxLength(50);
        });

        modelBuilder.Entity<Costumer>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(50)
                .HasColumnName("Number_phone");
        });

        modelBuilder.Entity<Emplyee>(entity =>
        {
            entity.Property(e => e.Father).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(50)
                .HasColumnName("Number_phone");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.CountInStock).HasColumnName("Count_in_Stock");
            entity.Property(e => e.ProductName).HasMaxLength(50);
        });

        modelBuilder.Entity<SellOrder>(entity =>
        {
            entity.Property(e => e.OrderDate).HasMaxLength(50);
        });

        modelBuilder.Entity<SellOrderDetail>(entity =>
        {
            entity.Property(e => e.ItemTotal).HasColumnType("date");
            entity.Property(e => e.SorderId).HasColumnName("SOrderId");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(50)
                .HasColumnName("Number_phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

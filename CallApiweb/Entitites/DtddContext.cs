using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CallApiweb.Entitites;

public partial class DtddContext : DbContext
{
    public DtddContext()
    {
    }

    public DtddContext(DbContextOptions<DtddContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TIEUPHU\\TIEUPHU;Initial Catalog=DTDD;Integrated Security=True;Encrypt=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("brand");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("product");

            entity.Property(e => e.Id)
                .HasComment("1: SẢN PHẨM MỚI, 2: SẢN PHẨM HOT, 3: SẢN PHẨM KHUYẾN MÃI, 4: PHỤ KIỆN")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

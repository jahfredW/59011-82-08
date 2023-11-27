using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using nppApplication.Models.Data;

namespace nppApplication.Models;

public partial class nppContext : DbContext
{
    public nppContext()
    {
    }

    public nppContext(DbContextOptions<nppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<DoctrineMigrationVersion> DoctrineMigrationVersions { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderLine> OrderLines { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("address");

            entity.HasIndex(e => e.UserId, "IDX_D4E6F81A76ED395");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Address1)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .HasColumnName("company");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .HasColumnName("country");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Postal)
                .HasMaxLength(255)
                .HasColumnName("postal");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_D4E6F81A76ED395");
        });

        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("album");

            entity.HasIndex(e => e.CategoryId, "IDX_39986E4312469DE2");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("category_id");
            entity.Property(e => e.CoverPicture)
                .HasMaxLength(255)
                .HasColumnName("cover_picture");
            entity.Property(e => e.CreatedAt)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Morning).HasColumnName("morning");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.Albums)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_39986E4312469DE2");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("director");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<DoctrineMigrationVersion>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PRIMARY");

            entity.ToTable("doctrine_migration_versions");

            entity.Property(e => e.Version)
                .HasMaxLength(191)
                .HasColumnName("version");
            entity.Property(e => e.ExecutedAt)
                .HasColumnType("datetime")
                .HasColumnName("executed_at");
            entity.Property(e => e.ExecutionTime)
                .HasColumnType("int(11)")
                .HasColumnName("execution_time");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("film");

            entity.HasIndex(e => e.DirectorId, "IDX_8244BE22899FB366");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DirectorId)
                .HasColumnType("int(11)")
                .HasColumnName("director_id");
            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .HasColumnName("photo");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Director).WithMany(p => p.Films)
                .HasForeignKey(d => d.DirectorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_8244BE22899FB366");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("order");

            entity.HasIndex(e => e.UserId, "IDX_F5299398A76ED395");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.StripeId)
                .HasMaxLength(255)
                .HasColumnName("stripe_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_F5299398A76ED395");
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("order_line");

            entity.HasIndex(e => e.OrderedId, "IDX_9CE58EE1AA60395A");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.OrderedId)
                .HasColumnType("int(11)")
                .HasColumnName("ordered_id");
            entity.Property(e => e.PictureId)
                .HasColumnType("int(11)")
                .HasColumnName("picture_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Ordered).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OrderedId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_9CE58EE1AA60395A");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("photo");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Path)
                .HasMaxLength(255)
                .HasColumnName("path");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("picture");

            entity.HasIndex(e => e.AlbumId, "IDX_16DB4F891137ABCF");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AlbumId)
                .HasColumnType("int(11)")
                .HasColumnName("album_id");
            entity.Property(e => e.CreatedAt)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("file_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .HasColumnName("thumbnail");

            entity.HasOne(d => d.Album).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.AlbumId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_16DB4F891137ABCF");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "UNIQ_8D93D649E7927C74").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(180)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Pseudo)
                .HasMaxLength(255)
                .HasColumnName("pseudo");
            entity.Property(e => e.Roles)
                .HasComment("(DC2Type:json)")
                .HasColumnName("roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

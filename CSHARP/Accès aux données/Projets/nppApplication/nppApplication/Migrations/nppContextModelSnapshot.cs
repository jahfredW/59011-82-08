﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nppApplication.Models;

#nullable disable

namespace nppApplication.Migrations
{
    [DbContext(typeof(nppContext))]
    partial class nppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("nppApplication.Models.Data.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("city");

                    b.Property<string>("Company")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("company");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("country");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("lastname");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("phone");

                    b.Property<string>("Postal")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("postal");

                    b.Property<int?>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserId" }, "IDX_D4E6F81A76ED395");

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("nppApplication.Models.Data.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int(11)")
                        .HasColumnName("category_id");

                    b.Property<string>("CoverPicture")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("cover_picture");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasComment("(DC2Type:datetime_immutable)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<bool>("Morning")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("morning");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CategoryId" }, "IDX_39986E4312469DE2");

                    b.ToTable("album", (string)null);
                });

            modelBuilder.Entity("nppApplication.Models.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasComment("(DC2Type:datetime_immutable)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at")
                        .HasComment("(DC2Type:datetime_immutable)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("nppApplication.Models.Data.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("director", (string)null);
                });

            modelBuilder.Entity("nppApplication.Models.Data.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ReductionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReductionId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("nppApplication.Models.Data.DoctrineMigrationVersion", b =>
                {
                    b.Property<string>("Version")
                        .HasMaxLength(191)
                        .HasColumnType("varchar(191)")
                        .HasColumnName("version");

                    b.Property<DateTime?>("ExecutedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("executed_at");

                    b.Property<int?>("ExecutionTime")
                        .HasColumnType("int(11)")
                        .HasColumnName("execution_time");

                    b.HasKey("Version")
                        .HasName("PRIMARY");

                    b.ToTable("doctrine_migration_versions", (string)null);
                });

            modelBuilder.Entity("nppApplication.Models.Data.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<int?>("DirectorId")
                        .HasColumnType("int(11)")
                        .HasColumnName("director_id");

                    b.Property<string>("Photo")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("photo");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DirectorId" }, "IDX_8244BE22899FB366");

                    b.ToTable("film", (string)null);
                });

            modelBuilder.Entity("nppApplication.Models.Data.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasComment("(DC2Type:datetime_immutable)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<int?>("ReductionId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("status");

                    b.Property<string>("StripeId")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("stripe_id");

                    b.Property<int?>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("ReductionId");

                    b.HasIndex(new[] { "UserId" }, "IDX_F5299398A76ED395");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("nppApplication.Models.Data.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("OrderedId")
                        .HasColumnType("int(11)")
                        .HasColumnName("ordered_id");

                    b.Property<int>("PictureId")
                        .HasColumnType("int(11)")
                        .HasColumnName("picture_id");

                    b.Property<double>("Price")
                        .HasColumnType("double")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int(11)")
                        .HasColumnName("quantity");

                    b.Property<double>("Total")
                        .HasColumnType("double")
                        .HasColumnName("total");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "OrderedId" }, "IDX_9CE58EE1AA60395A");

                    b.ToTable("order_line", (string)null);
                });

            modelBuilder.Entity("nppApplication.Models.Data.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasComment("(DC2Type:datetime_immutable)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("path");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("photo", (string)null);
                });

            modelBuilder.Entity("nppApplication.Models.Data.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int(11)")
                        .HasColumnName("album_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasComment("(DC2Type:datetime_immutable)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("file_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("thumbnail");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "AlbumId" }, "IDX_16DB4F891137ABCF");

                    b.ToTable("picture", (string)null);
                });

            modelBuilder.Entity("nppApplication.Models.Data.Reduction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Reductions");
                });

            modelBuilder.Entity("nppApplication.Models.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("varchar(180)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("pseudo");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("roles")
                        .HasComment("(DC2Type:json)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Email" }, "UNIQ_8D93D649E7927C74")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("nppApplication.Models.Data.Address", b =>
                {
                    b.HasOne("nppApplication.Models.Data.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_D4E6F81A76ED395");

                    b.Navigation("User");
                });

            modelBuilder.Entity("nppApplication.Models.Data.Album", b =>
                {
                    b.HasOne("nppApplication.Models.Data.Category", "Category")
                        .WithMany("Albums")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_39986E4312469DE2");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("nppApplication.Models.Data.Discount", b =>
                {
                    b.HasOne("nppApplication.Models.Data.Reduction", null)
                        .WithMany("Discounts")
                        .HasForeignKey("ReductionId");
                });

            modelBuilder.Entity("nppApplication.Models.Data.Film", b =>
                {
                    b.HasOne("nppApplication.Models.Data.Director", "Director")
                        .WithMany("Films")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_8244BE22899FB366");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("nppApplication.Models.Data.Order", b =>
                {
                    b.HasOne("nppApplication.Models.Data.Reduction", null)
                        .WithMany("Orders")
                        .HasForeignKey("ReductionId");

                    b.HasOne("nppApplication.Models.Data.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_F5299398A76ED395");

                    b.Navigation("User");
                });

            modelBuilder.Entity("nppApplication.Models.Data.OrderLine", b =>
                {
                    b.HasOne("nppApplication.Models.Data.Order", "Ordered")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderedId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_9CE58EE1AA60395A");

                    b.Navigation("Ordered");
                });

            modelBuilder.Entity("nppApplication.Models.Data.Picture", b =>
                {
                    b.HasOne("nppApplication.Models.Data.Album", "Album")
                        .WithMany("Pictures")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_16DB4F891137ABCF");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("nppApplication.Models.Data.Album", b =>
                {
                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("nppApplication.Models.Data.Category", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("nppApplication.Models.Data.Director", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("nppApplication.Models.Data.Order", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("nppApplication.Models.Data.Reduction", b =>
                {
                    b.Navigation("Discounts");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("nppApplication.Models.Data.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

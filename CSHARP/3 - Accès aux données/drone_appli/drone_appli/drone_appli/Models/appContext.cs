using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using drone_appli.Models.Data;

namespace drone_appli.Models;

public partial class appContext : DbContext
{
    public appContext()
    {
    }

    public appContext(DbContextOptions<appContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Drone> Drones { get; set; }

    public virtual DbSet<Pilote> Pilotes { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<TypeDrone> TypeDrones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Drone>(entity =>
        {
            entity.HasKey(e => e.IdDrone).HasName("PRIMARY");

            entity.ToTable("drone");

            entity.HasIndex(e => e.IdTypeDrone, "FK_DRONE_TYPE");

            entity.Property(e => e.IdDrone).HasColumnName("Id_Drone");
            entity.Property(e => e.IdTypeDrone).HasColumnName("Id_Type_Drone");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prix)
                .HasPrecision(15)
                .HasColumnName("prix");

            entity.HasOne(d => d.IdTypeDroneNavigation).WithMany(p => p.Drones)
                .HasForeignKey(d => d.IdTypeDrone)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DRONE_TYPE");
        });

        modelBuilder.Entity<Pilote>(entity =>
        {
            entity.HasKey(e => e.IdPilote).HasName("PRIMARY");

            entity.ToTable("pilote");

            entity.Property(e => e.IdPilote).HasColumnName("Id_Pilote");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .HasColumnName("prenom");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => new { e.IdDrone, e.IdPilote }).HasName("PRIMARY");

            entity.ToTable("session");

            entity.HasIndex(e => e.IdPilote, "FK_SESSION_PILOTE");

            entity.HasIndex(e => e.IdSession, "Id_session").IsUnique();

            entity.Property(e => e.IdDrone).HasColumnName("Id_Drone");
            entity.Property(e => e.IdPilote).HasColumnName("Id_Pilote");
            entity.Property(e => e.DateSession)
                .HasColumnType("date")
                .HasColumnName("Date_session");
            entity.Property(e => e.IdSession).HasColumnName("Id_session");

            entity.HasOne(d => d.IdDroneNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.IdDrone)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SESSION_DRONE");

            entity.HasOne(d => d.IdPiloteNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.IdPilote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SESSION_PILOTE");
        });

        modelBuilder.Entity<TypeDrone>(entity =>
        {
            entity.HasKey(e => e.IdTypeDrone).HasName("PRIMARY");

            entity.ToTable("type_drone");

            entity.Property(e => e.IdTypeDrone).HasColumnName("Id_Type_Drone");
            entity.Property(e => e.Intitule)
                .HasMaxLength(50)
                .HasColumnName("intitule");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

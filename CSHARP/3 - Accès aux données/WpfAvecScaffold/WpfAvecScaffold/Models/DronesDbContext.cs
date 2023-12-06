using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WpfAvecScaffold.Models.Data;

namespace WpfAvecScaffold.Models;

public partial class DronesDbContext : DbContext
{
    public DronesDbContext()
    {
    }

    public DronesDbContext(DbContextOptions<DronesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Drone> Drones { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Pilote> Pilotes { get; set; }

    public virtual DbSet<Session> ListeSessions { get; set; }

    public virtual DbSet<TypeDrone> TypeDrones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost;port=3306;database=drone_session;user=root;ssl mode=none");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Drone>(entity =>
        {
            entity.HasKey(e => e.IdDrone).HasName("PRIMARY");

            entity.ToTable("drone");

            entity.HasIndex(e => e.IdTypeDrone, "FK_DRONE_TYPE");

            entity.Property(e => e.IdDrone)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Drone");
            entity.Property(e => e.IdTypeDrone)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Type_Drone");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prix)
                .HasPrecision(15)
                .HasColumnName("prix");

            entity.HasOne(d => d.LeTypeDeDrone).WithMany(p => p.Drones)
                .HasForeignKey(d => d.IdTypeDrone)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_DRONE_TYPE");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Pilote>(entity =>
        {
            entity.HasKey(e => e.IdPilote).HasName("PRIMARY");

            entity.ToTable("pilote");

            entity.Property(e => e.IdPilote)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Pilote");
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

            entity.Property(e => e.IdDrone)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Drone");
            entity.Property(e => e.IdPilote)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Pilote");
            entity.Property(e => e.DateSession)
                .HasColumnType("date")
                .HasColumnName("Date_session");
            entity.Property(e => e.IdSession)
                .HasColumnType("int(11)")
                .HasColumnName("Id_session");

            entity.HasOne(d => d.LeDrone).WithMany(p => p.ListeSessions)
                .HasForeignKey(d => d.IdDrone)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_SESSION_DRONE");

            entity.HasOne(d => d.LePilote).WithMany(p => p.ListeSessions)
                .HasForeignKey(d => d.IdPilote)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_SESSION_PILOTE");
        });

        modelBuilder.Entity<TypeDrone>(entity =>
        {
            entity.HasKey(e => e.IdTypeDrone).HasName("PRIMARY");

            entity.ToTable("type_drone");

            entity.Property(e => e.IdTypeDrone)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Type_Drone");
            entity.Property(e => e.Intitule)
                .HasMaxLength(50)
                .HasColumnName("intitule");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ExerciceAPI.Models.Data;

public partial class ApiDbContext : DbContext
{
 
    public ApiDbContext()
    {
        
    }

    public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
    {
    }

    public virtual DbSet<Cadeau> Cadeaus { get; set; }


    public virtual DbSet<Enfant> Enfants { get; set; }

    public virtual DbSet<Gerer> Gerers { get; set; }

    public virtual DbSet<Lutin> Lutins { get; set; }

    public virtual DbSet<Renne> Rennes { get; set; }

    public virtual DbSet<Tournee> Tournees { get; set; }

    public virtual DbSet<Traineau> Traineaus { get; set; }

    public virtual DbSet<Voeux> Voeuxes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = ("name=Default");

        optionsBuilder.UseMySQL(connectionString);
    }
         

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cadeau>(entity =>
        {
            entity.HasKey(e => e.IdCadeau).HasName("PRIMARY");

            entity.ToTable("cadeau");

            entity.HasIndex(e => e.IdTraineau, "FK_CADEAU");

            entity.Property(e => e.IdCadeau)
                .HasColumnType("int(11)")
                .HasColumnName("Id_CADEAU");
            entity.Property(e => e.DesignationCadeau)
                .HasMaxLength(50)
                .HasColumnName("designation_cadeau");
            entity.Property(e => e.IdTraineau)
                .HasColumnType("int(11)")
                .HasColumnName("Id_TRAINEAU");

            entity.HasOne(d => d.IdTraineauNavigation).WithMany(p => p.Cadeaus)
                .HasForeignKey(d => d.IdTraineau)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CADEAU");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Enfant>(entity =>
        {
            entity.HasKey(e => e.IdEnfant).HasName("PRIMARY");

            entity.ToTable("enfant");

            entity.Property(e => e.IdEnfant)
                .HasColumnType("int(11)")
                .HasColumnName("Id_ENFANT");
            entity.Property(e => e.AdresseEnfant)
                .HasMaxLength(255)
                .HasColumnName("adresse_enfant");
            entity.Property(e => e.NomEnfant)
                .HasMaxLength(25)
                .HasColumnName("nom_enfant");
            entity.Property(e => e.PrenomEnfant)
                .HasMaxLength(25)
                .HasColumnName("prenom_enfant");
            entity.Property(e => e.SagesseEnfant)
                .HasPrecision(15)
                .HasColumnName("sagesse_enfant");
            entity.Property(e => e.SexeEnfant).HasColumnName("sexe_enfant");
        });

        modelBuilder.Entity<Gerer>(entity =>
        {
            entity.HasKey(e => new { e.IdLutin, e.IdTraineau }).HasName("PRIMARY");

            entity.ToTable("gerer");

            entity.HasIndex(e => e.IdTraineau, "FK_TRAINEAU_GERER");

            entity.Property(e => e.IdLutin)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Lutin");
            entity.Property(e => e.IdTraineau)
                .HasColumnType("int(11)")
                .HasColumnName("Id_TRAINEAU");
            entity.Property(e => e.DatePriseEnCompte)
                .HasMaxLength(50)
                .HasColumnName("date_prise_en_compte");

            entity.HasOne(d => d.IdLutinNavigation).WithMany(p => p.Gerers)
                .HasForeignKey(d => d.IdLutin)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_LUTIN_GERER");

            entity.HasOne(d => d.IdTraineauNavigation).WithMany(p => p.Gerers)
                .HasForeignKey(d => d.IdTraineau)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TRAINEAU_GERER");
        });

        modelBuilder.Entity<Lutin>(entity =>
        {
            entity.HasKey(e => e.IdLutin).HasName("PRIMARY");

            entity.ToTable("lutin");

            entity.Property(e => e.IdLutin)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Lutin");
            entity.Property(e => e.NomLutin)
                .HasMaxLength(25)
                .HasColumnName("nom_lutin");
            entity.Property(e => e.PrenomLutin)
                .HasMaxLength(25)
                .HasColumnName("prenom_lutin");
        });

        modelBuilder.Entity<Renne>(entity =>
        {
            entity.HasKey(e => e.NomRenne).HasName("PRIMARY");

            entity.ToTable("renne");

            entity.HasIndex(e => e.IdTraineau, "FK_TRAINEAU_RENNE");

            entity.Property(e => e.NomRenne)
                .HasMaxLength(50)
                .HasColumnName("nom_renne");
            entity.Property(e => e.DateDeNaissance)
                .HasColumnType("date")
                .HasColumnName("date_de_naissance");
            entity.Property(e => e.IdTraineau)
                .HasColumnType("int(11)")
                .HasColumnName("Id_TRAINEAU");
            entity.Property(e => e.SexeRenne).HasColumnName("sexe_renne");

            entity.HasOne(d => d.IdTraineauNavigation).WithMany(p => p.Rennes)
                .HasForeignKey(d => d.IdTraineau)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TRAINEAU_RENNE");
        });

        modelBuilder.Entity<Tournee>(entity =>
        {
            entity.HasKey(e => e.IdTournee).HasName("PRIMARY");

            entity.ToTable("tournee");

            entity.HasIndex(e => e.IdLutin, "FK_LUTIN_TOURNEE");

            entity.HasIndex(e => e.IdTraineau, "FK_TRAINEAU_TOURNEE");

            entity.Property(e => e.IdTournee)
                .HasColumnType("int(11)")
                .HasColumnName("Id_TOURNEE");
            entity.Property(e => e.DateDepart)
                .HasColumnType("date")
                .HasColumnName("date_depart");
            entity.Property(e => e.IdLutin)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Lutin");
            entity.Property(e => e.IdTraineau)
                .HasColumnType("int(11)")
                .HasColumnName("Id_TRAINEAU");

            entity.HasOne(d => d.IdLutinNavigation).WithMany(p => p.Tournees)
                .HasForeignKey(d => d.IdLutin)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_LUTIN_TOURNEE");

            entity.HasOne(d => d.IdTraineauNavigation).WithMany(p => p.Tournees)
                .HasForeignKey(d => d.IdTraineau)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TRAINEAU_TOURNEE");
        });

        modelBuilder.Entity<Traineau>(entity =>
        {
            entity.HasKey(e => e.IdTraineau).HasName("PRIMARY");

            entity.ToTable("traineau");

            entity.Property(e => e.IdTraineau)
                .HasColumnType("int(11)")
                .HasColumnName("Id_TRAINEAU");
            entity.Property(e => e.DateMiseEnService)
                .HasColumnType("date")
                .HasColumnName("date_mise_en_service");
            entity.Property(e => e.DateRevision)
                .HasColumnType("date")
                .HasColumnName("date_revision");
            entity.Property(e => e.TailleTraineau)
                .HasPrecision(15)
                .HasColumnName("taille_traineau");
        });

        modelBuilder.Entity<Voeux>(entity =>
        {
            entity.HasKey(e => e.IdVoeu).HasName("PRIMARY");

            entity.ToTable("voeux");

            entity.HasIndex(e => e.IdCadeau, "FK_CADEAU_VOEUX");

            entity.HasIndex(e => e.IdEnfant, "FK_ENFANT_VOEUX");

            entity.Property(e => e.IdVoeu)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Voeu");
            entity.Property(e => e.EstExaucé)
                .HasMaxLength(50)
                .HasColumnName("est_exaucé");
            entity.Property(e => e.IdCadeau)
                .HasColumnType("int(11)")
                .HasColumnName("Id_CADEAU");
            entity.Property(e => e.IdEnfant)
                .HasColumnType("int(11)")
                .HasColumnName("Id_ENFANT");

            entity.HasOne(d => d.IdCadeauNavigation).WithMany(p => p.Voeuxes)
                .HasForeignKey(d => d.IdCadeau)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CADEAU_VOEUX");

            entity.HasOne(d => d.IdEnfantNavigation).WithMany(p => p.Voeuxes)
                .HasForeignKey(d => d.IdEnfant)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ENFANT_VOEUX");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

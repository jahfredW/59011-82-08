﻿// <auto-generated />
using System;
using ExerciceAPI.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExerciceAPI.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ExerciceAPI.Models.Data.Cadeau", b =>
                {
                    b.Property<int>("IdCadeau")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_CADEAU");

                    b.Property<int>("DesignationCadeau")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("designation_cadeau");

                    b.Property<int?>("IdTraineau")
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_TRAINEAU");

                    b.HasKey("IdCadeau")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdTraineau" }, "FK_CADEAU");

                    b.ToTable("cadeau", (string)null);
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Efmigrationshistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("MigrationId")
                        .HasName("PRIMARY");

                    b.ToTable("__efmigrationshistory", (string)null);
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Enfant", b =>
                {
                    b.Property<int>("IdEnfant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_ENFANT");

                    b.Property<string>("AdresseEnfant")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("adresse_enfant");

                    b.Property<string>("NomEnfant")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("nom_enfant");

                    b.Property<string>("PrenomEnfant")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("prenom_enfant");

                    b.Property<decimal?>("SagesseEnfant")
                        .HasPrecision(15)
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("sagesse_enfant");

                    b.Property<bool?>("SexeEnfant")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("sexe_enfant");

                    b.HasKey("IdEnfant")
                        .HasName("PRIMARY");

                    b.ToTable("enfant", (string)null);
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Gerer", b =>
                {
                    b.Property<int>("IdLutin")
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_Lutin");

                    b.Property<int>("IdTraineau")
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_TRAINEAU");

                    b.Property<string>("DatePriseEnCompte")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("date_prise_en_compte");

                    b.HasKey("IdLutin", "IdTraineau")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdTraineau" }, "FK_TRAINEAU_GERER");

                    b.ToTable("gerer", (string)null);
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Lutin", b =>
                {
                    b.Property<int>("IdLutin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_Lutin");

                    b.Property<string>("NomLutin")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("nom_lutin");

                    b.Property<string>("PrenomLutin")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("prenom_lutin");

                    b.HasKey("IdLutin")
                        .HasName("PRIMARY");

                    b.ToTable("lutin", (string)null);
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Renne", b =>
                {
                    b.Property<string>("NomRenne")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nom_renne");

                    b.Property<DateTime?>("DateDeNaissance")
                        .HasColumnType("date")
                        .HasColumnName("date_de_naissance");

                    b.Property<int?>("IdTraineau")
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_TRAINEAU");

                    b.Property<bool?>("SexeRenne")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("sexe_renne");

                    b.HasKey("NomRenne")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdTraineau" }, "FK_TRAINEAU_RENNE");

                    b.ToTable("renne", (string)null);
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Tournee", b =>
                {
                    b.Property<int>("IdTournee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_TOURNEE");

                    b.Property<DateTime?>("DateDepart")
                        .HasColumnType("date")
                        .HasColumnName("date_depart");

                    b.Property<int?>("IdLutin")
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_Lutin");

                    b.Property<int?>("IdTraineau")
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_TRAINEAU");

                    b.HasKey("IdTournee")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdLutin" }, "FK_LUTIN_TOURNEE");

                    b.HasIndex(new[] { "IdTraineau" }, "FK_TRAINEAU_TOURNEE");

                    b.ToTable("tournee", (string)null);
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Traineau", b =>
                {
                    b.Property<int>("IdTraineau")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_TRAINEAU");

                    b.Property<DateTime?>("DateMiseEnService")
                        .HasColumnType("date")
                        .HasColumnName("date_mise_en_service");

                    b.Property<DateTime?>("DateRevision")
                        .HasColumnType("date")
                        .HasColumnName("date_revision");

                    b.Property<decimal?>("TailleTraineau")
                        .HasPrecision(15)
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("taille_traineau");

                    b.HasKey("IdTraineau")
                        .HasName("PRIMARY");

                    b.ToTable("traineau", (string)null);
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Voeux", b =>
                {
                    b.Property<int>("IdVoeu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_Voeu");

                    b.Property<string>("EstExaucé")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("est_exaucé");

                    b.Property<int>("IdCadeau")
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_CADEAU");

                    b.Property<int?>("IdEnfant")
                        .HasColumnType("int(11)")
                        .HasColumnName("Id_ENFANT");

                    b.HasKey("IdVoeu")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCadeau" }, "FK_CADEAU_VOEUX");

                    b.HasIndex(new[] { "IdEnfant" }, "FK_ENFANT_VOEUX");

                    b.ToTable("voeux", (string)null);
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Cadeau", b =>
                {
                    b.HasOne("ExerciceAPI.Models.Data.Traineau", "IdTraineauNavigation")
                        .WithMany("Cadeaus")
                        .HasForeignKey("IdTraineau")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_CADEAU");

                    b.Navigation("IdTraineauNavigation");
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Gerer", b =>
                {
                    b.HasOne("ExerciceAPI.Models.Data.Lutin", "IdLutinNavigation")
                        .WithMany("Gerers")
                        .HasForeignKey("IdLutin")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_LUTIN_GERER");

                    b.HasOne("ExerciceAPI.Models.Data.Traineau", "IdTraineauNavigation")
                        .WithMany("Gerers")
                        .HasForeignKey("IdTraineau")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_TRAINEAU_GERER");

                    b.Navigation("IdLutinNavigation");

                    b.Navigation("IdTraineauNavigation");
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Renne", b =>
                {
                    b.HasOne("ExerciceAPI.Models.Data.Traineau", "IdTraineauNavigation")
                        .WithMany("Rennes")
                        .HasForeignKey("IdTraineau")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_TRAINEAU_RENNE");

                    b.Navigation("IdTraineauNavigation");
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Tournee", b =>
                {
                    b.HasOne("ExerciceAPI.Models.Data.Lutin", "IdLutinNavigation")
                        .WithMany("Tournees")
                        .HasForeignKey("IdLutin")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_LUTIN_TOURNEE");

                    b.HasOne("ExerciceAPI.Models.Data.Traineau", "IdTraineauNavigation")
                        .WithMany("Tournees")
                        .HasForeignKey("IdTraineau")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_TRAINEAU_TOURNEE");

                    b.Navigation("IdLutinNavigation");

                    b.Navigation("IdTraineauNavigation");
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Voeux", b =>
                {
                    b.HasOne("ExerciceAPI.Models.Data.Cadeau", "IdCadeauNavigation")
                        .WithMany("Voeuxes")
                        .HasForeignKey("IdCadeau")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_CADEAU_VOEUX");

                    b.HasOne("ExerciceAPI.Models.Data.Enfant", "IdEnfantNavigation")
                        .WithMany("Voeuxes")
                        .HasForeignKey("IdEnfant")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_ENFANT_VOEUX");

                    b.Navigation("IdCadeauNavigation");

                    b.Navigation("IdEnfantNavigation");
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Cadeau", b =>
                {
                    b.Navigation("Voeuxes");
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Enfant", b =>
                {
                    b.Navigation("Voeuxes");
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Lutin", b =>
                {
                    b.Navigation("Gerers");

                    b.Navigation("Tournees");
                });

            modelBuilder.Entity("ExerciceAPI.Models.Data.Traineau", b =>
                {
                    b.Navigation("Cadeaus");

                    b.Navigation("Gerers");

                    b.Navigation("Rennes");

                    b.Navigation("Tournees");
                });
#pragma warning restore 612, 618
        }
    }
}

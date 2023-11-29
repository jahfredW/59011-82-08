﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using drone_appli.Models;

#nullable disable

namespace drone_appli.Migrations
{
    [DbContext(typeof(appContext))]
    [Migration("20231129075846_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("drone_appli.Models.Data.Drone", b =>
                {
                    b.Property<int>("IdDrone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Drone");

                    b.Property<int>("IdTypeDrone")
                        .HasColumnType("int")
                        .HasColumnName("Id_Type_Drone");

                    b.Property<string>("Nom")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nom");

                    b.Property<decimal?>("Prix")
                        .HasPrecision(15)
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("prix");

                    b.HasKey("IdDrone")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdTypeDrone" }, "FK_DRONE_TYPE");

                    b.ToTable("drone", (string)null);
                });

            modelBuilder.Entity("drone_appli.Models.Data.Pilote", b =>
                {
                    b.Property<int>("IdPilote")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Pilote");

                    b.Property<string>("Nom")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nom");

                    b.Property<string>("Prenom")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("prenom");

                    b.HasKey("IdPilote")
                        .HasName("PRIMARY");

                    b.ToTable("pilote", (string)null);
                });

            modelBuilder.Entity("drone_appli.Models.Data.Session", b =>
                {
                    b.Property<int>("IdDrone")
                        .HasColumnType("int")
                        .HasColumnName("Id_Drone");

                    b.Property<int>("IdPilote")
                        .HasColumnType("int")
                        .HasColumnName("Id_Pilote");

                    b.Property<DateTime?>("DateSession")
                        .HasColumnType("date")
                        .HasColumnName("Date_session");

                    b.Property<int>("IdSession")
                        .HasColumnType("int")
                        .HasColumnName("Id_session");

                    b.HasKey("IdDrone", "IdPilote")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdPilote" }, "FK_SESSION_PILOTE");

                    b.HasIndex(new[] { "IdSession" }, "Id_session")
                        .IsUnique();

                    b.ToTable("session", (string)null);
                });

            modelBuilder.Entity("drone_appli.Models.Data.TypeDrone", b =>
                {
                    b.Property<int>("IdTypeDrone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Type_Drone");

                    b.Property<string>("Intitule")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("intitule");

                    b.HasKey("IdTypeDrone")
                        .HasName("PRIMARY");

                    b.ToTable("type_drone", (string)null);
                });

            modelBuilder.Entity("drone_appli.Models.Data.Drone", b =>
                {
                    b.HasOne("drone_appli.Models.Data.TypeDrone", "IdTypeDroneNavigation")
                        .WithMany("Drones")
                        .HasForeignKey("IdTypeDrone")
                        .IsRequired()
                        .HasConstraintName("FK_DRONE_TYPE");

                    b.Navigation("IdTypeDroneNavigation");
                });

            modelBuilder.Entity("drone_appli.Models.Data.Session", b =>
                {
                    b.HasOne("drone_appli.Models.Data.Drone", "IdDroneNavigation")
                        .WithMany("Sessions")
                        .HasForeignKey("IdDrone")
                        .IsRequired()
                        .HasConstraintName("FK_SESSION_DRONE");

                    b.HasOne("drone_appli.Models.Data.Pilote", "IdPiloteNavigation")
                        .WithMany("Sessions")
                        .HasForeignKey("IdPilote")
                        .IsRequired()
                        .HasConstraintName("FK_SESSION_PILOTE");

                    b.Navigation("IdDroneNavigation");

                    b.Navigation("IdPiloteNavigation");
                });

            modelBuilder.Entity("drone_appli.Models.Data.Drone", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("drone_appli.Models.Data.Pilote", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("drone_appli.Models.Data.TypeDrone", b =>
                {
                    b.Navigation("Drones");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Autoparc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Autoparc.Migrations
{
    [DbContext(typeof(VehiculeContext))]
    [Migration("20210319134516_fk-tache-user")]
    partial class fktacheuser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Autoparc.Models.Tache", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("arrivalDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("arrivalPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("departureDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("departurePoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("registrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("cin");

                    b.HasIndex("registrationNumber");

                    b.ToTable("taches");
                });

            modelBuilder.Entity("Autoparc.Models.User", b =>
                {
                    b.Property<string>("cin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("birthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cin");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Autoparc.Models.Vehicule", b =>
                {
                    b.Property<string>("registrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("kmPerLittre")
                        .HasColumnType("float");

                    b.Property<string>("mark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("reservoir")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("totalDistance")
                        .HasColumnType("bigint");

                    b.HasKey("registrationNumber");

                    b.ToTable("vehicules");
                });

            modelBuilder.Entity("Autoparc.Models.Tache", b =>
                {
                    b.HasOne("Autoparc.Models.User", "User")
                        .WithMany("taches")
                        .HasForeignKey("cin");

                    b.HasOne("Autoparc.Models.Vehicule", "Vehicule")
                        .WithMany()
                        .HasForeignKey("registrationNumber");

                    b.Navigation("User");

                    b.Navigation("Vehicule");
                });

            modelBuilder.Entity("Autoparc.Models.User", b =>
                {
                    b.Navigation("taches");
                });
#pragma warning restore 612, 618
        }
    }
}

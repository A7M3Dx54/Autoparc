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
    [Migration("20210428122052_New_tache_entretien_relation")]
    partial class New_tache_entretien_relation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Autoparc.Models.DriverLocationHistory", b =>
                {
                    b.Property<int>("idLocation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("longitude")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idLocation");

                    b.HasIndex("cin");

                    b.ToTable("driverLocationsHistory");
                });

            modelBuilder.Entity("Autoparc.Models.Entretien", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("cost")
                        .HasColumnType("real");

                    b.Property<string>("dateDebut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dateFin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idTask")
                        .HasColumnType("int");

                    b.Property<int>("idType")
                        .HasColumnType("int");

                    b.Property<string>("registrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("idTask");

                    b.HasIndex("idType");

                    b.HasIndex("registrationNumber");

                    b.ToTable("entretiens");
                });

            modelBuilder.Entity("Autoparc.Models.EntretienType", b =>
                {
                    b.Property<int>("idType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("period")
                        .HasColumnType("int");

                    b.HasKey("idType");

                    b.ToTable("entretienTypes");
                });

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

                    b.Property<bool>("isEntretien")
                        .HasColumnType("bit");

                    b.Property<string>("priority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("registrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usedCar")
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

            modelBuilder.Entity("Autoparc.Models.DriverLocationHistory", b =>
                {
                    b.HasOne("Autoparc.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("cin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Autoparc.Models.Entretien", b =>
                {
                    b.HasOne("Autoparc.Models.Tache", "Tache")
                        .WithMany()
                        .HasForeignKey("idTask")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autoparc.Models.EntretienType", "EntretienType")
                        .WithMany()
                        .HasForeignKey("idType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Autoparc.Models.Vehicule", "Vehicule")
                        .WithMany()
                        .HasForeignKey("registrationNumber");

                    b.Navigation("EntretienType");

                    b.Navigation("Tache");

                    b.Navigation("Vehicule");
                });

            modelBuilder.Entity("Autoparc.Models.Tache", b =>
                {
                    b.HasOne("Autoparc.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("cin");

                    b.HasOne("Autoparc.Models.Vehicule", "Vehicule")
                        .WithMany()
                        .HasForeignKey("registrationNumber");

                    b.Navigation("User");

                    b.Navigation("Vehicule");
                });
#pragma warning restore 612, 618
        }
    }
}

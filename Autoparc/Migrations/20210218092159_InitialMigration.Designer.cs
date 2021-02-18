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
    [Migration("20210218092159_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
#pragma warning restore 612, 618
        }
    }
}

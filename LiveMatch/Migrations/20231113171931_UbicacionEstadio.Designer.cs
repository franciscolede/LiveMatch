﻿// <auto-generated />
using System;
using LiveMatch.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiveMatch.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231113171931_UbicacionEstadio")]
    partial class UbicacionEstadio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LiveMatch.Models.CondicionPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.ToTable("CondicionPagos");
                });

            modelBuilder.Entity("LiveMatch.Models.Deporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Deporte");
                });

            modelBuilder.Entity("LiveMatch.Models.Estadio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estadio");
                });

            modelBuilder.Entity("LiveMatch.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DeporteRefId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("EstadioRefId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaEvento")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("ImagenEvento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Visitante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeporteRefId");

                    b.HasIndex("EstadioRefId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("LiveMatch.Models.Parcialidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parcialidades");
                });

            modelBuilder.Entity("LiveMatch.Models.TipoEspectador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoEspectadores");
                });

            modelBuilder.Entity("LiveMatch.Models.UbicacionEstadio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UbicacionesEstadio");
                });

            modelBuilder.Entity("LiveMatch.Models.Evento", b =>
                {
                    b.HasOne("LiveMatch.Models.Deporte", "Deporte")
                        .WithMany()
                        .HasForeignKey("DeporteRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiveMatch.Models.Estadio", "Estadio")
                        .WithMany()
                        .HasForeignKey("EstadioRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deporte");

                    b.Navigation("Estadio");
                });
#pragma warning restore 612, 618
        }
    }
}

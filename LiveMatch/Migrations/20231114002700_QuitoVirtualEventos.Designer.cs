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
    [Migration("20231114002700_QuitoVirtualEventos")]
    partial class QuitoVirtualEventos
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

            modelBuilder.Entity("LiveMatch.Models.Entrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("EventoRefId")
                        .HasColumnType("int");

                    b.Property<int?>("ParcialidadRefId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int?>("TipoEspectadorRefId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UbicacionEstadioRefId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventoRefId");

                    b.HasIndex("ParcialidadRefId");

                    b.HasIndex("TipoEspectadorRefId");

                    b.HasIndex("UbicacionEstadioRefId");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("LiveMatch.Models.Estadio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("LiveMatch.Models.Entrada", b =>
                {
                    b.HasOne("LiveMatch.Models.Evento", "Evento")
                        .WithMany("Entradas")
                        .HasForeignKey("EventoRefId");

                    b.HasOne("LiveMatch.Models.Parcialidad", "Parcialidad")
                        .WithMany()
                        .HasForeignKey("ParcialidadRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiveMatch.Models.TipoEspectador", "TipoEspectador")
                        .WithMany()
                        .HasForeignKey("TipoEspectadorRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiveMatch.Models.UbicacionEstadio", "UbicacionEstadio")
                        .WithMany()
                        .HasForeignKey("UbicacionEstadioRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Parcialidad");

                    b.Navigation("TipoEspectador");

                    b.Navigation("UbicacionEstadio");
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

            modelBuilder.Entity("LiveMatch.Models.Evento", b =>
                {
                    b.Navigation("Entradas");
                });
#pragma warning restore 612, 618
        }
    }
}
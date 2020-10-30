﻿// <auto-generated />
using System;
using APIBook.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIBook.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIBook.Models.Autor", b =>
                {
                    b.Property<int>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAutor");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("APIBook.Models.Estudiante", b =>
                {
                    b.Property<int>("IdLector")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Carrera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLector");

                    b.ToTable("Estudiante");
                });

            modelBuilder.Entity("APIBook.Models.LibAut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AutorIdAutor")
                        .HasColumnType("int");

                    b.Property<int>("IdAutor")
                        .HasColumnType("int");

                    b.Property<int>("IdLibro")
                        .HasColumnType("int");

                    b.Property<int?>("LibroIdLibro")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorIdAutor");

                    b.HasIndex("LibroIdLibro");

                    b.ToTable("LibAut");
                });

            modelBuilder.Entity("APIBook.Models.Libro", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Editorial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLibro");

                    b.ToTable("Libro");
                });

            modelBuilder.Entity("APIBook.Models.Prestamo", b =>
                {
                    b.Property<int>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Devuelto")
                        .HasColumnType("bit");

                    b.Property<int?>("EstudianteIdLector")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaDevolucion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPrestamo")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLector")
                        .HasColumnType("int");

                    b.Property<int>("IdLibro")
                        .HasColumnType("int");

                    b.Property<int?>("LibroIdLibro")
                        .HasColumnType("int");

                    b.HasKey("IdPrestamo");

                    b.HasIndex("EstudianteIdLector");

                    b.HasIndex("LibroIdLibro");

                    b.ToTable("Prestamo");
                });

            modelBuilder.Entity("APIBook.Models.LibAut", b =>
                {
                    b.HasOne("APIBook.Models.Autor", "Autor")
                        .WithMany("LibroAutor")
                        .HasForeignKey("AutorIdAutor");

                    b.HasOne("APIBook.Models.Libro", "Libro")
                        .WithMany("LibroAutor")
                        .HasForeignKey("LibroIdLibro");
                });

            modelBuilder.Entity("APIBook.Models.Prestamo", b =>
                {
                    b.HasOne("APIBook.Models.Estudiante", "Estudiante")
                        .WithMany("Prestamo")
                        .HasForeignKey("EstudianteIdLector");

                    b.HasOne("APIBook.Models.Libro", "Libro")
                        .WithMany("Prestamo")
                        .HasForeignKey("LibroIdLibro");
                });
#pragma warning restore 612, 618
        }
    }
}
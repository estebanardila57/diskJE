﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyectodisctienda;

namespace proyectodisctienda.Migrations
{
    [DbContext(typeof(Basecontext))]
    partial class BasecontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("proyectodisctienda.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cedulacli")
                        .HasColumnType("int");

                    b.Property<string>("Direccioncli")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombrecli")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefonocli")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("proyectodisctienda.Models.Discos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcioncd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Discos");
                });

            modelBuilder.Entity("proyectodisctienda.Models.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CodDiskId")
                        .HasColumnType("int");

                    b.Property<int>("Codiodisco")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fechafinalpres")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fechainiciopres")
                        .HasColumnType("datetime2");

                    b.Property<int>("Idclientepres")
                        .HasColumnType("int");

                    b.Property<int?>("IdclipresId")
                        .HasColumnType("int");

                    b.Property<int>("Idusers")
                        .HasColumnType("int");

                    b.Property<int?>("iduserystemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodDiskId");

                    b.HasIndex("IdclipresId");

                    b.HasIndex("iduserystemId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("proyectodisctienda.Models.Sancion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descripcionretraso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Iduser")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecharetrasouser")
                        .HasColumnType("datetime2");

                    b.Property<int>("idprest")
                        .HasColumnType("int");

                    b.Property<int?>("idprestamosId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("idprestamosId");

                    b.HasIndex("userId");

                    b.ToTable("Sanciones");
                });

            modelBuilder.Entity("proyectodisctienda.Models.Usersystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idcliente")
                        .HasColumnType("int");

                    b.Property<string>("Nomuser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("clienteId")
                        .HasColumnType("int");

                    b.Property<string>("descripcioncargo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("clienteId");

                    b.ToTable("Usersystems");
                });

            modelBuilder.Entity("proyectodisctienda.Models.Prestamo", b =>
                {
                    b.HasOne("proyectodisctienda.Models.Discos", "CodDisk")
                        .WithMany()
                        .HasForeignKey("CodDiskId");

                    b.HasOne("proyectodisctienda.Models.Clientes", "Idclipres")
                        .WithMany()
                        .HasForeignKey("IdclipresId");

                    b.HasOne("proyectodisctienda.Models.Usersystem", "iduserystem")
                        .WithMany()
                        .HasForeignKey("iduserystemId");

                    b.Navigation("CodDisk");

                    b.Navigation("Idclipres");

                    b.Navigation("iduserystem");
                });

            modelBuilder.Entity("proyectodisctienda.Models.Sancion", b =>
                {
                    b.HasOne("proyectodisctienda.Models.Prestamo", "idprestamos")
                        .WithMany()
                        .HasForeignKey("idprestamosId");

                    b.HasOne("proyectodisctienda.Models.Usersystem", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("idprestamos");

                    b.Navigation("user");
                });

            modelBuilder.Entity("proyectodisctienda.Models.Usersystem", b =>
                {
                    b.HasOne("proyectodisctienda.Models.Clientes", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteId");

                    b.Navigation("cliente");
                });
#pragma warning restore 612, 618
        }
    }
}

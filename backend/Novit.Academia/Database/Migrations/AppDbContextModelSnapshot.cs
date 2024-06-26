﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Novit.Academia.Database;

#nullable disable

namespace Novit.Academia.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Novit.Academia.Domain.Carrito", b =>
                {
                    b.Property<int>("IdCarrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdCarrito");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("Novit.Academia.Domain.ItemCarrito", b =>
                {
                    b.Property<int>("IdItemCarrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCarrito")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProducto")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdItemCarrito");

                    b.HasIndex("IdCarrito");

                    b.HasIndex("IdProducto");

                    b.ToTable("ItemCarrito");
                });

            modelBuilder.Entity("Novit.Academia.Domain.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UrlImagen")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("IdProducto");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            IdProducto = 1,
                            Nombre = "Fideo",
                            Precio = 550m,
                            Stock = 400
                        },
                        new
                        {
                            IdProducto = 2,
                            Nombre = "Arroz",
                            Precio = 900m,
                            Stock = 350
                        },
                        new
                        {
                            IdProducto = 3,
                            Nombre = "Raviol",
                            Precio = 1600m,
                            Stock = 120
                        });
                });

            modelBuilder.Entity("Novit.Academia.Domain.Rol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rol");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5ee17b40-b6c2-457a-9853-271f19935191"),
                            Name = "administrador"
                        },
                        new
                        {
                            Id = new Guid("dec5321b-0280-446c-9ffa-8fa4aeb3a2d9"),
                            Name = "cliente"
                        },
                        new
                        {
                            Id = new Guid("621ef88a-9dae-49d1-ba9d-c2f4dd89dadb"),
                            Name = "vendedor"
                        });
                });

            modelBuilder.Entity("Novit.Academia.Domain.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("RolUsuario", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UsuariosId")
                        .HasColumnType("TEXT");

                    b.HasKey("RolesId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("RolUsuario");
                });

            modelBuilder.Entity("Novit.Academia.Domain.ItemCarrito", b =>
                {
                    b.HasOne("Novit.Academia.Domain.Carrito", "Carrito")
                        .WithMany("Items")
                        .HasForeignKey("IdCarrito")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Novit.Academia.Domain.Producto", "Producto")
                        .WithMany("Items")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("RolUsuario", b =>
                {
                    b.HasOne("Novit.Academia.Domain.Rol", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Novit.Academia.Domain.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Novit.Academia.Domain.Carrito", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Novit.Academia.Domain.Producto", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}

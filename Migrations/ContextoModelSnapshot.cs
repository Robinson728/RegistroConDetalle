﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroDetalle.DAL;

namespace RegistroDetalle.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("RegistroDetalle.Entidades.Permisos", b =>
                {
                    b.Property<int>("PermisoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Permiso")
                        .HasColumnType("TEXT");

                    b.HasKey("PermisoId");

                    b.ToTable("Permisos");

                    b.HasData(
                        new
                        {
                            PermisoId = 1,
                            Permiso = "Descuento"
                        },
                        new
                        {
                            PermisoId = 2,
                            Permiso = "Vende"
                        },
                        new
                        {
                            PermisoId = 3,
                            Permiso = "Cobra"
                        });
                });

            modelBuilder.Entity("RegistroDetalle.Entidades.Roles", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<bool>("esActivo")
                        .HasColumnType("INTEGER");

                    b.HasKey("RolId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RegistroDetalle.Entidades.RolesDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PermisoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RolId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("esAsignado")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("RolesDetalle");
                });

            modelBuilder.Entity("RegistroDetalle.Entidades.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alias")
                        .HasColumnType("TEXT");

                    b.Property<string>("Clave")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConfirmarClave")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rol")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("RegistroDetalle.Entidades.Permisos", b =>
                {
                    b.HasOne("RegistroDetalle.Entidades.Permisos", "permiso")
                        .WithMany()
                        .HasForeignKey("PermisoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("permiso");
                });

            modelBuilder.Entity("RegistroDetalle.Entidades.RolesDetalle", b =>
                {
                    b.HasOne("RegistroDetalle.Entidades.Roles", null)
                        .WithMany("Detalle")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegistroDetalle.Entidades.Roles", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}

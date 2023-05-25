﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Refaccionaria.Data;

#nullable disable

namespace Refaccionaria.Data.Migrations
{
    [DbContext(typeof(RefaccionariaDBContext))]
    [Migration("20230307170448_bb")]
    partial class bb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Refaccionaria.Data.Maping.DetalleVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<decimal>("Precioventa")
                        .HasColumnType("SMALLMONEY");

                    b.HasKey("Id");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdVenta");

                    b.ToTable("Detalleventa", (string)null);
                });

            modelBuilder.Entity("Refaccionaria.Data.Maping.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<decimal>("Existencia")
                        .HasColumnType("SMALLMONEY");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<decimal>("Preciocosto")
                        .HasColumnType("SMALLMONEY");

                    b.Property<decimal>("Precioventa")
                        .HasColumnType("SMALLMONEY");

                    b.HasKey("Id");

                    b.ToTable("producto", (string)null);
                });

            modelBuilder.Entity("Refaccionaria.Data.Maping.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Total")
                        .HasColumnType("float")
                        .HasColumnName("SMALLMONEY");

                    b.HasKey("Id");

                    b.ToTable("Sale", (string)null);
                });

            modelBuilder.Entity("Refaccionaria.Data.Maping.DetalleVenta", b =>
                {
                    b.HasOne("Refaccionaria.Data.Maping.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Refaccionaria.Data.Maping.Sale", "Venta")
                        .WithMany()
                        .HasForeignKey("IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ViewDataFromDB.Data;

#nullable disable

namespace ViewDataFromDB.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20250221034559_3thCommit")]
    partial class _3thCommit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ViewDataFromDB.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("ViewDataFromDB.Models.SuKien", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DiaDiem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayToChuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("suKiens");
                });

            modelBuilder.Entity("ViewDataFromDB.Models.Ve", b =>
                {
                    b.Property<int>("MaVe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaVe"));

                    b.Property<decimal>("GiaVe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LoaiVe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaSuKien")
                        .HasColumnType("int");

                    b.HasKey("MaVe");

                    b.HasIndex("MaSuKien");

                    b.ToTable("ves");
                });

            modelBuilder.Entity("ViewDataFromDB.Models.Ve", b =>
                {
                    b.HasOne("ViewDataFromDB.Models.SuKien", "SuKien")
                        .WithMany("Ves")
                        .HasForeignKey("MaSuKien");

                    b.Navigation("SuKien");
                });

            modelBuilder.Entity("ViewDataFromDB.Models.SuKien", b =>
                {
                    b.Navigation("Ves");
                });
#pragma warning restore 612, 618
        }
    }
}

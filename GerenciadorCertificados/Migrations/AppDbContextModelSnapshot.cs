﻿// <auto-generated />
using System;
using GerenciadorCertificados.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciadorCertificados.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("GerenciadorCertificados.Models.Certificado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaCertificado")
                        .HasColumnType("int");

                    b.Property<string>("ArquivoCertificado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<float>("QuantidadeHoras")
                        .HasColumnType("float");

                    b.Property<string>("TituloCertificado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Certificado");
                });

            modelBuilder.Entity("GerenciadorCertificados.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}

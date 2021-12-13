﻿// <auto-generated />
using System;
using MaximaTech.DotnetChallenge.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MaximaTech.DotnetChallenge.Api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MaximaTech.DotnetChallenge.Domain.Models.Departamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID");

                    b.Property<int>("Codigo")
                        .HasColumnType("INT")
                        .HasColumnName("CODIGO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT")
                        .HasColumnName("DESCRICAO");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("STATUS");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique()
                        .HasDatabaseName("IDX_CODIGODEPARTAMENTO");

                    b.ToTable("DEPARTAMENTOS");
                });

            modelBuilder.Entity("MaximaTech.DotnetChallenge.Domain.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID");

                    b.Property<int>("Codigo")
                        .HasColumnType("INT")
                        .HasColumnName("CODIGO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT")
                        .HasColumnName("DESCRICAO");

                    b.Property<Guid>("IDDEPARTAMENTO")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric")
                        .HasColumnName("PRECO");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("STATUS");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique()
                        .HasDatabaseName("IDX_CODIGOPRODUTO");

                    b.HasIndex("IDDEPARTAMENTO");

                    b.ToTable("PRODUTOS");
                });

            modelBuilder.Entity("MaximaTech.DotnetChallenge.Domain.Models.Produto", b =>
                {
                    b.HasOne("MaximaTech.DotnetChallenge.Domain.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("IDDEPARTAMENTO")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Departamento");
                });
#pragma warning restore 612, 618
        }
    }
}
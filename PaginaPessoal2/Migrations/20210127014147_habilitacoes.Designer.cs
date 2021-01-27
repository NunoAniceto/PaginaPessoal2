﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PaginaPessoal2.Migrations
{
    [DbContext(typeof(PaginaPessoalDBContext))]
    [Migration("20210127014147_habilitacoes")]
    partial class habilitacoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaginaPessoal2.Models.Experiencia", b =>
                {
                    b.Property<int>("ExperienciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExperienciaId");

                    b.ToTable("Experiencia");
                });

            modelBuilder.Entity("PaginaPessoal2.Models.Habilitacoes", b =>
                {
                    b.Property<int>("HabilitacoesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Curso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instituicao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HabilitacoesId");

                    b.ToTable("Habilitacoes");
                });
#pragma warning restore 612, 618
        }
    }
}

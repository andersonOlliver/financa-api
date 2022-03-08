﻿// <auto-generated />
using System;
using Financa.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Financa.Infra.Migrations
{
    [DbContext(typeof(FinancaContext))]
    [Migration("20220307200546_adiciona-cartao")]
    partial class adicionacartao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Financa.Domain.Entities.Cartao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<byte>("DiaFechamento")
                        .HasColumnType("TINYINT");

                    b.Property<byte>("DiaVencimento")
                        .HasColumnType("TINYINT");

                    b.Property<string>("Limite")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cartoes", (string)null);
                });

            modelBuilder.Entity("Financa.Domain.Entities.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("Id");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("Financa.Domain.Entities.ItemLancamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LancamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Parcela")
                        .HasColumnType("int");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100, 2)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("LancamentoId");

                    b.ToTable("ItensLancamento", (string)null);
                });

            modelBuilder.Entity("Financa.Domain.Entities.Lancamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartaoId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("TipoLancamento")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100, 2)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("CartaoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Lancamentos", (string)null);
                });

            modelBuilder.Entity("Financa.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Financa.Domain.Entities.Cartao", b =>
                {
                    b.HasOne("Financa.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Cartoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Financa.Domain.Entities.ItemLancamento", b =>
                {
                    b.HasOne("Financa.Domain.Entities.Lancamento", "Lancamento")
                        .WithMany("Itens")
                        .HasForeignKey("LancamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lancamento");
                });

            modelBuilder.Entity("Financa.Domain.Entities.Lancamento", b =>
                {
                    b.HasOne("Financa.Domain.Entities.Cartao", "Cartao")
                        .WithMany("Lancamentos")
                        .HasForeignKey("CartaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Financa.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Lancamentos")
                        .HasForeignKey("CategoriaId")
                        .IsRequired();

                    b.HasOne("Financa.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Lancamentos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cartao");

                    b.Navigation("Categoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Financa.Domain.Entities.Cartao", b =>
                {
                    b.Navigation("Lancamentos");
                });

            modelBuilder.Entity("Financa.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Lancamentos");
                });

            modelBuilder.Entity("Financa.Domain.Entities.Lancamento", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("Financa.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Cartoes");

                    b.Navigation("Lancamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
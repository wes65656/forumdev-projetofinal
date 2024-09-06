﻿// <auto-generated />
using System;
using FDV.Usuarios.App.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FDV.Usuarios.App.Migrations
{
    [DbContext(typeof(UsuarioContext))]
    partial class UsuarioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FDV.Usuarios.App.Domain.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataDeCadastro");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("CaminhoFoto");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("FDV.Usuarios.App.Domain.Usuario", b =>
                {
                    b.OwnsOne("FDV.Core.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)")
                                .HasColumnName("Cpf");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsMany("FDV.Usuarios.App.Domain.Endereco", "Enderecos", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("Complemento")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("nvarchar(5)");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("UsuarioId");

                            b1.ToTable("Endereco");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");

                            b1.OwnsOne("FDV.Core.ValueObjects.Cep", "Cep", b2 =>
                                {
                                    b2.Property<Guid>("EnderecoId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Numero")
                                        .IsRequired()
                                        .HasMaxLength(8)
                                        .HasColumnType("nvarchar(8)")
                                        .HasColumnName("Cep");

                                    b2.HasKey("EnderecoId");

                                    b2.ToTable("Endereco");

                                    b2.WithOwner()
                                        .HasForeignKey("EnderecoId");
                                });

                            b1.Navigation("Cep")
                                .IsRequired();
                        });

                    b.OwnsOne("FDV.Usuarios.App.Domain.Login", "Login", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Hash")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("LoginHash");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");

                            b1.OwnsOne("FDV.Core.ValueObjects.Email", "Email", b2 =>
                                {
                                    b2.Property<Guid>("LoginUsuarioId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Endereco")
                                        .IsRequired()
                                        .HasMaxLength(256)
                                        .HasColumnType("nvarchar(256)")
                                        .HasColumnName("Email");

                                    b2.HasKey("LoginUsuarioId");

                                    b2.ToTable("Usuarios");

                                    b2.WithOwner()
                                        .HasForeignKey("LoginUsuarioId");
                                });

                            b1.OwnsOne("FDV.Core.ValueObjects.Senha", "Senha", b2 =>
                                {
                                    b2.Property<Guid>("LoginUsuarioId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Valor")
                                        .IsRequired()
                                        .HasMaxLength(1000)
                                        .HasColumnType("nvarchar(1000)")
                                        .HasColumnName("Senha");

                                    b2.HasKey("LoginUsuarioId");

                                    b2.ToTable("Usuarios");

                                    b2.WithOwner()
                                        .HasForeignKey("LoginUsuarioId");
                                });

                            b1.Navigation("Email")
                                .IsRequired();

                            b1.Navigation("Senha")
                                .IsRequired();
                        });

                    b.Navigation("Cpf")
                        .IsRequired();

                    b.Navigation("Enderecos");

                    b.Navigation("Login")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

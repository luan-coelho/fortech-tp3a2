﻿// <auto-generated />
using System;
using FortechTP3A2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FortechTP3A2.Migrations
{
    [DbContext(typeof(FortechContext))]
    partial class FortechContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FortechTP3A2.Models.Eletronico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataFabricao")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroNotaFiscal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SolicitacaoServicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModeloId");

                    b.HasIndex("SolicitacaoServicoId");

                    b.ToTable("Eletronico");
                });

            modelBuilder.Entity("FortechTP3A2.Models.Endereco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("FortechTP3A2.Models.HistoricoServico", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SolicitacaoServicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SolicitacaoServicoId");

                    b.ToTable("HistoricoServico");
                });

            modelBuilder.Entity("FortechTP3A2.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("FortechTP3A2.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Modelo");
                });

            modelBuilder.Entity("FortechTP3A2.Models.SolicitacaoServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Detalhes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("SolicitacaoServico");
                });

            modelBuilder.Entity("FortechTP3A2.Models.SolicitacaoTipoServico", b =>
                {
                    b.Property<int>("TipoServicoId")
                        .HasColumnType("int");

                    b.Property<int>("SolicitacaoServicoId")
                        .HasColumnType("int");

                    b.HasKey("TipoServicoId", "SolicitacaoServicoId");

                    b.HasIndex("SolicitacaoServicoId");

                    b.ToTable("SolicitacaoTipoServico");
                });

            modelBuilder.Entity("FortechTP3A2.Models.TipoServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoServico");
                });

            modelBuilder.Entity("FortechTP3A2.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("FortechTP3A2.Models.Eletronico", b =>
                {
                    b.HasOne("FortechTP3A2.Models.Modelo", "Modelo")
                        .WithMany()
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FortechTP3A2.Models.SolicitacaoServico", null)
                        .WithMany("Eletronicos")
                        .HasForeignKey("SolicitacaoServicoId");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("FortechTP3A2.Models.Endereco", b =>
                {
                    b.HasOne("FortechTP3A2.Models.Usuario", "Usuario")
                        .WithMany("Enderecos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FortechTP3A2.Models.HistoricoServico", b =>
                {
                    b.HasOne("FortechTP3A2.Models.SolicitacaoServico", "SolicitacaoServico")
                        .WithMany()
                        .HasForeignKey("SolicitacaoServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SolicitacaoServico");
                });

            modelBuilder.Entity("FortechTP3A2.Models.Modelo", b =>
                {
                    b.HasOne("FortechTP3A2.Models.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("FortechTP3A2.Models.SolicitacaoServico", b =>
                {
                    b.HasOne("FortechTP3A2.Models.Usuario", null)
                        .WithMany("Solicitacoes")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("FortechTP3A2.Models.SolicitacaoTipoServico", b =>
                {
                    b.HasOne("FortechTP3A2.Models.TipoServico", "TipoServico")
                        .WithMany("Solicitacoes")
                        .HasForeignKey("SolicitacaoServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FortechTP3A2.Models.SolicitacaoServico", "SolicitacaoServico")
                        .WithMany("TiposServico")
                        .HasForeignKey("TipoServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SolicitacaoServico");

                    b.Navigation("TipoServico");
                });

            modelBuilder.Entity("FortechTP3A2.Models.Marca", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("FortechTP3A2.Models.SolicitacaoServico", b =>
                {
                    b.Navigation("Eletronicos");

                    b.Navigation("TiposServico");
                });

            modelBuilder.Entity("FortechTP3A2.Models.TipoServico", b =>
                {
                    b.Navigation("Solicitacoes");
                });

            modelBuilder.Entity("FortechTP3A2.Models.Usuario", b =>
                {
                    b.Navigation("Enderecos");

                    b.Navigation("Solicitacoes");
                });
#pragma warning restore 612, 618
        }
    }
}

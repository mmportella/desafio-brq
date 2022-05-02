﻿// <auto-generated />
using DesafioBRQ.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioBRQ.Migrations
{
    [DbContext(typeof(BRQContext))]
    [Migration("20220427033445_Migracao1")]
    partial class Migracao1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DesafioBRQ.Models.Candidato", b =>
                {
                    b.Property<int>("IdCandidato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCandidato"), 1L, 1);

                    b.Property<int>("Cpf")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Nascimento")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.HasKey("IdCandidato");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("DesafioBRQ.Models.Certificacao", b =>
                {
                    b.Property<int>("IdCertificacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCertificacao"), 1L, 1);

                    b.Property<string>("Instituicao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeCertificacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("IdCertificacao");

                    b.HasIndex("SkillId");

                    b.ToTable("Certificacoes");
                });

            modelBuilder.Entity("DesafioBRQ.Models.CertificacaoCandidato", b =>
                {
                    b.Property<int>("IdCertificacaoCandidato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCertificacaoCandidato"), 1L, 1);

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<int>("CertificacaoId")
                        .HasColumnType("int");

                    b.HasKey("IdCertificacaoCandidato");

                    b.HasIndex("CandidatoId");

                    b.HasIndex("CertificacaoId");

                    b.ToTable("CertificacoesCandidatos");
                });

            modelBuilder.Entity("DesafioBRQ.Models.Skill", b =>
                {
                    b.Property<int>("IdSkill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSkill"), 1L, 1);

                    b.Property<string>("NomeSkill")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdSkill");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("DesafioBRQ.Models.SkillCandidato", b =>
                {
                    b.Property<int>("IdSkillCandidato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSkillCandidato"), 1L, 1);

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("IdSkillCandidato");

                    b.HasIndex("CandidatoId");

                    b.HasIndex("SkillId");

                    b.ToTable("SkillCandidatos");
                });

            modelBuilder.Entity("DesafioBRQ.Models.Certificacao", b =>
                {
                    b.HasOne("DesafioBRQ.Models.Skill", "Skill")
                        .WithMany("Certificacoes")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("DesafioBRQ.Models.CertificacaoCandidato", b =>
                {
                    b.HasOne("DesafioBRQ.Models.Candidato", "Candidato")
                        .WithMany("CertificacoesCandidato")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesafioBRQ.Models.Certificacao", "Certificacao")
                        .WithMany("CertificacoesCandidato")
                        .HasForeignKey("CertificacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("Certificacao");
                });

            modelBuilder.Entity("DesafioBRQ.Models.SkillCandidato", b =>
                {
                    b.HasOne("DesafioBRQ.Models.Candidato", "Candidato")
                        .WithMany("SkillsCandidato")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesafioBRQ.Models.Skill", "Skill")
                        .WithMany("SkillsCandidato")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("DesafioBRQ.Models.Candidato", b =>
                {
                    b.Navigation("CertificacoesCandidato");

                    b.Navigation("SkillsCandidato");
                });

            modelBuilder.Entity("DesafioBRQ.Models.Certificacao", b =>
                {
                    b.Navigation("CertificacoesCandidato");
                });

            modelBuilder.Entity("DesafioBRQ.Models.Skill", b =>
                {
                    b.Navigation("Certificacoes");

                    b.Navigation("SkillsCandidato");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using BRQWebService.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace BRQWebService.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20220430030305_OracleMigration")]
    partial class OracleMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BRQWebService.Models.Candidate", b =>
                {
                    b.Property<long>("Cpf")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("nr_cpf");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Cpf"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATE")
                        .HasColumnName("dt_aniversario");

                    b.Property<long>("CellPhone")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("nr_telefone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("email");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(1)")
                        .HasColumnName("genero");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("nome");

                    b.HasKey("Cpf");

                    b.ToTable("TB_CANDIDATO", (string)null);
                });

            modelBuilder.Entity("BRQWebService.Models.Certification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("cd_certificado");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("CandidateKey")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("nr_cpf");

                    b.Property<string>("CertificationName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("nm_certificado");

                    b.HasKey("Id");

                    b.HasIndex("CandidateKey");

                    b.ToTable("TB_CERTIFICADO", (string)null);
                });

            modelBuilder.Entity("BRQWebService.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("cd_skill");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("CandidateKey")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("nr_cpf");

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("nm_skill");

                    b.HasKey("Id");

                    b.HasIndex("CandidateKey");

                    b.ToTable("TB_SKILL", (string)null);
                });

            modelBuilder.Entity("BRQWebService.Models.Certification", b =>
                {
                    b.HasOne("BRQWebService.Models.Candidate", "Candidate")
                        .WithMany("CertificationCollection")
                        .HasForeignKey("CandidateKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("BRQWebService.Models.Skill", b =>
                {
                    b.HasOne("BRQWebService.Models.Candidate", "Candidate")
                        .WithMany("SkillCollection")
                        .HasForeignKey("CandidateKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("BRQWebService.Models.Candidate", b =>
                {
                    b.Navigation("CertificationCollection");

                    b.Navigation("SkillCollection");
                });
#pragma warning restore 612, 618
        }
    }
}
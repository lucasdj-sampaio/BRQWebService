using BRQWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace BRQWebService.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> preferences)
            : base(preferences) { }

        public DbSet<Candidate>? DbCandidates { get; set; }

        public DbSet<Certification>? DbCertification { get; set; }

        public DbSet<Skill>? DbSkill { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            SetCandidateBuilder(builder);
            SetCertificationBuilder(builder);
            SetSkillBuilder(builder);
        }

        private static void SetCandidateBuilder(ModelBuilder builder) 
        {
            builder.Entity<Candidate>().ToTable("TB_CANDIDATO");

            builder.Entity<Candidate>().HasKey(c => c.Cpf);

            builder.Entity<Candidate>().Property(c => c.Cpf)
                .HasColumnName("nr_cpf")
                .IsRequired();

            builder.Entity<Candidate>().Property(c => c.Name)
                .HasColumnName("nome")
                .HasMaxLength(100)
                .IsRequired();

            builder.Entity<Candidate>().Property(c => c.Email)
                .HasColumnName("email")
                .HasMaxLength(200)
                .IsRequired();

            builder.Entity<Candidate>().Property(c => c.CellPhone)
                .HasColumnName("nr_telefone")
                .IsRequired();

            builder.Entity<Candidate>().Property(c => c.Gender)
                .HasColumnName("genero")
                .IsRequired();

            builder.Entity<Candidate>().Property(c => c.BirthDate)
                .HasColumnName("dt_aniversario")
                .HasColumnType("DATE")
                .IsRequired();
        }

        private static void SetCertificationBuilder(ModelBuilder builder) 
        {
            builder.Entity<Certification>().ToTable("TB_CERTIFICADO");

            builder.Entity<Certification>().Property(c => c.Id)
                .HasColumnName("cd_certificado");

            builder.Entity<Certification>().Property(c => c.CertificationName)
                .HasColumnName("nm_certificado")
                .HasMaxLength(200)
                .IsRequired();

            builder.Entity<Certification>().Property(c => c.CandidateKey)
                .HasColumnName("nr_cpf");

            builder.Entity<Certification>()
                .HasOne(c => c.Candidate)
                .WithMany(c => c.CertificationCollection)
                .HasForeignKey(fk => fk.CandidateKey);
        }

        private static void SetSkillBuilder(ModelBuilder builder) 
        {
            builder.Entity<Skill>().ToTable("TB_SKILL");

            builder.Entity<Skill>().Property(s => s.Id)
                .HasColumnName("cd_skill");

            builder.Entity<Skill>().Property(s => s.SkillName)
                .HasColumnName("nm_skill")
                .HasMaxLength(200)
                .IsRequired();

            builder.Entity<Skill>().Property(s => s.CandidateKey)
                .HasColumnName("nr_cpf");

            builder.Entity<Skill>()
                .HasOne(c => c.Candidate)
                .WithMany(s => s.SkillCollection)
                .HasForeignKey(fk => fk.CandidateKey);
        }
    }
}
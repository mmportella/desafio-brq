using DesafioBRQ.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioBRQ.Data
{
    public class BRQContext : DbContext
    {
        public BRQContext(DbContextOptions<BRQContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Certificacao>()
                .HasOne(certificacao => certificacao.Skill)
                .WithMany(skill => skill.Certificacoes)
                .HasForeignKey(certificacao => certificacao.SkillId);

            builder.Entity<CertificacaoCandidato>()
                .HasOne(certificacaoCandidato => certificacaoCandidato.Certificacao)
                .WithMany(certificacao => certificacao.CertificacoesCandidato)
                .HasForeignKey(certificacaoCandidato => certificacaoCandidato.CertificacaoId);

            builder.Entity<CertificacaoCandidato>()
                .HasOne(certificacaoCandidato => certificacaoCandidato.Candidato)
                .WithMany(candidato => candidato.CertificacoesCandidato)
                .HasForeignKey(certificacaoCandidato => certificacaoCandidato.CandidatoId);

            builder.Entity<SkillCandidato>()
                .HasOne(skillCandidato => skillCandidato.Skill)
                .WithMany(skill => skill.SkillsCandidato)
                .HasForeignKey(skillCandidato => skillCandidato.SkillId);

            builder.Entity<SkillCandidato>()
                .HasOne(skillCandidato => skillCandidato.Candidato)
                .WithMany(candidato => candidato.SkillsCandidato)
                .HasForeignKey(skillCandidato => skillCandidato.CandidatoId);

        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Certificacao> Certificacoes { get; set; }
        public DbSet<SkillCandidato> SkillCandidatos { get; set; }
        public DbSet<CertificacaoCandidato> CertificacoesCandidatos { get; set; }

    }
}

using FortechTP3A2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FortechTP3A2.Data
{
    public class FortechContext : DbContext
    {
        public FortechContext(DbContextOptions<FortechContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Eletronico> Eletronico { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
        public DbSet<TipoServico> TipoServico { get; set; }
        public DbSet<SolicitacaoServico> SolicitacaoServico { get; set; }
        public DbSet<SolicitacaoTipoServico> SolicitacaoTipoServico { get; set; }
        public DbSet<HistoricoServico> HistoricoServico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SolicitacaoTipoServico>().HasKey(st => new { st.TipoServicoId, st.SolicitacaoServicoId });
            
            modelBuilder.Entity<SolicitacaoTipoServico>()
             .HasOne<TipoServico>(st => st.TipoServico)
              .WithMany(s => s.Solicitacoes)
              .HasForeignKey(st => st.SolicitacaoServicoId);

            modelBuilder.Entity<SolicitacaoTipoServico>()
             .HasOne<SolicitacaoServico>(s => s.SolicitacaoServico)
              .WithMany(t => t.TiposServico)
              .HasForeignKey(s => s.TipoServicoId);
        }
    }
}

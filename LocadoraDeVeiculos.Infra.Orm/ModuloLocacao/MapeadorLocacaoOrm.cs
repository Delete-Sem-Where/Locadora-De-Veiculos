using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloLocacao
{
    public class MapeadorLocacaoOrm : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TBLocacao");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.Cliente)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Condutor)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.GrupoVeiculos)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Veiculo)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.PlanoCobranca)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.DataLocacao).HasColumnType("date");
            builder.Property(x => x.DataDevolucaoPrevista).HasColumnType("date");
            builder.Property(x => x.ValorTotalPrevisto).HasColumnType("decimal(8,2)");
            builder.HasMany(x => x.TaxasSelecionadas);
            builder.Property(x => x.DataDevolucao).HasColumnType("date").HasDefaultValue(DateTime.MinValue);
            builder.Property(x => x.EstaAlugado).HasColumnType("bit").IsRequired();
            builder.Property(x => x.NivelTanqueDevolucao)
                .HasColumnType("int")
                .HasConversion<int>()
                .HasColumnName("NivelTanqueDevolucao")
                .HasDefaultValue(NivelTanqueDevolucao.Cheio);
        }
    }
}

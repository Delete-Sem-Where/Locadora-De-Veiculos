using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloTaxa
{
    public class MapeadorTaxaOrm : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> builder)
        {
            builder.ToTable("TBTaxa");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Descricao).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Valor).HasColumnType("decimal(8,2)").IsRequired();
            builder.Property(x => x.TipoCalculo).HasColumnType("int").IsRequired().HasConversion<int>().HasColumnName("TipoCalculo");
            builder.HasMany(x => x.Locacoes)
                    .WithMany(s => s.TaxasSelecionadas)
                    .UsingEntity<Dictionary<string, object>>(
                        "LocacaoTaxa",
                        x => x.HasOne<Locacao>().WithMany().OnDelete(DeleteBehavior.Cascade),
                        x => x.HasOne<Taxa>().WithMany().OnDelete(DeleteBehavior.Restrict)
                    );
        }
    }
}

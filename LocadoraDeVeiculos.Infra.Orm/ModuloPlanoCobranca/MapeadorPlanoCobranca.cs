using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> builder)
        {
            builder.ToTable("TBPlanoCobranca");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.ModalidadePlanoCobranca).HasColumnType("int").IsRequired().HasConversion<int>().HasColumnName("ModalidadePlanoCobranca");
            builder.Property(x => x.ValorDiaria).HasColumnType("decimal(8,2)").IsRequired();
            builder.Property(x => x.LimiteKm).HasColumnType("decimal(8,2)").IsRequired();
            builder.Property(x => x.ValorKm).HasColumnType("decimal(8,2)").IsRequired();
            builder.HasOne(x => x.GrupoVeiculos);
        }
    }
}

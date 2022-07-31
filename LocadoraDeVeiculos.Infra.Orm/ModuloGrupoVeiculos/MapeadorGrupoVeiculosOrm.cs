using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculosOrm : IEntityTypeConfiguration<GrupoVeiculos>
    {
        public void Configure(EntityTypeBuilder<GrupoVeiculos> builder)
        {
            builder.ToTable("TBGrupoVeiculos");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(50)").IsRequired();
        }
    }
}

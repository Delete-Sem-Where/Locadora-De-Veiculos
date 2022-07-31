using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculos
{
    public class MapeadorVeiculosOrm : IEntityTypeConfiguration<Veiculos>
    {
        public void Configure(EntityTypeBuilder<Veiculos> builder)
        {
            builder.ToTable("TBVeiculos");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Modelo).HasColumnType("varchar(65)").IsRequired();
            builder.Property(x => x.Marca).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Ano).HasColumnType("varchar(4)").IsRequired();
            builder.Property(x => x.Cor).HasColumnType("varchar(40)").IsRequired();
            builder.Property(x => x.Placa).HasColumnType("varchar(7)").IsRequired();
            builder.Property(x => x.QuilometroPercorrido).HasColumnType("varchar(8)").IsRequired();
            builder.Property(x => x.CapacidadeTanque).HasColumnType("varchar(8)").IsRequired();          
            builder.Property(x => x.TipoCombustivel).HasColumnType("varchar(30)").IsRequired();
            builder.HasOne(x => x.GrupoVeiculos)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.Imagem).HasColumnType("varbinary(max)").IsRequired(false);
        }
    }
}

using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosOrm : IRepositorioGrupoVeiculos
    {
        private DbSet<GrupoVeiculos> gruposDeVeiculos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioGrupoVeiculosOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            gruposDeVeiculos = dbContext.Set<GrupoVeiculos>();
            this.dbContext = dbContext;
        }

        public void Inserir(GrupoVeiculos novoRegistro)
        {
            gruposDeVeiculos.Add(novoRegistro);
        }

        public void Editar(GrupoVeiculos registro)
        {
            gruposDeVeiculos.Update(registro);
        }

        public void Excluir(GrupoVeiculos registro)
        {
            gruposDeVeiculos.Remove(registro);
        }

        public List<GrupoVeiculos> SelecionarTodos()
        {
            return gruposDeVeiculos.ToList();
        }

        public GrupoVeiculos SelecionarPorId(Guid id)
        {
            return gruposDeVeiculos.SingleOrDefault(x => x.Id == id);
        }

        public GrupoVeiculos SelecionarGrupoVeiculosPorNome(string nome)
        {
            return gruposDeVeiculos.FirstOrDefault(x => x.Nome == nome);
        }
    }
}

using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculos
{
    public class RepositorioVeiculosOrm : IRepositorioVeiculos
    {
        private DbSet<Veiculos> veiculos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioVeiculosOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            veiculos = dbContext.Set<Veiculos>();
            this.dbContext = dbContext;
        }

        public void Inserir(Veiculos novoRegistro)
        {
            veiculos.Add(novoRegistro);
        }

        public void Editar(Veiculos registro)
        {
            veiculos.Update(registro);
        }

        public void Excluir(Veiculos registro)
        {
            veiculos.Remove(registro);
        }

        public List<Veiculos> SelecionarTodos()
        {
            return veiculos.ToList();
        }

        public Veiculos SelecionarPorId(Guid id)
        {
            return veiculos.SingleOrDefault(x => x.Id == id);
        }

        public Veiculos SelecionarVeiculosPorPlaca(string placa)
        {
            return veiculos.FirstOrDefault(x => x.Placa == placa);
        }        
    }
}

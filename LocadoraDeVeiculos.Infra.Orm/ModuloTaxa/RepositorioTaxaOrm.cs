using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloTaxa
{
    public class RepositorioTaxaOrm : IRepositorioTaxa
    {
        private DbSet<Taxa> taxas;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioTaxaOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            taxas = dbContext.Set<Taxa>();
            this.dbContext = dbContext;
        }

        public void Inserir(Taxa novoRegistro)
        {
            taxas.Add(novoRegistro);
        }

        public void Editar(Taxa registro)
        {
            taxas.Update(registro);
        }

        public void Excluir(Taxa registro)
        {
            taxas.Remove(registro);
        }

        public List<Taxa> SelecionarTodos()
        {
            return taxas.ToList();
        }

        public Taxa SelecionarPorId(Guid id)
        {
            return taxas.SingleOrDefault(x => x.Id == id);
        }

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return taxas.FirstOrDefault(x => x.Descricao == descricao);
        }        
    }
}

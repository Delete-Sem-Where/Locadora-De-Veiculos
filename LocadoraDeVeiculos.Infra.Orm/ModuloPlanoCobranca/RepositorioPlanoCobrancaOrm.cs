using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaOrm : IRepositorioPlanoCobranca
    {
        private DbSet<PlanoCobranca> planosCobranca;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioPlanoCobrancaOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            planosCobranca = dbContext.Set<PlanoCobranca>();
            this.dbContext = dbContext;
        }

        public void Inserir(PlanoCobranca novoRegistro)
        {
            planosCobranca.Add(novoRegistro);
        }

        public void Editar(PlanoCobranca registro)
        {
            planosCobranca.Update(registro);
        }

        public void Excluir(PlanoCobranca registro)
        {
            planosCobranca.Remove(registro);
        }

        public List<PlanoCobranca> SelecionarTodos()
        {
            return planosCobranca.Include(x => x.GrupoVeiculos).ToList();
        }

        public PlanoCobranca SelecionarPorId(Guid id)
        {
            return planosCobranca.SingleOrDefault(x => x.Id == id);
        }        

        //Ver isso aqui
        public PlanoCobranca SelecionarPlanoPorGrupo_E_Modalidade(Guid id, ModalidadePlanoCobranca tipoPlano)
        {
            return planosCobranca.FirstOrDefault(x => x.GrupoVeiculos.Id == id && x.ModalidadePlanoCobranca == tipoPlano);
        }
    }
}
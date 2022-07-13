using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
    {
        public void Editar(PlanoCobranca registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(PlanoCobranca registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(PlanoCobranca novoRegistro)
        {
            throw new NotImplementedException();
        }

        public PlanoCobranca SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<PlanoCobranca> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}

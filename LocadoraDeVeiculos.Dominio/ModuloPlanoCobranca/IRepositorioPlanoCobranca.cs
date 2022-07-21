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
        PlanoCobranca SelecionarPlanoPorGrupo_E_Modalidade(Guid id, ModalidadePlanoCobranca tipoPlano);
    }
}

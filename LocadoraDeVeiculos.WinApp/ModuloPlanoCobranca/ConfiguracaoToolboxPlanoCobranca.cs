using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    public class ConfiguracaoToolboxPlanoCobranca : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Planos de Cobrança";

        public override string TooltipInserir { get { return "Inserir um novo plano de cobrança"; } }

        public override string TooltipEditar { get { return "Editar um plano de cobrança existente"; } }

        public override string TooltipExcluir { get { return "Excluir um plano de cobrança existente"; } }
    }
}

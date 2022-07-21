using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculos
{
    public class ConfiguracaoToolboxVeiculos : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de veículos";

        public override string TooltipInserir { get { return "Inserir novo veículo"; } }

        public override string TooltipEditar { get { return "Editar veículo"; } }

        public override string TooltipExcluir { get { return "Excluir veículo"; } }
    }
}

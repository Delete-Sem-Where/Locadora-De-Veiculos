using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloConfiguracao
{
    public class ConfiguracaoToolboxConfiguracao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Configurações";

        public override string TooltipInserir { get { return ""; } }

        public override string TooltipEditar { get { return ""; } }

        public override string TooltipExcluir { get { return ""; } }
    }
}

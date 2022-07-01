using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ConfiguracaoToolboxCondutor : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Condutor";

        public override string TooltipInserir { get { return "Inserir um novo condutor"; } }

        public override string TooltipEditar { get { return "Editar um condutor existente"; } }

        public override string TooltipExcluir { get { return "Excluir um condutor existente"; } }
    }
}

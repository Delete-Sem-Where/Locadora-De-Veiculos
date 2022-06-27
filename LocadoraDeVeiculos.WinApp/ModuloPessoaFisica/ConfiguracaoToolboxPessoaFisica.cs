using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloPessoaFisica
{
    public class ConfiguracaoToolboxPessoaFisica:ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Pessoas Físicas";

        public override string TooltipInserir { get { return "Inserir uma nova pessoa física"; } }

        public override string TooltipEditar { get { return "Editar uma pessoa física existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma pessoa física existente"; } }
    }
}
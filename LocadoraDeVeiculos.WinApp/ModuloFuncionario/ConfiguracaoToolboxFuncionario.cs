using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ConfiguracaoToolboxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Funcionarios";

        public override string TooltipInserir { get { return "Inserir um novo funcionario"; } }

        public override string TooltipEditar { get { return "Editar um funcionario existente"; } }

        public override string TooltipExcluir { get { return "Excluir um funcionario existente"; } }

        //public override string TooltipAgrupar { get { return "Agrupar funcionarios"; } }

        //public override bool AgruparHabilitado { get { return true; } }
    }
}

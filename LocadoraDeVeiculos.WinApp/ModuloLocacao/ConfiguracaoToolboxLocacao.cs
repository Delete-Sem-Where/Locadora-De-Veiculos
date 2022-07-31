using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public class ConfiguracaoToolboxLocacao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Locação";

        public override string TooltipInserir { get { return "Inserir uma nova locacação"; } }

        public override string TooltipEditar { get { return "Editar uma locacação existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma locacação existente"; } }

        public override string TooltipAdicionarItens { get { return "Registrar uma devolução"; } }

        public override bool AdicionarItensHabilitado { get { return true; } }

    }
}

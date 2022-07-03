using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ConfiguracaoToolboxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Clientes";

        public override string TooltipInserir { get { return "Inserir um novo cliente"; } }

        public override string TooltipEditar { get { return "Editar um cliente existente"; } }

        public override string TooltipExcluir { get { return "Excluir um cliente existente"; } }
    }
}

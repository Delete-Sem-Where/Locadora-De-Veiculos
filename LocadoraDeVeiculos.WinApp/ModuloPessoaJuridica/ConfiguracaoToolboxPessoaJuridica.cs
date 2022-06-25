using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloPessoaJuridica
{
    public class ConfiguracaoToolboxPessoaJuridica : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Pessoa Jurídica";

        public override string TooltipInserir { get { return "Inserir uma novo Pessoa Jurídica"; } }

        public override string TooltipEditar { get { return "Editar uma Pessoa Jurídica existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma Pessoa Jurídica existente"; } }
    }
}

using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloGruposVeiculos
{
    public class ConfiguraçãoToolboxGrupoVeiculos : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de grupo de veículos";

        public override string TooltipInserir { get { return "Inserir um novo grupo de veículos"; } }

        public override string TooltipEditar { get { return "Editar um grupo de veículos"; } }

        public override string TooltipExcluir { get { return "Excluir um grupo de veículos"; } }
    }
}

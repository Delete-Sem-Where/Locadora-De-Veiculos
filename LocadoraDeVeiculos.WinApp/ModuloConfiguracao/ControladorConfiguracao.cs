using Configs;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloConfiguracao
{
    public class ControladorConfiguracao : ControladorBase
    {

        private readonly ConfiguracaoAplicacao configuracao;

        public ControladorConfiguracao(ConfiguracaoAplicacao configuracao)
        {
            this.configuracao = configuracao;
        }

        public override void Editar()
        {
            
        }

        public override void Excluir()
        {

        }

        public override void Inserir()
        {

        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxConfiguracao();
        }

        public override UserControl ObtemListagem()
        {
            return new ConfiguracaoControl(configuracao);
        }
    }
}

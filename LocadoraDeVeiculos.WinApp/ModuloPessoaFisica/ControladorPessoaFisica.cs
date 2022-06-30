using LocadoraDeVeiculos.Aplicacao.ModuloPessoaFisica;
using LocadoraDeVeiculos.Dominio.ModuloPessoaFisica;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloPessoaFisica
{
    public class ControladorPessoaFisica : ControladorBase
    {
        private readonly IRepositorioPessoaFisica repositorioPessoaFisica;
        private TabelaPessoaFisicaControl tabelaPessoaFisica;
        private readonly ServicoPessoaFisica servicoPessoaFisica;

        public ControladorPessoaFisica(IRepositorioPessoaFisica repositorioPessoaFisica, ServicoPessoaFisica servicoPessoaFisica)
        {
            this.repositorioPessoaFisica = repositorioPessoaFisica;
            this.servicoPessoaFisica = servicoPessoaFisica;
        }

        public override void Inserir()
        {
            TelaCadastroPessoaFisicaForm tela = new TelaCadastroPessoaFisicaForm();
            tela.PessoaFisica = new PessoaFisica();

            tela.GravarRegistro = servicoPessoaFisica.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPessoasFisicas();

        }

        public override void Editar()
        {
            PessoaFisica pessoaFisicaSelecionada = ObtemPessoaFisicaSelecionado();

            if (pessoaFisicaSelecionada == null)
            {
                MessageBox.Show("Selecione uma Pessoa Física primeiro",
                "Edição de Pessoas Físicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroPessoaFisicaForm tela = new TelaCadastroPessoaFisicaForm();

            tela.PessoaFisica = pessoaFisicaSelecionada.Clonar();

            tela.GravarRegistro = servicoPessoaFisica.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPessoasFisicas();

        }

        public override void Excluir()
        {
            PessoaFisica contatoSelecionado = ObtemPessoaFisicaSelecionado();

            if (contatoSelecionado == null)
            {
                MessageBox.Show("Selecione uma Pessoa Física primeiro",
                "Exclusão de Pessoas Físicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a Pessoa Física?",
                "Exclusão de Pessoas Físicas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioPessoaFisica.Excluir(contatoSelecionado);
                CarregarPessoasFisicas();
            }
        }

        //public override void Agrupar()
        //{
        //    TelaAgrupamentoContatoForm telaAgrupamento = new TelaAgrupamentoContatoForm();

        //    if (telaAgrupamento.ShowDialog() == DialogResult.OK)
        //    {
        //        tabelaContatos.AgruparContatos(telaAgrupamento.TipoAgrupamento);
        //    }
        //}

        public override UserControl ObtemListagem()
        {
            //if (tabelaContatos == null)
            tabelaPessoaFisica = new TabelaPessoaFisicaControl();

            CarregarPessoasFisicas();

            return tabelaPessoaFisica;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPessoaFisica();
        }

        private PessoaFisica ObtemPessoaFisicaSelecionado()
        {
            var id = tabelaPessoaFisica.ObtemNumeroPessoaFisicaSelecionada();

            return (PessoaFisica)repositorioPessoaFisica.SelecionarPorId(id);
        }

        private void CarregarPessoasFisicas()
        {
            List<PessoaFisica> pessoasFisicas = repositorioPessoaFisica.SelecionarTodos();

            tabelaPessoaFisica.AtualizarRegistros(pessoasFisicas);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {pessoasFisicas.Count} pessoas físicas(s)");
        }

    }
}

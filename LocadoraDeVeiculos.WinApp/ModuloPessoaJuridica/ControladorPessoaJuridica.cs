using LocadoraDeVeiculos.Aplicacao.ModuloPessoaJuridica;
using LocadoraDeVeiculos.Dominio.ModuloPessoaJuridica;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloPessoaJuridica
{
    public class ControladorPessoaJuridica : ControladorBase
    {
        private readonly IRepositorioPessoaJuridica repositorioPessoaJuridica;
        private TabelaPessoaJuridicaControl tabelaPessoaJuridica;
        private ServicoPessoaJuridica servicoPessoaJuridica;

        public ControladorPessoaJuridica(IRepositorioPessoaJuridica repositorioPessoaJuridica, ServicoPessoaJuridica servicoPessoaJuridica)
        {
            this.repositorioPessoaJuridica = repositorioPessoaJuridica;
            this.servicoPessoaJuridica = servicoPessoaJuridica;
        }

        public override void Inserir()
        {
            TelaCadastroPessoaJuridicaForm tela = new TelaCadastroPessoaJuridicaForm();
            tela.PessoaJuridica = new PessoaJuridica();

            tela.GravarRegistro = servicoPessoaJuridica.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPessoasJuridicas();

        }

        public override void Editar()
        {
            PessoaJuridica pessoaJuridicaSelecionada = ObtemPessoaJuridicaSelecionado();

            if (pessoaJuridicaSelecionada == null)
            {
                MessageBox.Show("Selecione uma Pessoa Jurídica primeiro",
                "Edição de Pessoas Juridicass", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroPessoaJuridicaForm tela = new TelaCadastroPessoaJuridicaForm();

            tela.PessoaJuridica = pessoaJuridicaSelecionada.Clonar();

            tela.GravarRegistro = servicoPessoaJuridica.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPessoasJuridicas();

        }

        public override void Excluir()
        {
            PessoaJuridica contatoSelecionado = ObtemPessoaJuridicaSelecionado();

            if (contatoSelecionado == null)
            {
                MessageBox.Show("Selecione uma Pessoa Jurídica primeiro",
                "Exclusão de Pessoas Juridicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a Pessoa Jurídica?",
                "Exclusão de Pessoas Juridicas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioPessoaJuridica.Excluir(contatoSelecionado);
                CarregarPessoasJuridicas();
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
            tabelaPessoaJuridica = new TabelaPessoaJuridicaControl();

            CarregarPessoasJuridicas();

            return tabelaPessoaJuridica;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPessoaJuridica();
        }

        private PessoaJuridica ObtemPessoaJuridicaSelecionado()
        {
            var id = tabelaPessoaJuridica.ObtemNumeroPessoaJuridicaSelecionado();

            return (PessoaJuridica)repositorioPessoaJuridica.SelecionarPorId(id);
        }

        private void CarregarPessoasJuridicas()
        {
            List<PessoaJuridica> pessoasJuridicas = repositorioPessoaJuridica.SelecionarTodos();

            tabelaPessoaJuridica.AtualizarRegistros(pessoasJuridicas);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {pessoasJuridicas.Count} contato(s)");
        }

    }
}

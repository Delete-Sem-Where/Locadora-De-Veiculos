using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private readonly IRepositorioCliente repositorioCliente;
        private TabelaClientesControl tabelaCliente;
        private readonly ServicoCliente servicoCliente;

        public ControladorCliente(IRepositorioCliente repositorioCliente, ServicoCliente servicoCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            TelaCadastroClientesForm tela = new TelaCadastroClientesForm();
            tela.Cliente = new Cliente();

            tela.GravarRegistro = servicoCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPessoasFisicas();

        }

        public override void Editar()
        {
            Cliente pessoaFisicaSelecionada = ObtemClienteSelecionado();

            if (pessoaFisicaSelecionada == null)
            {
                MessageBox.Show("Selecione um Cliente primeiro",
                "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroClientesForm tela = new TelaCadastroClientesForm();

            tela.Cliente = pessoaFisicaSelecionada.Clonar();

            tela.GravarRegistro = servicoCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPessoasFisicas();

        }

        public override void Excluir()
        {
            Cliente contatoSelecionado = ObtemClienteSelecionado();

            if (contatoSelecionado == null)
            {
                MessageBox.Show("Selecione um Cliente primeiro",
                "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Cliente?",
                "Exclusão de Clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioCliente.Excluir(contatoSelecionado);
                CarregarPessoasFisicas();
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaCliente = new TabelaClientesControl();

            CarregarPessoasFisicas();

            return tabelaCliente;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCliente();
        }

        private Cliente ObtemClienteSelecionado()
        {
            var id = tabelaCliente.ObtemNumeroClienteSelecionado();

            return (Cliente)repositorioCliente.SelecionarPorId(id);
        }

        private void CarregarPessoasFisicas()
        {
            List<Cliente> pessoasFisicas = repositorioCliente.SelecionarTodos();

            tabelaCliente.AtualizarRegistros(pessoasFisicas);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {pessoasFisicas.Count} cliente(s)");
        }
    }
}

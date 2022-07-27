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
        private TabelaClientesControl tabelaCliente;
        private readonly ServicoCliente servicoCliente;

        public ControladorCliente(ServicoCliente servicoCliente)
        {
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            TelaCadastroClientesForm tela = new TelaCadastroClientesForm();
            tela.Cliente = new Cliente();

            tela.GravarRegistro = servicoCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarClientes();

        }

        public override void Editar()
        {
            var id = tabelaCliente.ObtemNumeroClienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Cliente primeiro",
                "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCliente.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var clienteSelecionado = resultado.Value;

            TelaCadastroClientesForm tela = new TelaCadastroClientesForm();

            tela.Cliente = clienteSelecionado.Clonar();

            tela.GravarRegistro = servicoCliente.Editar;

            DialogResult resultadoTela = tela.ShowDialog();

            if (resultadoTela == DialogResult.OK)
                CarregarClientes();

        }

        public override void Excluir()
        {
            var id = tabelaCliente.ObtemNumeroClienteSelecionado();
            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCliente.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o cliente?", "Exclusão de Cliente",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCliente.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarClientes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaCliente = new TabelaClientesControl();

            CarregarClientes();

            return tabelaCliente;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCliente();
        }

        private void CarregarClientes()
        {
            var resultado = servicoCliente.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Cliente> clientes = resultado.Value;

                tabelaCliente.AtualizarRegistros(clientes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {clientes.Count} cliente(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Listagem de Cliente",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

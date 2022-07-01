using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    internal class ControladorFuncionario : ControladorBase
    {
        private readonly IRepositorioFuncionario repositorioFuncionario;
        private TabelaFuncionariosControl tabelaFuncionarios;
        private readonly ServicoFuncionario servicoFuncionario;

        public ControladorFuncionario(IRepositorioFuncionario repositorioFuncionario,
            ServicoFuncionario servicoFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            TelaCadastroFuncionariosForm tela = new TelaCadastroFuncionariosForm();
            tela.Funcionario = new Funcionario();

            tela.GravarRegistro = servicoFuncionario.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();

        }

        public override void Editar()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                "Edição de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroFuncionariosForm tela = new TelaCadastroFuncionariosForm();

            tela.Funcionario = funcionarioSelecionado.Clonar();

            tela.GravarRegistro = servicoFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
            
        }

        public override void Excluir()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                "Exclusão de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o funcionário?",
                "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioFuncionario.Excluir(funcionarioSelecionado);
                CarregarFuncionarios();
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaFuncionarios = new TabelaFuncionariosControl();

            CarregarFuncionarios();

            return tabelaFuncionarios;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxFuncionario();
        }

        private Funcionario ObtemFuncionarioSelecionado()
        {
            var id = tabelaFuncionarios.ObtemNumeroFuncionarioSelecionado();

            return (Funcionario)repositorioFuncionario.SelecionarPorId(id);
        }

        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();

            tabelaFuncionarios.AtualizarRegistros(funcionarios);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionário(s)");
        }
    }
}

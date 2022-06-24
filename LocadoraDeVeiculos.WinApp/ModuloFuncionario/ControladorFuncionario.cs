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

        public ControladorFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public override void Inserir()
        {
            TelaCadastroFuncionariosForm tela = new TelaCadastroFuncionariosForm();
            tela.Funcionario = new Funcionario();

            tela.GravarRegistro = repositorioFuncionario.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();

        }

        public override void Editar()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um contato primeiro",
                "Edição de Funcionarioss", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroFuncionariosForm tela = new TelaCadastroFuncionariosForm();

            tela.Funcionario = funcionarioSelecionado.Clonar();

            tela.GravarRegistro = repositorioFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
            
        }

        public override void Excluir()
        {
            Funcionario contatoSelecionado = ObtemFuncionarioSelecionado();

            if (contatoSelecionado == null)
            {
                MessageBox.Show("Selecione um contato primeiro",
                "Exclusão de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a contato?",
                "Exclusão de Funcionarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioFuncionario.Excluir(contatoSelecionado);
                CarregarFuncionarios();
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

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} contato(s)");
        }
    }
}

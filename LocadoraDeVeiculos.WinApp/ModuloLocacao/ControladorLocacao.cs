using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGruposVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private TabelaLocacaoControl tabelaLocacao;
        private readonly ServicoLocacao servicoLocacao;
        private readonly ServicoCliente servicoCliente;
        private readonly ServicoCondutor servicoCondutor;
        private readonly ServicoGrupoVeiculos servicoGrupoVeiculos;
        private readonly ServicoVeiculos servicoVeiculos;
        private readonly ServicoPlanoCobranca servicoPlanoCobranca;
        private readonly ServicoTaxa servicoTaxa;

        public ControladorLocacao(ServicoLocacao servicoLocacao, ServicoCliente servicoCliente, ServicoCondutor servicoCondutor, ServicoGrupoVeiculos servicoGrupoVeiculos, ServicoVeiculos servicoVeiculos, ServicoPlanoCobranca servicoPlanoCobranca, ServicoTaxa servicoTaxa)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoCliente = servicoCliente;
            this.servicoCondutor = servicoCondutor;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
            this.servicoVeiculos = servicoVeiculos;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
            this.servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            TelaCadastroLocacaoForm tela = new TelaCadastroLocacaoForm(
                ObterClientes(),
                ObterCondutores(),
                ObterGrupoVeiculos(),
                ObterVeiculos(),
                ObterPlanoCobrancas(),
                ObterTaxas()
                );
            tela.Locacao = new Locacao();

            tela.GravarRegistro = servicoLocacao.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarLocacaoes();

        }

        public override void Editar()
        {
            var id = tabelaLocacao.ObtemNumeroLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Locacao primeiro",
                "Edição de Locacaoes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultado.Value;

            if (locacaoSelecionada.EstaAlugado == false)
            {
                MessageBox.Show("O veículo já foi devolvido e não pode ser editado",
                "Locação encerrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroLocacaoForm tela = new TelaCadastroLocacaoForm(
                ObterClientes(),
                ObterCondutores(),
                ObterGrupoVeiculos(),
                ObterVeiculos(),
                ObterPlanoCobrancas(),
                ObterTaxas()
                );

            tela.Locacao = locacaoSelecionada;

            tela.GravarRegistro = servicoLocacao.Editar;

            DialogResult resultadoTela = tela.ShowDialog();

            if (resultadoTela == DialogResult.OK)
                CarregarLocacaoes();
        }

        public override void Excluir()
        {
            var id = tabelaLocacao.ObtemNumeroLocacaoSelecionada();
            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro",
                    "Exclusão de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoLocacao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a locação?", "Exclusão de Locacao",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacaoes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaLocacao = new TabelaLocacaoControl();

            CarregarLocacaoes();

            return tabelaLocacao;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxLocacao();
        }

        private void CarregarLocacaoes()
        {
            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                tabelaLocacao.AtualizarRegistros(locacoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} locação(ões)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Listagem de Locação",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<Cliente> ObterClientes()
        {
            var resultado = servicoCliente.SelecionarTodos();
            List<Cliente> lista = new List<Cliente>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }

        private List<Condutor> ObterCondutores()
        {
            var resultado = servicoCondutor.SelecionarTodos();
            List<Condutor> lista = new List<Condutor>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }

        private List<GrupoVeiculos> ObterGrupoVeiculos()
        {
            var resultado = servicoGrupoVeiculos.SelecionarTodos();
            List<GrupoVeiculos> lista = new List<GrupoVeiculos>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }

        private List<Veiculos> ObterVeiculos()
        {
            var resultado = servicoVeiculos.SelecionarTodos();
            List<Veiculos> lista = new List<Veiculos>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }

        private List<PlanoCobranca> ObterPlanoCobrancas()
        {
            var resultado = servicoPlanoCobranca.SelecionarTodos();
            List<PlanoCobranca> lista = new List<PlanoCobranca>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }

        private List<Taxa> ObterTaxas()
        {
            var resultado = servicoTaxa.SelecionarTodos();
            List<Taxa> lista = new List<Taxa>();
            if (resultado.IsSuccess)
                lista = resultado.Value;
            return lista;
        }

        #region Devolução

        public override void RegistrarDevolucao()
        {
            var id = tabelaLocacao.ObtemNumeroLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Locacao primeiro",
                "Devoluções", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultado.Value;
            
            if (locacaoSelecionada.EstaAlugado == false)
            {
                MessageBox.Show("O veículo já foi devolvido",
                "Locação encerrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroDevolucaoForm tela = new TelaCadastroDevolucaoForm(ObterClientes(),
                ObterCondutores(),
                ObterGrupoVeiculos(),
                ObterVeiculos(),
                ObterPlanoCobrancas(),
                ObterTaxas());

            tela.Locacao = locacaoSelecionada;

            tela.GravarRegistro = servicoLocacao.RegistrarDevolucao;

            DialogResult resultadoTela = tela.ShowDialog();

            if (resultadoTela == DialogResult.OK)
                CarregarLocacaoes();
        }

        #endregion

        #region GERADOR DE PDF DA LOCAÇÂO
        public override void GerarPdfLocacao()
        {
            var id = tabelaLocacao.ObtemNumeroLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Locacao primeiro",
                "Edição de Locacaoes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultado.Value;

            string diretorio = @"C:\PDF-LOCAÇÕES\";

            if (!System.IO.Directory.Exists(diretorio))
                System.IO.Directory.CreateDirectory(diretorio);

            var tituloTexto = $"Locação de - {locacaoSelecionada.Condutor}";

            Document doc = new Document(PageSize.A4);
            doc.SetMargins(20, 20, 20, 50);

            string caminhoEArquivo = diretorio + locacaoSelecionada.Condutor.Nome + ".pdf";

            if (File.Exists(caminhoEArquivo) == true)
                File.Delete(caminhoEArquivo);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoEArquivo, FileMode.Create));

            doc.Open();


            Paragraph titulo = new Paragraph();
            titulo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add($"{tituloTexto}\n\n");
            doc.Add(titulo);

            Paragraph paragrafo = new Paragraph("", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12));
            string conteudo = $"\nID.......................: {locacaoSelecionada.Id}\n" +
                               $"Condutor.................: {locacaoSelecionada.Condutor}\n" +
                               $"Veículo..................: {locacaoSelecionada.Veiculo}\n" +
                               $"Grupo....................: {locacaoSelecionada.GrupoVeiculos}\n" +
                               $"Kms Rodados:.............: {locacaoSelecionada.Veiculo.QuilometroPercorrido}\n" +
                               $"Plano....................: {locacaoSelecionada.PlanoCobranca}\n" +
                               $"Data de Locação..........: {locacaoSelecionada.DataLocacao}\n" +
                               $"Data Devolutiva Prevista.: {locacaoSelecionada.DataDevolucaoPrevista}\n" +
                               $"Valor Previsto:..........: {locacaoSelecionada.ValorTotalPrevisto:c}\n\n\n\n\n";
            paragrafo.Add(conteudo);
            doc.Add(paragrafo);

            PdfPTable table1 = new PdfPTable(1);
            table1.AddCell($"\nID interno:\n {locacaoSelecionada.Id}\n\t");
            PdfPTable tableCondutor = new PdfPTable(1);
            table1.AddCell($"\nCondutor: \n{locacaoSelecionada.Condutor}\n\t");

            PdfPTable tableVeiculo = new PdfPTable(1);
            tableVeiculo.AddCell($"Veículo: \n{locacaoSelecionada.Veiculo}\t");

            PdfPTable table2 = new PdfPTable(2);
            table2.AddCell($"Grupo: \n{locacaoSelecionada.GrupoVeiculos}\t");
            table2.AddCell($"Kms Rodados: \n{locacaoSelecionada.Veiculo.QuilometroPercorrido}\t");

            PdfPTable table3 = new PdfPTable(2);
            table3.AddCell($"Plano:  {locacaoSelecionada.PlanoCobranca}\t");
            table3.AddCell($"Valor Previsto:  {locacaoSelecionada.ValorTotalPrevisto:c}\t");

            PdfPTable table4 = new PdfPTable(1);
            table4.AddCell($"Data de locação: {locacaoSelecionada.DataLocacao}\t");

            PdfPTable tableDevolutiva = new PdfPTable(1);
            tableDevolutiva.AddCell($"Data Devolutiva Prevista: {locacaoSelecionada.DataDevolucaoPrevista}\t");

            doc.Add(table1);
            doc.Add(table2);
            doc.Add(table3);
            doc.Add(table4);
            doc.Add(tableCondutor);
            doc.Add(tableDevolutiva);
            doc.Add(tableVeiculo);

            doc.Close();

            // ABRE O Diretório do PDF AUTOMATICAMENTE, ASSIM QUE CRIADO; 

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(diretorio)
            {
                UseShellExecute = true
            };
            p.Start();
            /**/
        }
        #endregion
    }
}

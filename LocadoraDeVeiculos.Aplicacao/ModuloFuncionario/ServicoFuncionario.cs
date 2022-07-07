using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Serilog;

namespace LocadoraDeVeiculos.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private IRepositorioFuncionario repositorioFuncionario;

        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public ValidationResult Inserir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando inserir funcionário... \r\n{@funcionario}", funcionario);

            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Inserir(funcionario);
                Log.Logger.Debug("Funcionário {FuncionarioNome} inserido com sucesso", funcionario.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Funcionário {FuncionarioNome} - {Motivo}",
                        funcionario.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Funcionario funcionario)
        {
            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                repositorioFuncionario.Editar(funcionario);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Funcionario funcionario)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            if (NomeDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            if (UsuarioDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "Login duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorNome(funcionario.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == funcionario.Nome &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }

        private bool UsuarioDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorLogin(funcionario.Login);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login == funcionario.Login &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }
    }
}

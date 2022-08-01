using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm : IRepositorioCliente
    {
        private DbSet<Cliente> clientes;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioClienteOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            clientes = dbContext.Set<Cliente>();
            this.dbContext = dbContext;
        }

        public void Inserir(Cliente novoRegistro)
        {
            clientes.Add(novoRegistro);
        }

        public void Editar(Cliente registro)
        {
            clientes.Update(registro);
        }

        public void Excluir(Cliente registro)
        {
            clientes.Remove(registro);
        }

        public List<Cliente> SelecionarTodos()
        {
            return clientes.ToList();
        }

        public Cliente SelecionarPorId(Guid id)
        {
            return clientes.SingleOrDefault(x => x.Id == id);
        }

        public Cliente SelecionarClientePorNome(string nome)
        {
            return clientes.FirstOrDefault(x => x.Nome == nome);
        }

        public Cliente SelecionarClientePorDocumento(string documento)
        {
            return clientes.FirstOrDefault(x => x.Documento == documento);
        }
    }
}

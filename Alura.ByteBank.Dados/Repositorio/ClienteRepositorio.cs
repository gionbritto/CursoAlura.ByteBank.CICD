using Alura.ByteBank.Dados.Contexto;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Dados.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        //private readonly ByteBankContexto _contexto;
        private readonly List<Cliente> _listaCliente;
        public ClienteRepositorio()
        {
            //_contexto = new ByteBankContexto();            
            var cliente1 = new Cliente
            {
                Id = 1,
                CPF = "307.522.040-09",
                Nome = "André Silva",
                Profissao = "Developer",
                Identificador = Guid.Parse("531e5270-8a80-4a2c-8b20-f10182f728fc")
            };
            var cliente2 = new Cliente
            {
                Id = 2,
                CPF = "510.711.260-91",
                Nome = "João Pedro",
                Profissao = "Developer",
                Identificador = Guid.Parse("20cd1c01-5fbf-40b7-b41b-0341bd38fc32")

            };
            var cliente3 = new Cliente
            {
                Id = 3,
                CPF = "224.182.250-70",
                Nome = "José Neves",
                Profissao = "Atleta De Poker",
                Identificador = Guid.Parse("20cd1c01-5fbf-40b7-b41b-0341bd38fc32")

            };

            _listaCliente = new List<Cliente> { cliente1, cliente2, cliente3 };

        }
        public bool Adicionar(Cliente cliente)
        {
            try
            {
                _listaCliente.Add(cliente);               

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Atualizar(int id, Cliente cliente)
        {

            try
            {
                if (id != cliente.Id)
                {
                    return false;
                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Excluir(int id)
        {
            var cliente = _listaCliente.FirstOrDefault(p => p.Id == id);

            try
            {
                if (cliente == null)
                {
                    return false;
                }
                _listaCliente.Remove(cliente);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Cliente ObterPorId(int id)
        {
            try
            {
                var cliente = _listaCliente.FirstOrDefault(p => p.Id == id);
                if (cliente == null)
                {
                    return null;
                }
                return cliente;
            }
            catch
            {
                throw new Exception($"Erro ao obter cliente com Id = {id}.");
            }
        }

        public Cliente ObterPorGuid(Guid guid)
        {
            try
            {
                var cliente = _listaCliente.FirstOrDefault(p => p.Identificador == guid);
                if (cliente == null)
                {
                    return null;
                }
                return cliente;
            }
            catch
            {
                throw new Exception($"Erro ao obter cliente com Guid = {guid}.");
            }
        }

        public List<Cliente> ObterTodos()
        {
            try
            {
                return _listaCliente.ToList();
            }
            catch
            {
                throw new Exception("Erro ao obter clientes");
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

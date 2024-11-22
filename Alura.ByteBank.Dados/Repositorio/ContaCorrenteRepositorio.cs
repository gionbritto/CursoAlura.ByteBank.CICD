using Alura.ByteBank.Dados.Contexto;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.ByteBank.Dados.Repositorio
{
    public class ContaCorrenteRepositorio : IContaCorrenteRepositorio
    {
        //private readonly ByteBankContexto _contexto;
        private readonly List<ContaCorrente> _listaContas;
        public ContaCorrenteRepositorio()
        {
            //_contexto = new ByteBankContexto();
            _listaContas = new List<ContaCorrente> {
                new ContaCorrente(1, 4159, 1,2, 300,  Guid.Parse("1001b6f8-4fdb-44dd-a63d-850e6bf5e1d3"),  Guid.Parse("00000000-0000-0000-0000-000000000000")),
                new ContaCorrente(2,1789, 1,2, 400,  Guid.Parse("fd3a2250-27d9-48f4-ae89-9eea10a93396"),  Guid.Parse("00000000-0000-0000-0000-000000000000"))
            };

            PreencherVinculos(_listaContas);
        }

        public bool Adicionar(ContaCorrente conta)
        {
            try
            {    //https://docs.microsoft.com/pt-br/ef/core/change-tracking/identity-resolution            
                _listaContas.Add(conta);                

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public bool Atualizar(int id, ContaCorrente conta)
        {

            try
            {
                if (id != conta.Id)
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
            var conta = _listaContas.FirstOrDefault(p => p.Id == id);

            try
            {
                if (conta == null)
                {
                    return false;
                }
                _listaContas.Remove(conta);
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ContaCorrente ObterPorId(int id)
        {
            try
            {
                var conta = _listaContas.FirstOrDefault(p => p.Id == id);
                if (conta == null)
                {
                    return null;
                }
                return conta;
            }
            catch
            {
                throw new Exception($"Erro ao obter conta com Id = {id}.");
            }
        }

        public ContaCorrente ObterPorGuid(Guid guid)
        {
            try
            {
                var conta = _listaContas.FirstOrDefault(p => p.Identificador == guid);
                if (conta == null)
                {
                    return null;
                }
                return conta;
            }
            catch
            {
                throw new Exception($"Erro ao obter conta com Guid = {guid}.");
            }
        }
        public List<ContaCorrente> ObterTodos()
        {
            try
            {
                return _listaContas.ToList();
            }
            catch
            {
                throw new Exception("Erro ao obter conta,");
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private void PreencherVinculos(List<ContaCorrente> listaContas)
        {
            foreach (var conta in listaContas)
            {
                var cliente = new ClienteRepositorio().ObterPorId(conta.ClienteId);
                var agencia = new AgenciaRepositorio().ObterPorId(conta.AgenciaId);
                conta.DefinirCliente(cliente);
                conta.DefinirAgencia(agencia);
            }            
        }
    }
}

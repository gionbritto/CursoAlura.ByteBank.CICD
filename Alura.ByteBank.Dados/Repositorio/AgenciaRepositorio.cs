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
    public class AgenciaRepositorio : IAgenciaRepositorio
    {
        //private readonly ByteBankContexto _contexto;
        private readonly List<Agencia> _listaAgencia;
        public AgenciaRepositorio()
        {
            //_contexto = new ByteBankContexto();
            var agencia1 = new Agencia
            {
                Id = 1,
                Numero = 123,
                Nome = "Agencia Central",
                Endereco = "Rua: Pedro Alvares Cabral,63",
                Identificador = Guid.Parse("1447c0e7-c328-47e0-a39f-116e5ab597b3")
            };
            var agencia2 = new Agencia
            {
                Id = 2,
                Numero = 321,
                Nome = "Agencia Flores",
                Endereco = "Rua: Odete Roitman, 84",
                Identificador = Guid.Parse(" a05e08ca-e501-4719-87c4-a7f95c7f8f15")

            };
        
            _listaAgencia = new List<Agencia> { agencia1, agencia2 };
        }

        public bool Adicionar(Agencia agencia)
        {
            try
            {
                _listaAgencia.Add(agencia);                

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Atualizar(int id, Agencia agencia)
        {

            try
            {
                if (id != agencia.Id)
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
            var agencia = _listaAgencia.FirstOrDefault(p => p.Id == id);

            try
            {
                if (agencia == null)
                {
                    return false;
                }
                _listaAgencia.Remove(agencia);                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Agencia ObterPorId(int id)
        {
            try
            {
                var agencia = _listaAgencia.FirstOrDefault(p => p.Id == id);
                if (agencia == null)
                {
                    throw new Exception($"Erro ao obter agência com Id = {id}.");
                }
                return agencia;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Agencia ObterPorGuid(Guid guid)
        {
            try
            {
                var agencia = _listaAgencia.FirstOrDefault(p => p.Identificador == guid);
                if (agencia == null)
                {
                    return null;
                }
                return agencia;
            }
            catch
            {
                throw new Exception($"Erro ao obter agência com Guid = {guid}.");
            }
        }

        public List<Agencia> ObterTodos()
        {
            try
            {
                return _listaAgencia.ToList();
            }
            catch
            {
                throw new Exception("Erro ao obter Agências.");
            }
        }

        public void Dispose()
        {
            //_contexto.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

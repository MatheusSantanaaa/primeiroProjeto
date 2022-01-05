using Aplicacao.CadastroUsuario.Enumerations;
using Aplicacao.CadastroUsuario.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.CadastroUsuario.DAL
{
    public class ContatosDao : DAO<Cliente, string>
    {
        public ContatosDao() : base()
        { }
        public ContatosDao(string conexao) : base(conexao)
        { }
        public override Cliente Buscar(string chave)
        {
            using (var conn = new SqlConnection(this.Conexao))
            {
                var clienteDB = conn.QueryFirstOrDefault<ClienteDB>(
                    "SELECT * FROM TBContatos WHERE Documento = @Documento", new{Documento = chave});

                var endereco = conn.QueryFirstOrDefault<Endereco>(
                    "SELECT * FROM TBEnderecos WHERE Documento = @Documento", new { Documento = chave });

                var cliente = GetCliente(clienteDB);
                cliente.EnderecoPermanente = endereco;
                return cliente;
            }
        }

        public override void Incluir(Cliente elemento)
        {
            using (var conn = new SqlConnection(this.Conexao))
            {
                //dados do contato
                conn.Execute("INSERT INTO TBContatos (Documento, Nome, DataNascimento, Sexo) " +
                    "VALUES(@Documento, @Nome, @DataNascimento, @Sexo)", new 
                    {
                        Documento = elemento.Documento.Numero,
                        Nome = elemento.Nome,
                        DataNascimento = elemento.DataNascimento,
                        Sexo = elemento.Sexo == Sexos.Masculino ? "M" : "F"
                    });

                //dados do endereço
                var end = elemento.EnderecoPermanente;
                conn.Execute("INSERT INTO TBEnderecos (Documento, Logradouro, Numero, Cidade, Cep)" +
                    "VALUES(@Documento, @Logradouro, @Numero, @Cidade, @Cep)", new 
                    {
                        Documento = elemento.Documento.Numero,
                        Logradouro = end.Logradouro,
                        Numero = end.Numero,
                        Cidade = end.Cidade,
                        Cep = end.Cep
                    });
            }
        }

        public override IEnumerable<Cliente> Listar()
        {
            using (var conn = new SqlConnection(this.Conexao))
            {
                var lista = conn.Query<ClienteDB>("SELECT * FROM TBContatos");
                List<Cliente> clientes = new List<Cliente>();
                foreach (var item in lista)
                {
                    clientes.Add(GetCliente(item));
                }
                return clientes;
            }
        }

        //metodo usado para gerar um objeto cliente a partir de um
        //objeto ClienteDB
        private Cliente GetCliente(ClienteDB clienteDB)
        {
            if (clienteDB != null)
            {
                Cliente cliente = new Cliente();
                if (clienteDB.Documento.Length == 11)
                {
                    cliente.Documento = new DocumentoCPF { Numero = clienteDB.Documento };
                }
                else
                {
                    cliente.Documento = new DocumentoCNPJ { Numero = clienteDB.Documento };
                }

                cliente.Nome = clienteDB.Nome;
                cliente.DataNascimento = clienteDB.DataNascimento;
                cliente.Sexo = clienteDB.Sexo == "M" ? Sexos.Masculino : Sexos.Feminino;

                return cliente;
            }
            return null;
                
               
        }
    }
}

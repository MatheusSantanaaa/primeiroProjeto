using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Models.Models;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Biblioteca.Models.DAL
{
    //DAL - Data Access Layer
    //DAO - Data Access Objects
    public class Dao<T>  where T : class 
    {
        static string conexao = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DbProdutos;Data Source=.\SQLEXPRESS";
        
        //Metodo para adicionar um novo registro
        public long Incluir(T item)
        {
            using(var conn = new SqlConnection(conexao))
            {
                return conn.Insert<T>(item);
            }
        }

        //Método para buscar um registro pelo seu (ID)
        public T Buscar(int id)
        {
            using(var conn = new SqlConnection(conexao))
            {
                return conn.Get<T>(id);
            }
        }

        //Metodo para listar todos os registros
        public IEnumerable<T> Listar()
        {
            using (var conn = new SqlConnection(conexao))
            {
                return conn.GetAll<T>();
            }
        }

        //Metodopara deletar registrar
        public bool Deletar(T item)
        {
            using(var conn = new SqlConnection())
            {
                return conn.Delete<T>(item);
            }
        }
    }
}

using Dapper;
using System;
using System.Data.SqlClient;

namespace CadastroCategorias
{
    class Program
    {
        //String de conexão
        static string conexao = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DbProdutos;Data Source=.\SQLEXPRESS";
        
        //metódo para criar e incluir uma nova categoria no banco de dados
        static void IncluirCategoria()
        {
            Console.Write("Informe uma categoria: ");
            string categoria = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(conexao))
            {
                int registros = connection.Execute("INSERT INTO TBCategorias (DESCRICAO) VALUES(@descricao)",
                    new { descricao = categoria });

                Console.WriteLine($"Registros incluídos: {registros}");
            }


        }

        //Metodo para listar todas as categorias
        static void ListarCategorias()
        {
            using (var command = new SqlConnection(conexao))
            {
                var Categorias = command.Query<Categoria>("SELECT * FROM TBCategorias");

                foreach (var item in Categorias)
                {
                    Console.WriteLine($"Id: {item.Id}");
                    Console.WriteLine($"Descrição: {item.Descricao}");
                    Console.WriteLine(new string('-', 50));
                }
            }
        }

        //Metodo para alterar uma categoria
        static void AlterarCategoria()
        {
            Console.Write("Informe o código da Categoria: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Informe a nova Categoria: ");
            string novaCategoria = Console.ReadLine();

            using (var command = new SqlConnection(conexao))
            {
                var Categorias = command.Execute("UPDATE TBCategorias SET Descricao = @descricao WHERE Id = @id",
                    new { descricao = novaCategoria, id = codigo });

                Console.WriteLine($"Registros alterados: {Categorias}");
            }
        }

        //Metodo que exclui uma categoria
        static void ExcluirCategoria()
        {
            Console.WriteLine("Remover Categoria");
            Console.Write("Informe o código da categoria: ");
            int codigo = int.Parse(Console.ReadLine());

            using (var commnand = new SqlConnection(conexao))
            {
                var remover = commnand.Execute("DELETE FROM TBCategorias WHERE Id = @id",
                    new { id = codigo });

                Console.WriteLine($"Registros excluidos: {remover}");
            }
        }
        static void Main(string[] args)
        {
            //IncluirCategoria();
            //ListarCategorias();
            //AlterarCategoria();
            ExcluirCategoria();
            Console.ReadKey();
        }
    }
}

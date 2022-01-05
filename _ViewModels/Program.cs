using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace _ViewModels
{
    class Program
    { 
        //String de conexão
        static string conexao = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DbProdutos;Data Source=.\SQLEXPRESS";

        static void ListarProdutosVm()
        {
            string sql = @"SELECT 
                            C.Descricao AS Categoria,
                            P.Descricao AS Produto,
                            P.Preco AS Valor
                          FROM 
                            TBCategorias C, TBProdutos P
                          WHERE 
                            C.Id = P.IdCategoria";
            using (var conn = new SqlConnection(conexao))
            {
                var produto = conn.Query<CategoriaProdutoVM>(sql);

                foreach (var item in produto)
                {
                    Console.WriteLine($"Categoria: {item.Categoria}");
                    Console.WriteLine($"Produto: {item.Produto}");
                    Console.WriteLine($"Valor: {item.Valor:c}");
                    Console.WriteLine(new string('-', 40));
                }
            } 
        }
        static void ListarProdutosVM_Proc()
        {
            using (var conn = new SqlConnection(conexao))
            {
                var produto = conn
                    .Query<CategoriaProdutoVM>(
                    "p_Listar_Produtos", commandType: CommandType.StoredProcedure);

                foreach (var item in produto)
                {
                    Console.WriteLine($"Categoria: {item.Categoria}");
                    Console.WriteLine($"Produto: {item.Produto}");
                    Console.WriteLine($"Valor: {item.Valor:c}");
                    Console.WriteLine(new string('-', 40));
                }
            }
        }
        static void Main(string[] args)
        {
            ListarProdutosVM_Proc();
            //ListarProdutosVm();
            Console.ReadKey();
        }
    }
}

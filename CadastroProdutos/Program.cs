using Biblioteca.Models.Models;
using System;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Biblioteca.Models.DAL;

namespace CadastroProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            //IncluirProduto();
            //BuscarProduto();
            ListarProdutos();
            Console.ReadKey();
        }
        
        static void IncluirProduto()
        {
            //Criando uma instancia da classe produto
            var produto = new Produto();

            Console.Write("Informe o Id da categoria: ");
            produto.IdCategoria = int.Parse(Console.ReadLine());

            Console.Write("Informe a descrição: ");
            produto.Descricao = Console.ReadLine();

            Console.Write("Informe o preço do produto: ");
            produto.Preco = double.Parse(Console.ReadLine());


            var Dao = new Dao<Produto>();
            Console.WriteLine($"Registros incluidos {Dao.Incluir(produto)}");
        }
        static void BuscarProduto()
        {
            Console.Write("Informe o Id do produto: ");
            int id = int.Parse(Console.ReadLine());

            var dao = new Dao<Produto>();
            Produto p = dao.Buscar(id);

            Console.WriteLine(p);
        }
        static void ListarProdutos()
        {
            var dao = new Dao<Produto>();
            var lista = dao.Listar();
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }
    }
}

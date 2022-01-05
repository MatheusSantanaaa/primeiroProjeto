using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Biblioteca.Models.Models
{
    [Table("TBProdutos")]
    public class Produto : IEntity
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Descrição: {Descricao}, Preço: {Preco:c}";
        }
    }
}

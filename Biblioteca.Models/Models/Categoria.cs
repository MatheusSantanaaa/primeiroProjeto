using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Biblioteca.Models.Models
{
    [Table("TBCategorias")]
    public class Categoria : IEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.CadastroUsuario.Models
{
    //esta classe recebera informações do
    //banco de dados da forma como estão
    //armazenados
    public class ClienteDB
    {
        public string Documento { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
    }
}

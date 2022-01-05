using Aplicacao.CadastroUsuario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.CadastroUsuario.Models
{
    public class DocumentoCPF : IDocumento
    {
        private string _numero;
        public string Numero 
        {
            get => _numero;
            set => _numero = value.Length == 11 ? value : throw new InvalidOperationException("CPF INVÁLIDO");
        }

        public override string ToString()
        {
            return $"CPF: {this.Numero}";
        }
    }
}

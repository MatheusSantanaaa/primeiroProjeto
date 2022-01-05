using Aplicacao.CadastroUsuario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.CadastroUsuario.Models
{
    public class DocumentoCNPJ : IDocumento
    {
        private string _numero;

        public string Numero 
        {
            get => _numero;
            set => _numero = value.Length == 14 ? value : throw new InvalidOperationException("CNPJ INVÁlIDO");
        }

        public override string ToString()
        {
            return $"CNPJ: {Numero}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aplicacao.CadastroUsuario.Models
{
    public struct Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }

        private string _cep;
        public string Cep
        {
            get => _cep;
            set => _cep = Regex.IsMatch(value, "[0-9]{8}") ? value : throw new FormatException("CEP INVÁLIDO");
        }

        public string Mostrar()
        {
            return $"Logradouro: {Logradouro} {Environment.NewLine}" +
                   $"Numero: {Numero} {Environment.NewLine}" +
                   $"Cidade: {Cidade} {Environment.NewLine}" +
                   $"Cep: {Cep} {Environment.NewLine}";
        }
    }
}

using Aplicacao.CadastroUsuario.Enumerations;
using Aplicacao.CadastroUsuario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.CadastroUsuario.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public IDocumento Documento { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexos Sexo { get; set; }
        public Endereco EnderecoPermanente { get; set; }

        public string Mostrar()
        {
            return $"{Documento} {Environment.NewLine}" +
                   $"Nome: {Nome} {Environment.NewLine}" +
                   $"Data de Nascimento: {DataNascimento:dd/MM/yyyy} {Environment.NewLine}" +
                   $"Sexo: {Sexo} {Environment.NewLine}{Environment.NewLine}" +
                   $"Endereço: {Environment.NewLine}" +
                   $"{EnderecoPermanente.Mostrar()}";
        }
        public override string ToString()
        {
            return this.Nome;
        }
    }
}

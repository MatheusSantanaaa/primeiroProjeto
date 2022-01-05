using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.CadastroUsuario.DAL
{
    public abstract class DAO<T, K> 
    {
        protected string Conexao { get; private set; }

        public DAO() : this(@"Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = DbContatos; Data Source =.\SQLEXPRESS")
        { }
        public DAO(string conexao )
        {
            this.Conexao = conexao;
        }

        public abstract void Incluir(T elemento);
        public abstract T Buscar(K id);
        public abstract IEnumerable<T> Listar();
    }
}

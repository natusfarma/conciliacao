using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALConexao
    {
        //MySqlConnection con = new MySqlConnection("server=localhost; userid=root; database=dbnflocacao");
        private String _stringConexao;
        private MySqlConnection _conexao;
        private MySqlTransaction _transaction;

        public DALConexao(String dadosConexao)
        {
            this._conexao = new MySqlConnection();
            this.StringConexao = dadosConexao;
            this._conexao.ConnectionString = dadosConexao;
        }

        public String StringConexao
        {
            get { return this._stringConexao; }
            set { this._stringConexao = value; }
        }
        public MySqlConnection ObjetoConexao
        {
            get { return this._conexao; }
            set { this._conexao = value; }
        }
        public MySqlTransaction ObjetoTransacao
        {
            get { return this._transaction; }
            set { this._transaction = value; }
        }

        public void IniciarTransacao()
        {
            this._transaction = _conexao.BeginTransaction();

        }
        public void TerminarTransacao()
        {
            this._transaction.Commit();
        }

        public void CancelarTransacao()
        {
            this._transaction.Rollback();
        }

        public void Conectar()
        {
            this._conexao.Open();
        }

        public void Desconectar()
        {
            this._conexao.Close();
        }
    }
}

using MODELO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALAgencia
    {
        private DALConexao conexao;
        public DALAgencia(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloAgencias modelo)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandText = "insert into agencias (filial_id,agencia_num,agencia_banco) values " +
                "(@filialnum,@agencnum,@agencbanc); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@filialnum", modelo.FilialNum);
            cmd.Parameters.AddWithValue("@agencnum", modelo.AgencNum);
            cmd.Parameters.AddWithValue("@agencbanc", modelo.AgencBanc);

            modelo.IdAgenc = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public DataTable ListarAgencias(int filial, string banco)
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select f.filial_id, f.filial_cidade,a.agencia_num " +
                "from filial f inner join agencias a on f.filial_id = a.filial_id " +
                "where f.filial_id=@filial and a.agencia_banco=@banco; ";

            cmd.Parameters.AddWithValue("@filial", filial);
            cmd.Parameters.AddWithValue("@banco", banco);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable ListarAgencias(int filial)
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select a.agencia_num " +
                "from filial f inner join agencias a on f.filial_id = a.filial_id " +
                "where f.filial_id=@filial; ";

            cmd.Parameters.AddWithValue("@filial", filial);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public int VerificoQtdeAgencia(int filial, string banco)  // quantidades de agencia que filial faz deposito
        {
            int qtde;
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select count(a.agencia_num)as nrAgencia " +
                "from filial f inner join agencias a on f.filial_id = a.filial_id " +
                "where f.filial_id=@filial and a.agencia_banco=@banco; ";

            cmd.Parameters.AddWithValue("@filial", filial);
            cmd.Parameters.AddWithValue("@banco", banco);

            conexao.Conectar();
            qtde = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
            return qtde;
        }
        public string RetornaAgencia(int filial, string banco)  // retorna agencia da filial
        {
            string agencia;
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select a.agencia_num " +
                "from filial f inner join agencias a on f.filial_id = a.filial_id " +
                "where f.filial_id=@filial; ";

            cmd.Parameters.AddWithValue("@filial", filial);
            cmd.Parameters.AddWithValue("@banco", banco);

            conexao.Conectar();
            agencia = Convert.ToString(cmd.ExecuteScalar());
            conexao.Desconectar();
            return agencia;
        }
    }
}

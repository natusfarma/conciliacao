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
    public class DALContas
    {
        private DALConexao conexao;
        public DALContas(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloContas modelo)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandText = "insert into contas (conta_num,conta_banco,conta_razao) values " +
                "(@ConNum,@ConBanc,@ConRaz); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@ConNum", modelo.ConNum);
            cmd.Parameters.AddWithValue("@ConBanc", modelo.ConBanc);
            cmd.Parameters.AddWithValue("@ConRaz", modelo.ConRaz);

            modelo.IdConta = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public DataTable Localizar(string busca)
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from contas where (conta_banco like '%" + busca + "%' or conta_num like '%" + busca + "%' ) order by conta_banco ";

            //cmd.Parameters.AddWithValue("@busca", txtBusca.Text);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloContas CarregaModeloConta(int idConta)
        {
            ModeloContas modelo = new ModeloContas();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from contas where conta_id=@idconta; ";

            cmd.Parameters.AddWithValue("@idconta", idConta);

            conexao.Conectar();
            MySqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.IdConta = Convert.ToInt32(registro["conta_id"]);
                modelo.ConNum = Convert.ToString(registro["conta_num"]);
                modelo.ConBanc = Convert.ToString(registro["conta_banco"]);
                modelo.ConRaz = Convert.ToString(registro["conta_razao"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}

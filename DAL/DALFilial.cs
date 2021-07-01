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
    public class DALFilial
    {
        private DALConexao conexao;
        public DALFilial(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloFilial modelo)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandText = "insert into filial (filial_id,filial_cidade) values " +
                "(@numfilial,@cidade); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@cidade", modelo.FilialCidade);
            cmd.Parameters.AddWithValue("@numfilial", modelo.FilialNum);

            cmd.ExecuteNonQuery();
        }
        public DataTable Localizar(string busca)
        {
            DALContas DALobj = new DALContas(conexao);
            return DALobj.Localizar(busca);
        }
    }
}

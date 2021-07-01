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
    public class DALIndicador
    {
        private DALConexao conexao;

        public DALIndicador(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloIndicador modelo)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into indicador (ind_dtmov,ind_filial_id,ind_tipo_erro,ind_dtlanc) values " +
                "(@inddtmov,@indfilial,@indtperro,now()); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@inddtmov", modelo.IndDtMov);
            cmd.Parameters.AddWithValue("@indfilial", modelo.IndFilial);
            cmd.Parameters.AddWithValue("@indtperro", modelo.IndTpErro);
            //cmd.Parameters.AddWithValue("@inddtlanc", modelo.IndDtLanc);

            conexao.Conectar();
            modelo.IdInd = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public DataTable LocalizarDtLancamento(DateTime dtInicio, DateTime dtFim)   // DATA LANÇAMENTO
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select ind_id, ind_dtlanc, ind_dtmov,ind_filial_id, "+
                "(case when ind_tipo_erro = 1 then 'Prot.Duplicado' when ind_tipo_erro = 2 then 'Protocolo' " +
                "when ind_tipo_erro = 3 then 'Data' when ind_tipo_erro = 4 then 'Conta' when ind_tipo_erro = 5 then 'Valor' " +
                "when ind_tipo_erro = 6 then 'Prot.Duplicado-Protocolo' when ind_tipo_erro = 7 then 'Prot.Duplicado-Data' " +
                "when ind_tipo_erro = 8 then 'Prot.Duplicado-Conta' when ind_tipo_erro = 9 then 'Prot.Duplicado-Valor' " +
                "when ind_tipo_erro = 10 then 'Protocolo-Data' when ind_tipo_erro = 11 then 'Protocolo-Conta' " +
                "when ind_tipo_erro = 12 then 'Protocolo-Valor' when ind_tipo_erro = 13 then 'Data-Conta' " +
                "when ind_tipo_erro = 14 then 'Data-Valor' when ind_tipo_erro = 15 then 'Conta-Valor' " +
                "when ind_tipo_erro = 16 then 'Prot.Dupl-Protocolo-Data' when ind_tipo_erro = 17 then 'Prot.Dupl-Protocolo-Conta' " +
                "when ind_tipo_erro = 18 then 'Prot.Dupl-Protocolo-Valor' when ind_tipo_erro = 19 then 'Protocolo-Data-Conta' " +
                "when ind_tipo_erro = 20 then 'Protocolo-Data-Valor' when ind_tipo_erro = 21 then 'Data-Conta-Valor' " +
                "when ind_tipo_erro = 22 then 'Prot.Dupl-Conta-Valor' when ind_tipo_erro = 23 then 'Protocolo-Conta-Valor' " +
                "when ind_tipo_erro = 24 then 'Prot.Dupl-Data-Conta' when ind_tipo_erro = 25 then 'Prot.Dupl-Prot-Data-Conta' " +
                "when ind_tipo_erro = 26 then 'Prot-Data-Conta-Valor' when ind_tipo_erro = 27 then 'Prot.Dupl-Data-Conta-Valor' " +
                "when ind_tipo_erro = 28 then 'Prot.Dupl-Prot-Conta-Valor' when ind_tipo_erro = 29 then 'Tudo errado'end) as tipoErro " +
                "from indicador WHERE DATE(ind_dtlanc) BETWEEN @datai and @dataf";

            cmd.Parameters.AddWithValue("@datai", dtInicio);
            cmd.Parameters.AddWithValue("@dataf", dtFim);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarDtMovimento(DateTime dtInicio, DateTime dtFim)   // DATA MOVIMENTO
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select ind_id, ind_dtlanc, ind_dtmov,ind_filial_id, " +
                "(case when ind_tipo_erro = 1 then 'Prot.Duplicado' when ind_tipo_erro = 2 then 'Protocolo' " +
                "when ind_tipo_erro = 3 then 'Data' when ind_tipo_erro = 4 then 'Conta' when ind_tipo_erro = 5 then 'Valor' " +
                "when ind_tipo_erro = 6 then 'Prot.Duplicado-Protocolo' when ind_tipo_erro = 7 then 'Prot.Duplicado-Data' " +
                "when ind_tipo_erro = 8 then 'Prot.Duplicado-Conta' when ind_tipo_erro = 9 then 'Prot.Duplicado-Valor' " +
                "when ind_tipo_erro = 10 then 'Protocolo-Data' when ind_tipo_erro = 11 then 'Protocolo-Conta' " +
                "when ind_tipo_erro = 12 then 'Protocolo-Valor' when ind_tipo_erro = 13 then 'Data-Conta' " +
                "when ind_tipo_erro = 14 then 'Data-Valor' when ind_tipo_erro = 15 then 'Conta-Valor' " +
                "when ind_tipo_erro = 16 then 'Prot.Dupl-Protocolo-Data' when ind_tipo_erro = 17 then 'Prot.Dupl-Protocolo-Conta' " +
                "when ind_tipo_erro = 18 then 'Prot.Dupl-Protocolo-Valor' when ind_tipo_erro = 19 then 'Protocolo-Data-Conta' " +
                "when ind_tipo_erro = 20 then 'Protocolo-Data-Valor' when ind_tipo_erro = 21 then 'Data-Conta-Valor' " +
                "when ind_tipo_erro = 22 then 'Prot.Dupl-Conta-Valor' when ind_tipo_erro = 23 then 'Protocolo-Conta-Valor' " +
                "when ind_tipo_erro = 24 then 'Prot.Dupl-Data-Conta' when ind_tipo_erro = 25 then 'Prot.Dupl-Prot-Data-Conta' " +
                "when ind_tipo_erro = 26 then 'Prot-Data-Conta-Valor' when ind_tipo_erro = 27 then 'Prot.Dupl-Data-Conta-Valor' " +
                "when ind_tipo_erro = 28 then 'Prot.Dupl-Prot-Conta-Valor' when ind_tipo_erro = 29 then 'Tudo errado'end) as tipoErro " +
                "from indicador  WHERE DATE(ind_dtmov) BETWEEN @datai and @dataf";

            cmd.Parameters.AddWithValue("@datai", dtInicio);
            cmd.Parameters.AddWithValue("@dataf", dtFim);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
    }
}

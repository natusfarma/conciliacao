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
    public class DALErro
    {
        private DALConexao conexao;
        public DALErro(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloErro modelo)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "INSERT INTO erros (err_filial,err_tipoerro,err_valor,err_erroidentificado,err_errocorrigir,err_dtmov) VALUES " +
                "(@errfilial,@errtipoerro,@errvalor,@erridentificado,@errcorrigir,@errdtmov); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@errfilial", modelo.ErrFilial);
            cmd.Parameters.AddWithValue("@errtipoerro", modelo.ErrTipoErro);
            cmd.Parameters.AddWithValue("@errvalor", modelo.ErrValor);
            cmd.Parameters.AddWithValue("@erridentificado", modelo.ErrIdentificado);
            cmd.Parameters.AddWithValue("@errcorrigir", modelo.ErrCorrigir);
            cmd.Parameters.AddWithValue("@errdtmov", modelo.ErrDtMov);

            conexao.Conectar();
            modelo.IdErro = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public DataTable Localizar()
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM erros ;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarMovimento(DateTime dtmov)  // data de lançamentos
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT err_dtmov,err_filial,err_tipoerro,err_valor,err_erroidentificado,err_errocorrigir " +
                "FROM erros where DATE(err_dtmov)=@dtmovimento;";

            cmd.Parameters.AddWithValue("@dtmovimento", dtmov);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;

        }
        public DataTable LocalizarMovimento(int nrfilial, DateTime dtInicio, DateTime dtFim)  // Filial e data de lançamentos
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT err_dtmov,err_filial,err_tipoerro,err_valor,err_erroidentificado,err_errocorrigir " +
                "FROM erros where err_filial=@nrfilial AND DATE(err_dtlanc) BETWEEN @dtinicio AND @dtfim;";

            cmd.Parameters.AddWithValue("@nrfilial", nrfilial);
            cmd.Parameters.AddWithValue("@dtinicio", dtInicio);
            cmd.Parameters.AddWithValue("@dtfim", dtFim);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;

        }
        public DataTable LocalizarMovimento(DateTime dtInicio, DateTime dtFim)
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT err_dtmov,err_filial,err_tipoerro,err_valor,err_erroidentificado,err_errocorrigir " +
                "FROM erros WHERE DATE(err_dtmov) BETWEEN @dtinicio AND @dtfim;";

            cmd.Parameters.AddWithValue("@dtinicio", dtInicio);
            cmd.Parameters.AddWithValue("@dtfim", dtFim);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
    }
}

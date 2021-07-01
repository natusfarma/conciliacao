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
    public class DALConsolidaExtrato
    {
        private DALConexao conexao;
        public DALConsolidaExtrato(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloConsolidaExtrato modelo)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            //cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandText = "insert into consolidaextrato (conta_id,consext_dtlanc,consext_agencia,consext_hist," +
                "consext_protocolo,consext_valorc,consext_valord) values " +
                "(@idconta,@extdrlanc,@extagenc,@exthist,@extprot,@extvalorc,@extvalord); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@idconta", modelo.IdConta);
            cmd.Parameters.AddWithValue("@extdrlanc", modelo.ExtDrLanc);
            cmd.Parameters.AddWithValue("@extagenc", modelo.ExtAgenc);
            cmd.Parameters.AddWithValue("@exthist", modelo.ExtHist);
            cmd.Parameters.AddWithValue("@extprot", modelo.ExtProt);
            cmd.Parameters.AddWithValue("@extvalorc", modelo.ExtValorC);
            cmd.Parameters.AddWithValue("@extvalord", modelo.ExtValorD);

            conexao.Conectar();
            modelo.IdConExt = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void AlterarProtocoloValor(ModeloConsolidaExtrato modelo)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            //cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandText = "UPDATE consolidaextrato SET consext_protocolo=@protocolo, consext_valorc=@valor " +
                          "WHERE id_consext=@idext ;";

            cmd.Parameters.AddWithValue("@idext", modelo.IdConExt);
            cmd.Parameters.AddWithValue("@protocolo", modelo.ExtProt);
            cmd.Parameters.AddWithValue("@valor", modelo.ExtValorC);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void Excluir(int idConta, DateTime dia)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            //cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandText = "DELETE FROM consolidaextrato where conta_id=@conta and consext_dtlanc=@dia ";

            cmd.Parameters.AddWithValue("@conta", idConta);
            cmd.Parameters.AddWithValue("@dia", dia);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void ExcluirValidado(int idConta)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            //cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandText = "DELETE FROM consolidaextrato where consext_valid=1 and conta_id=@conta ";

            cmd.Parameters.AddWithValue("@conta", idConta);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void ValidarEXtrato(int idExtrato)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            //cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandText = "UPDATE consolidaextrato set consext_valid=@validar where id_consext=@idconsext ;";

            cmd.Parameters.AddWithValue("@idconsext", idExtrato);
            cmd.Parameters.AddWithValue("@validar", '1');

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public int VerificaLancamento(int idConta, DateTime dia)
        {
            int qtdeLanc;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT count(id_consext) FROM consolidaextrato " +
                "where conta_id=@conta and consext_dtlanc=@dtmovimento ";

            cmd.Parameters.AddWithValue("@conta", idConta);
            cmd.Parameters.AddWithValue("@dtmovimento", dia);
            

            conexao.Conectar();
            qtdeLanc = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
            return qtdeLanc;
        }
        public DataTable LocalizarSobraExtrato(int idConta)  // EXTRATO NÃO LOCALIZADO NO ITEC
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select e.id_consext,concat(c.conta_num,' - ',c.conta_banco)as conta,e.consext_dtlanc,e.consext_hist, e.consext_agencia, " +
                "e.consext_protocolo,e.consext_valorc,e.consext_valord " +
                "from consolidaextrato e inner join contas c on e.conta_id = c.conta_id " +
                "where consext_valid = 0 and e.conta_id = @conta and consext_valorc > 0;  ";

            cmd.Parameters.AddWithValue("@conta", idConta);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
    }
}

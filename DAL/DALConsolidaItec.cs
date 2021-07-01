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
    public class DALConsolidaItec
    {
        private DALConexao conexao;
        public DALConsolidaItec(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloConsolidaItec modelo)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            //cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandText = "insert into consolidaitec (conta_id,consitec_dtlanc,consitec_hist,consitec_filial," +
                "consitec_dia,consitec_protocolo,consitec_valorc,consitec_valord) values " +
                "(@idconta,@itecdtlanc,@itechist,@itecfilial,@itecdia,@itecprot,@itecvalorc,@itecvalord); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@idconta", modelo.IdConta);
            cmd.Parameters.AddWithValue("@itecdtlanc", modelo.ItecDtLanc);
            cmd.Parameters.AddWithValue("@itechist", modelo.ItecHist);
            cmd.Parameters.AddWithValue("@itecfilial", modelo.ItecFilial);
            cmd.Parameters.AddWithValue("@itecdia", modelo.ItecDia);
            cmd.Parameters.AddWithValue("@itecprot", modelo.ItecProt);
            cmd.Parameters.AddWithValue("@itecvalorc", modelo.ItecValorC);
            cmd.Parameters.AddWithValue("@itecvalord", modelo.ItecValorD);
            //cmd.Parameters.AddWithValue("@itecvalid", modelo.ItecValid);

            conexao.Conectar();
            modelo.IdConsItec = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void AlterarProtocoloValor(ModeloConsolidaItec modelo)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            //cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandText = "UPDATE consolidaitec SET consitec_protocolo=@protocolo, consitec_valorc=@valor " +
                          "WHERE id_constec=@iditec";

            cmd.Parameters.AddWithValue("@iditec", modelo.IdConsItec);
            cmd.Parameters.AddWithValue("@protocolo", modelo.ItecProt);
            cmd.Parameters.AddWithValue("@valor", modelo.ItecValorC);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void Excluir(int idConta, DateTime dia)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM consolidaitec where consitec_dtlanc=@dia and conta_id=@conta ";

            cmd.Parameters.AddWithValue("@conta", idConta);
            cmd.Parameters.AddWithValue("@dia", dia);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void ExcluirValidados(int idConta )
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM consolidaitec where consitec_valid=1 and conta_id=@conta ";

            cmd.Parameters.AddWithValue("@conta", idConta);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void ValidarItec( int idItec)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "UPDATE consolidaitec set consitec_valid=@validar where id_constec=@idconstec ;";

            cmd.Parameters.AddWithValue("@idconstec", idItec);
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
            cmd.CommandText = "SELECT count(id_constec) FROM consolidaitec  " +
                        "where conta_id=@conta and consitec_dtlanc=@dtmovimento ";

            cmd.Parameters.AddWithValue("@conta", idConta);
            cmd.Parameters.AddWithValue("@dtmovimento", dia);

            conexao.Conectar();
            qtdeLanc = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
            return qtdeLanc;
        }
        public DataTable LocalizarProtocoloProtocolo(int idConta) //  TODOS   // ITAU // CEF // BB // CEF  
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT i.id_constec,i.consitec_dtlanc,i.consitec_filial,i.consitec_valorc,i.consitec_protocolo, " +
                    "e.consext_protocolo,e.consext_valorc,e.consext_agencia,e.consext_dtlanc,e.id_consext  " +
                    "FROM consolidaitec i inner join consolidaextrato e on i.conta_id = e.conta_id " +
                    "WHERE i.consitec_valid=0 and e.consext_protocolo LIKE concat('%',consitec_protocolo,'%') and i.consitec_valorc=e.consext_valorc " +
                    "and i.consitec_valorc > 0 and i.conta_id=@conta " +
                    "UNION " +
                    "SELECT i.id_constec,i.consitec_dtlanc,i.consitec_filial,i.consitec_valorc,i.consitec_protocolo, "+
                    "e.consext_protocolo,e.consext_valorc,e.consext_agencia,e.consext_dtlanc,e.id_consext "+
                    "FROM consolidaitec i INNER JOIN consolidaextrato e on i.conta_id = e.conta_id "+
                    "WHERE i.consitec_valid = 0 AND i.consitec_hist LIKE '%Cheques%' and(e.consext_hist like '%bloquea%' or e.consext_hist like '%Desbl%') "+
                    "AND i.consitec_valorc = e.consext_valorc and i.consitec_valorc > 0 and i.conta_id=@conta; ";

            cmd.Parameters.AddWithValue("@conta", idConta);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarProtocoloProtocolo(int idConta, DateTime dtMov) //  TODOS   // ITAU // CEF // BB // CEF  
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT i.id_constec,i.consitec_dtlanc,i.consitec_filial,i.consitec_valorc,i.consitec_protocolo, " +
                    "e.consext_protocolo,e.consext_valorc,e.consext_agencia,e.consext_dtlanc,e.id_consext  " +
                    "FROM consolidaitec i inner join consolidaextrato e on i.conta_id = e.conta_id " +
                    "WHERE i.consitec_valid=0 and e.consext_protocolo LIKE concat('%',consitec_protocolo,'%') and i.consitec_valorc=e.consext_valorc " +
                    "and i.consitec_valorc > 0 and i.conta_id=@conta and i.consitec_dtlanc=@datamov " +
                    "UNION " +
                    "SELECT i.id_constec,i.consitec_dtlanc,i.consitec_filial,i.consitec_valorc,i.consitec_protocolo, " +
                    "e.consext_protocolo,e.consext_valorc,e.consext_agencia,e.consext_dtlanc,e.id_consext " +
                    "FROM consolidaitec i INNER JOIN consolidaextrato e on i.conta_id = e.conta_id " +
                    "WHERE i.consitec_valid = 0 AND i.consitec_hist LIKE '%Cheques%' and(e.consext_hist like '%bloquea%' or e.consext_hist like '%Desbl%') " +
                    "AND i.consitec_valorc = e.consext_valorc and i.consitec_valorc > 0 and i.conta_id=@conta and i.consitec_dtlanc=@datamov; ";

            cmd.Parameters.AddWithValue("@conta", idConta);
            cmd.Parameters.AddWithValue("@datamov", dtMov);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarProtocoloProtocoloBrad(int idConta)  // BRADESCO
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT i.id_constec,i.consitec_dtlanc,i.consitec_filial,i.consitec_valorc,i.consitec_protocolo, " +
                    "e.consext_protocolo,e.consext_valorc,e.consext_agencia,e.consext_dtlanc,e.id_consext  " +
                    "FROM consolidaitec i inner join consolidaextrato e on i.conta_id = e.conta_id " +
                    "WHERE e.consext_protocolo LIKE concat('%',consitec_protocolo,'%') and i.consitec_valorc=e.consext_valorc " +
                    "and i.consitec_valorc > 0 and i.conta_id=@conta; ";

            cmd.Parameters.AddWithValue("@conta", idConta);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarProtocoloProtocoloValor(int idConta)  // PROTOCOLO X PROTOCO <> VALOR
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT distinct i.id_constec,i.consitec_dtlanc,i.consitec_filial,i.consitec_valorc,i.consitec_protocolo,  " +
                    "e.consext_protocolo,e.consext_valorc,e.consext_agencia,e.consext_dtlanc,e.id_consext  " +
                    "FROM consolidaitec i inner join consolidaextrato e on i.conta_id = e.conta_id " +
                    "WHERE i.consitec_protocolo=e.consext_protocolo and i.consitec_valorc <> e.consext_valorc and i.conta_id=@conta; ";

            cmd.Parameters.AddWithValue("@conta", idConta);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarItecNaoExtrato(int idConta)  // ITEC NÃO LOCALIZADO NO EXTRATO
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select i.id_constec,concat(c.conta_num,' - ',c.conta_banco)as conta,i.consitec_dtlanc," +
                "i.consitec_hist,i.consitec_filial,i.consitec_dia,i.consitec_protocolo,i.consitec_valorc " +
                "from consolidaitec i inner join contas c on i.conta_id = c.conta_id " +
                "where consitec_valid=0 AND i.conta_id=@conta and consitec_valorc > 0;  ";

            cmd.Parameters.AddWithValue("@conta", idConta);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarProtocolosNaoValidados(int idConta,string valor)  // PROTOCOLOS DO NÃO LOCALIZADOS NO EXTRATO => LANÇAMENTOS DE CRÉDITOS
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select id_constec as Nrid,consitec_dtlanc as Data_Lacto,consitec_hist as Historico, " +
                                "consitec_filial as Filial_Ag,consitec_dia as Data,consitec_protocolo as Protocolo, " +
                                "consitec_valorc as ValorCredito,'Itec'as origem " +
                                "from consolidador.consolidaitec " +
                                "where (consitec_filial like '%" + valor + "' or consitec_protocolo like '%" + valor + "%') " +
                                "and consitec_valid = 0 and consitec_valorc > 0 AND consolidador.consolidaitec.conta_id=@conta " +
                                "union " +
                                "SELECT id_consext as Nrid,consext_dtlanc as Data_Lacto,consext_hist as Historico, " +
                                "consext_agencia as Filial_Ag,consext_dtlanc as Data,consext_protocolo as Protocolo,  " +
                                "consext_valorc as ValorCredito,'Extrato'as origem " +
                                "FROM consolidador.consolidaextrato " +
                                "where (consext_agencia like '%" + valor + "' or consext_protocolo like '%" + valor + "%') " +
                                "and consext_valid = 0 and consext_valorc > 0 and consext_hist not like '%bloquea%' " +
                                "and consolidador.consolidaextrato.conta_id=@conta order by ValorCredito desc;  ";

            cmd.Parameters.AddWithValue("@conta", idConta);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarProtocolosNaoValidados(int idConta, string valor,DateTime dtmov)  // PROTOCOLOS DO NÃO LOCALIZADOS NO EXTRATO => LANÇAMENTOS DE CRÉDITOS
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select id_constec as Nrid,consitec_dtlanc as Data_Lacto,consitec_hist as Historico, " +
                                "consitec_filial as Filial_Ag,consitec_dia as Data,consitec_protocolo as Protocolo, " +
                                "consitec_valorc as ValorCredito,'Itec'as origem " +
                                "from consolidador.consolidaitec " +
                                "where (consitec_filial like '%" + valor + "' or consitec_protocolo like '%" + valor + "%') and consitec_dtlanc=@datamov " +
                                "and consitec_valid = 0 and consitec_valorc > 0 AND consolidador.consolidaitec.conta_id=@conta " +
                                "union " +
                                "SELECT id_consext as Nrid,consext_dtlanc as Data_Lacto,consext_hist as Historico, " +
                                "consext_agencia as Filial_Ag,consext_dtlanc as Data,consext_protocolo as Protocolo,  " +
                                "consext_valorc as ValorCredito,'Extrato'as origem " +
                                "FROM consolidador.consolidaextrato " +
                                "where (consext_agencia like '%" + valor + "' or consext_protocolo like '%" + valor + "%') and consext_dtlanc=@datamov " +
                                "and consext_valid = 0 and consext_valorc > 0 and consext_hist not like '%bloquea%' " +
                                "and consolidador.consolidaextrato.conta_id=@conta order by ValorCredito desc;  ";

            cmd.Parameters.AddWithValue("@conta", idConta);
            cmd.Parameters.AddWithValue("@datamov", dtmov);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarProtocolosNaoValidadosPorAgencia(int idConta,string nrfilial,decimal valor ,string busca,string agencias)  // PROTOCOLOS DO NÃO LOCALIZADOS NO EXTRATO FILTRANDO POR VALOR E AGENCIAS DA CIDADE
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select c.id_constec as Nrid,c.consitec_dtlanc as Data_Lacto,c.consitec_hist as Historico, " +
                "c.consitec_filial as Filial_Ag,c.consitec_dia as Data,c.consitec_protocolo as Protocolo, " +
                "c.consitec_valorc as ValorCredito,'Itec'as origem " +
                "from consolidaitec c inner join filial f on f.filial_id=c.consitec_filial " +
                "where (consitec_filial like '%' or consitec_protocolo like '%" + busca + "%') " +
                "and c.consitec_valid = 0 and c.consitec_valorc=@valor AND c.conta_id=@conta and c.consitec_filial=@filial " +  //filial
                "union  " +
                "SELECT id_consext as Nrid,consext_dtlanc as Data_Lacto,consext_hist as Historico, " +
                "consext_agencia as Filial_Ag,consext_dtlanc as Data,consext_protocolo as Protocolo,  " +
                "consext_valorc as ValorCredito,'Extrato'as origem " +
                "FROM consolidaextrato " +
                "where (consext_agencia like '%' or consext_protocolo like '%" + busca + "%') " +
                "and consext_valid = 0 and consext_valorc > 0 and consext_hist not like '%bloquea%' " +
                "and conta_id=@conta and consext_valorc=@valor and consext_agencia in ("+agencias+") ;";

            cmd.Parameters.AddWithValue("@conta", idConta);
            cmd.Parameters.AddWithValue("@filial", nrfilial);
            cmd.Parameters.AddWithValue("@valor", valor);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarProtocolosNaoValidadosAgencia(int idConta, string nrfilial, decimal valor, string busca, string agencias)  // PROTOCOLOS DO NÃO LOCALIZADOS NO EXTRATO FILTRANDO POR VALOR E AGENCIAS DA CIDADE
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select c.id_constec as Nrid,c.consitec_dtlanc as Data_Lacto,c.consitec_hist as Historico, " +
                "c.consitec_filial as Filial_Ag,c.consitec_dia as Data,c.consitec_protocolo as Protocolo, " +
                "c.consitec_valorc as ValorCredito,'Itec'as origem " +
                "from consolidaitec c inner join filial f on f.filial_id=c.consitec_filial " +
                "where (consitec_filial like '%' or consitec_protocolo like '%" + busca + "%') " +
                "and c.consitec_valid = 0 and c.consitec_valorc=@valor AND c.conta_id=@conta and c.consitec_filial=@filial " +  //filial
                "union  " +
                "SELECT id_consext as Nrid,consext_dtlanc as Data_Lacto,consext_hist as Historico, " +
                "consext_agencia as Filial_Ag,consext_dtlanc as Data,consext_protocolo as Protocolo,  " +
                "consext_valorc as ValorCredito,'Extrato'as origem " +
                "FROM consolidaextrato " +
                "where (consext_agencia like '%' or consext_protocolo like '%" + busca + "%') " +
                "and consext_valid = 0 and consext_valorc > 0 and consext_hist not like '%bloquea%' " +
                "and conta_id=@conta and consext_valorc=@valor and consext_agencia=@agencia ;";

            cmd.Parameters.AddWithValue("@conta", idConta);
            cmd.Parameters.AddWithValue("@filial", nrfilial);
            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@agencia", agencias);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarLancamentosDebitos(int idConta)  // LISTAR TODOS OS LANÇAMENTOS DE DÉBITOS NO ITEC E NO EXTRATO
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select id_constec as Nrid,consitec_dtlanc as Data_Lacto,consitec_hist as Historico, "+
                "consitec_filial as Filial_Ag,consitec_dia as Data,consitec_protocolo as Protocolo, " +
                "consitec_valorc as ValorCredito,consitec_valord as ValorDebito,'Itec'as origem " +
                "from consolidador.consolidaitec where consitec_valid = 0 and consitec_valord >0 " +
                "AND consolidador.consolidaitec.conta_id=@conta " +
                "union " +
                "SELECT id_consext as Nrid,consext_dtlanc as Data_Lacto,consext_hist as Historico, " +
                "consext_agencia as Filial_Ag,consext_dtlanc as Data,consext_protocolo as Protocolo,  " +
                "consext_valorc as ValorCredito,consext_valord as ValorDebito,'Extrato'as origem " +
                "FROM consolidador.consolidaextrato where consext_valid = 0 and consext_valord > 0 " +
                "and consolidador.consolidaextrato.conta_id=@conta order by ValorDebito desc;  ";

            cmd.Parameters.AddWithValue("@conta", idConta);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarChequesProtocolosNaoValidados(int idConta, string valor)  // CHEQUES PROTOCOLOS DO NÃO LOCALIZADOS NO EXTRATO => LANÇAMENTOS DE CRÉDITOS
        {
            DataTable tabela = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select id_constec as Nrid,consitec_dtlanc as Data_Lacto,consitec_hist as Historico, " +
                                "consitec_filial as Filial_Ag,consitec_dia as Data,consitec_protocolo as Protocolo, " +
                                "consitec_valorc as ValorCredito,'Itec'as origem " +
                                "from consolidaitec " +
                                "where (consitec_filial like '%" + valor + "' or consitec_protocolo like '%" + valor + "%') and consitec_hist like '%Cheques%' " +
                                "and consitec_valid = 0 and consitec_valorc > 0 AND conta_id=@conta " +
                                "union " +
                                "SELECT id_consext as Nrid,consext_dtlanc as Data_Lacto,consext_hist as Historico, " +
                                "consext_agencia as Filial_Ag,consext_dtlanc as Data,consext_protocolo as Protocolo,  " +
                                "consext_valorc as ValorCredito,'Extrato'as origem " +
                                "FROM consolidaextrato " +
                                "where (consext_agencia like '%" + valor + "' or consext_protocolo like '%" + valor + "%') " +
                                "and consext_valid = 0 and consext_valorc > 0 and (consext_hist like '%bloquea%' or consext_hist like '%Desbl%') " +
                                "and conta_id=@conta order by ValorCredito desc;  ";

            cmd.Parameters.AddWithValue("@conta", idConta);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tabela);
            return tabela;
        }
    }
}

using DAL;
using MODELO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLConsolidaItec
    {
        private DALConexao conexao;
        public BLLConsolidaItec(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloConsolidaItec modelo)
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            DALobj.Incluir(modelo);
        }
        public void AlterarProtocoloValor(ModeloConsolidaItec modelo)
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            DALobj.AlterarProtocoloValor(modelo);
        }
        public void Excluir(int idConta, DateTime dia)
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            DALobj.Excluir(idConta, dia);
        }
        public void ExcluirValidados(int idConta)
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            DALobj.ExcluirValidados(idConta);
        }
        public void ValidarItec(int idItec)
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            DALobj.ValidarItec(idItec);
        }
        public int VerificaLancamento(int idConta, DateTime dia)
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            return DALobj.VerificaLancamento(idConta, dia);
        }
        public DataTable LocalizarProtocoloProtocolo(int idConta)  // ITAU // CEF // BB // CEF
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            return DALobj.LocalizarProtocoloProtocolo(idConta);
        }
        public DataTable LocalizarProtocoloProtocolo(int idConta, DateTime dtMov) //  TODOS   // ITAU // CEF // BB // CEF  
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            return DALobj.LocalizarProtocoloProtocolo(idConta,dtMov);
        }
        public DataTable LocalizarProtocoloProtocoloBrad(int idConta)  // BRADESCO
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            return DALobj.LocalizarProtocoloProtocoloBrad(idConta);
        }
        public DataTable LocalizarProtocoloProtocoloValor(int idConta)  // PROTOCOLO X PROTOCO <> VALOR
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            return DALobj.LocalizarProtocoloProtocoloValor(idConta);
        }
        public DataTable LocalizarItecNaoExtrato(int idConta)  // ITEC NÃO LOCALIZADO NO EXTRATO
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            return DALobj.LocalizarItecNaoExtrato(idConta);
        }
        public DataTable LocalizarProtocolosNaoValidados(int idConta,string valor)  // PROTOCOLOS DO NÃO LOCALIZADOS NO EXTRATO => LANÇAMENTOS DE CRÉDITOS
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            return DALobj.LocalizarProtocolosNaoValidados(idConta,valor);
        }
        public DataTable LocalizarProtocolosNaoValidados(int idConta, string valor, DateTime dtmov)  // PROTOCOLOS DO NÃO LOCALIZADOS NO EXTRATO => LANÇAMENTOS DE CRÉDITOS
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            return DALobj.LocalizarProtocolosNaoValidados(idConta, valor,dtmov);
        }
        public DataTable LocalizarProtocolosNaoValidadosPorAgencia(int idConta, string nrfilial, decimal valor, string busca, string agencias)  // PROTOCOLOS DO NÃO LOCALIZADOS NO EXTRATO FILTRANDO POR VALOR E AGENCIAS DA CIDADE
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            return DALobj.LocalizarProtocolosNaoValidadosPorAgencia(idConta, nrfilial,valor,busca,agencias);
        }
        public DataTable LocalizarProtocolosNaoValidadosAgencia(int idConta, string nrfilial, decimal valor, string busca, string agencias)  // PROTOCOLOS DO NÃO LOCALIZADOS NO EXTRATO FILTRANDO POR VALOR E AGENCIAS DA CIDADE
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            return DALobj.LocalizarProtocolosNaoValidadosAgencia(idConta, nrfilial, valor, busca, agencias);
        }
        public DataTable LocalizarLancamentosDebitos(int idConta)  // LISTAR TODOS OS LANÇAMENTOS DE DÉBITOS NO ITEC E NO EXTRATO
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            return DALobj.LocalizarLancamentosDebitos(idConta);
        }
        public DataTable LocalizarChequesProtocolosNaoValidados(int idConta, string valor)  // CHEQUES PROTOCOLOS DO NÃO LOCALIZADOS NO EXTRATO => LANÇAMENTOS DE CRÉDITOS
        {
            DALConsolidaItec DALobj = new DALConsolidaItec(conexao);
            return DALobj.LocalizarChequesProtocolosNaoValidados(idConta, valor);
        }
    }
}

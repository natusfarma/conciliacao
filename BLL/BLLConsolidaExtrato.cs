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
    public class BLLConsolidaExtrato
    {
        private DALConexao conexao;
        public BLLConsolidaExtrato(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloConsolidaExtrato modelo)
        {
            DALConsolidaExtrato DALobj = new DALConsolidaExtrato(conexao);
            DALobj.Incluir(modelo);
        }
        public void AlterarProtocoloValor(ModeloConsolidaExtrato modelo)
        {
            DALConsolidaExtrato DALobj = new DALConsolidaExtrato(conexao);
            DALobj.AlterarProtocoloValor(modelo);
        }
        public void Excluir(int idConta, DateTime dia)
        {
            DALConsolidaExtrato DALobj = new DALConsolidaExtrato(conexao);
            DALobj.Excluir(idConta,dia);
        }
        public void ExcluirValidado(int idConta)
        {
            DALConsolidaExtrato DALobj = new DALConsolidaExtrato(conexao);
            DALobj.ExcluirValidado(idConta);
        }
        public void ValidarEXtrato(int idExtrato)
        {
            DALConsolidaExtrato DALobj = new DALConsolidaExtrato(conexao);
            DALobj.ValidarEXtrato(idExtrato);
        }
        public int VerificaLancamento(int idConta, DateTime dia)
        {
            DALConsolidaExtrato DALobj = new DALConsolidaExtrato(conexao);
            return DALobj.VerificaLancamento(idConta,dia);
        }
        public DataTable LocalizarSobraExtrato(int idConta)  // EXTRATO NÃO LOCALIZADO NO ITEC
        {
            DALConsolidaExtrato DALobj = new DALConsolidaExtrato(conexao);
            return DALobj.LocalizarSobraExtrato(idConta);
        }
        
    }
}

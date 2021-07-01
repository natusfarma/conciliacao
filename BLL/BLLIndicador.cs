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
    public class BLLIndicador
    {
        private DALConexao conexao;
        public BLLIndicador(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloIndicador modelo)
        {
            DALIndicador DALobj = new DALIndicador(conexao);
            DALobj.Incluir(modelo);
        }
        public DataTable LocalizarDtLancamento(DateTime dtInicio, DateTime dtFim)   // DATA LANÇAMENTO
        {
            DALIndicador DALobj = new DALIndicador(conexao);
            return DALobj.LocalizarDtLancamento(dtInicio,dtFim);
        }
        public DataTable LocalizarDtMovimento(DateTime dtInicio, DateTime dtFim)   // DATA MOVIMENTO
        {
            DALIndicador DALobj = new DALIndicador(conexao);
            return DALobj.LocalizarDtMovimento(dtInicio, dtFim);
        }
    }
}

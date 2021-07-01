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
    public class BLLErro
    {
        private DALConexao conexao;
        public BLLErro(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloErro modelo)
        {
            DALErro DALobj = new DALErro(conexao);
            DALobj.Incluir(modelo);
        }
        public DataTable Localizar()
        {
            DALErro DALobj = new DALErro(conexao);
            return DALobj.Localizar();
        }
        public DataTable LocalizarMovimento(DateTime dtmov)  // data de lançamentos
        {
            DALErro DALobj = new DALErro(conexao);
            return DALobj.LocalizarMovimento(dtmov);
        }
        public DataTable LocalizarMovimento(int nrfilial, DateTime dtInicio, DateTime dtFim)  // Filial e data de lançamentos
        {
            DALErro DALobj = new DALErro(conexao);
            return DALobj.LocalizarMovimento(nrfilial,dtInicio,dtFim);
        }
        public DataTable LocalizarMovimento(DateTime dtInicio, DateTime dtFim)
        {
            DALErro DALobj = new DALErro(conexao);
            return DALobj.LocalizarMovimento(dtInicio,dtFim);
        }
    }
}

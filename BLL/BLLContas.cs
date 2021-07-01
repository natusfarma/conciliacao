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
    public class BLLContas
    {
        private DALConexao conexao;
        public BLLContas(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloContas modelo)
        {
            DALContas DALobj = new DALContas(conexao);
            DALobj.Incluir(modelo);
        }
        public DataTable Localizar(string busca)
        {
            DALContas DALobj = new DALContas(conexao);
            return DALobj.Localizar(busca);
        }
        public ModeloContas CarregaModeloContas(int idConta)
        {
            DALContas DALobj = new DALContas(conexao);
            return DALobj.CarregaModeloConta(idConta);
        }
    }
}

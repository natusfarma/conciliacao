using DAL;
using MODELO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLFilial
    {
        private DALConexao conexao;
        public BLLFilial(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloFilial modelo)
        {
            DALFilial DALobj = new DALFilial(conexao);
            DALobj.Incluir(modelo);
        }
    }
}

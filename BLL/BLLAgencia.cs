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
    public class BLLAgencia
    {
        private DALConexao conexao;
        public BLLAgencia(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloAgencias modelo)
        {
            DALAgencia DALobj = new DALAgencia(conexao);
            DALobj.Incluir(modelo);
        }
        public DataTable ListarAgencias(int filial, string banco)
        {
            DALAgencia DALobj = new DALAgencia(conexao);
            return DALobj.ListarAgencias(filial, banco);
        }
        public DataTable ListarAgencias(int filial)
        {
            DALAgencia DALobj = new DALAgencia(conexao);
            return DALobj.ListarAgencias(filial);
        }
        public int VerificoQtdeAgencia(int filial, string banco)  // quantidades de agencia que filial faz deposito
        {
            DALAgencia DALobj = new DALAgencia(conexao);
            return DALobj.VerificoQtdeAgencia(filial, banco);
        }
        public string RetornaAgencia(int filial, string banco)  // retorna agencia da filial
        {
            DALAgencia DALobj = new DALAgencia(conexao);
            return DALobj.RetornaAgencia(filial, banco);
        }
    }
}

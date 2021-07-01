using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ModeloContas
    {
        private int conta_id;
        public int IdConta
        {
            get { return this.conta_id; }
            set { this.conta_id = value; }
        }
        private string conta_num;
        public string ConNum
        {
            get { return this.conta_num; }
            set { this.conta_num = value; }
        }
        private string conta_banco;
        public string ConBanc
        {
            get { return this.conta_banco; }
            set { this.conta_banco = value; }
        }
        private string conta_razao;
        public string ConRaz
        {
            get { return this.conta_razao; }
            set { this.conta_razao = value; }
        }
        public ModeloContas()
        {

        }
        public ModeloContas(int idconta, string connum, string conbanc, string conraz)
        {
            this.IdConta = idconta;
            this.ConNum = connum;
            this.ConBanc = conbanc;
            this.ConRaz = conraz;
        }
    }
}

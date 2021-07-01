using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ModeloAgencias
    {
        private int agencia_id;
        public int IdAgenc
        {
            get { return this.agencia_id; }
            set { this.agencia_id = value; }
        }
        private int filial_id;
        public int FilialNum
        {
            get { return this.filial_id; }
            set { this.filial_id = value; }
        }
        private string agencia_num;
        public string AgencNum
        {
            get { return this.agencia_num; }
            set { this.agencia_num = value; }
        }
        private string agencia_banco;
        public string AgencBanc
        {
            get { return this.agencia_banco; }
            set { this.agencia_banco = value; }
        }
        public ModeloAgencias()
        {

        }
        public ModeloAgencias(int idagenc, int filialnum, string agencnum, string agencbanc)
        {
            this.IdAgenc = idagenc;
            this.FilialNum = filialnum;
            this.AgencNum = agencnum;
            this.AgencBanc = agencbanc;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ModeloFilial
    {
        private int filial_id;
        public int FilialNum
        {
            get { return this.filial_id; }
            set { this.filial_id = value; }
        }
        private string filial_cidade;
        public string FilialCidade
        {
            get { return this.filial_cidade; }
            set { this.filial_cidade = value; }
        }
        public ModeloFilial()
        {

        }
        public ModeloFilial(int filialnum, string filialcidade)
        {
            this.FilialNum = filialnum;
            this.FilialCidade = filialcidade;
        }
    }
}

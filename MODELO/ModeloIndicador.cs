using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ModeloIndicador
    {
        private int ind_id;
        public int IdInd
        {
            get { return this.ind_id; }
            set { this.ind_id = value; }
        }
        private DateTime ind_dtmv;
        public DateTime IndDtMov
        {
            get { return this.ind_dtmv; }
            set { this.ind_dtmv = value; }
        }
        private int ind_filial_id;
        public int IndFilial
        {
            get { return this.ind_filial_id; }
            set { this.ind_filial_id = value; }
        }        
        private string ind_tipo_erro;
        public string IndTpErro
        {
            get { return this.ind_tipo_erro; }
            set { this.ind_tipo_erro = value; }
        }
        private DateTime ind_dtlanc;
        public DateTime IndDtLanc
        {
            get { return this.ind_dtlanc; }
            set { this.ind_dtlanc = value; }
        }
        public ModeloIndicador()
        {

        }
        public ModeloIndicador(int idind, DateTime inddtmov, int indfilial, string indtperro, DateTime inddtlanc)
        {
            this.IdInd = idind;
            this.IndDtMov = inddtmov;
            this.IndFilial = indfilial;
            this.IndTpErro = indtperro;
            this.IndDtLanc = inddtlanc;

        }
    }
}

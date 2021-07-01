using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ModeloConsolidaExtrato
    {
        private int consext_id;
        public int IdConExt
        {
            get { return this.consext_id; }
            set { this.consext_id = value; }
        }
        private int conta_id;
        public int IdConta
        {
            get { return this.conta_id; }
            set { this.conta_id = value; }
        }
        private DateTime consext_dtlanc;
        public DateTime ExtDrLanc
        {
            get { return this.consext_dtlanc; }
            set { this.consext_dtlanc = value; }
        }
        private string consext_agencia;
        public string ExtAgenc
        {
            get { return this.consext_agencia; }
            set { this.consext_agencia = value; }
        }
        private string consext_hist;
        public string ExtHist
        {
            get { return this.consext_hist; }
            set { this.consext_hist = value; }
        }
        private decimal consext_protocolo;
        public decimal ExtProt
        {
            get { return this.consext_protocolo; }
            set { this.consext_protocolo = value; }
        }
        private decimal consext_valorc;
        public decimal ExtValorC
        {
            get { return this.consext_valorc; }
            set { this.consext_valorc = value; }
        }
        private decimal consext_valord;
        public decimal ExtValorD
        {
            get { return this.consext_valord; }
            set { this.consext_valord = value; }
        }
        private string consext_valid;
        public string ExtValid
        {
            get { return this.consext_valid; }
            set { this.consext_valid = value; }
        }
        public ModeloConsolidaExtrato()
        {

        }
        public ModeloConsolidaExtrato(int idconext, int idconta, DateTime extdrlanc, string extagenc, 
            string exthist, decimal extprot, decimal extvalorc, decimal extvalord, string extvalid)
        {
            this.IdConExt = idconext;
            this.IdConta = idconta;
            this.ExtDrLanc = extdrlanc;
            this.ExtAgenc = extagenc;
            this.ExtHist = exthist;
            this.ExtProt = extprot;
            this.ExtValorC = extvalorc;
            this.ExtValorD = extvalord;
            this.ExtValid = extvalid;

        }
    }
}

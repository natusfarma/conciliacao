using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ModeloConsolidaItec
    {
        private int consitec_id;
        public int IdConsItec
        {
            get { return this.consitec_id; }
            set { this.consitec_id = value; }
        }
        private int conta_id;
        public int IdConta
        {
            get { return this.conta_id; }
            set { this.conta_id = value; }
        }
        private DateTime consitec_dtlanc;
        public DateTime ItecDtLanc
        {
            get { return this.consitec_dtlanc; }
            set { this.consitec_dtlanc = value; }
        }
        private string consitec_hist;
        public string ItecHist
        {
            get { return this.consitec_hist; }
            set { this.consitec_hist = value; }
        }
        private int consitec_filial;
        public int ItecFilial
        {
            get { return this.consitec_filial; }
            set { this.consitec_filial = value; }
        }
        private DateTime consitec_dia;
        public DateTime ItecDia
        {
            get { return this.consitec_dia; }
            set { this.consitec_dia = value; }
        }
        private decimal consitec_protocolo;
        public decimal ItecProt
        {
            get { return this.consitec_protocolo; }
            set { this.consitec_protocolo = value; }
        }
        private decimal consitec_valorc;
        public decimal ItecValorC
        {
            get { return this.consitec_valorc; }
            set { this.consitec_valorc = value; }
        }
        private decimal consitec_valord;
        public decimal ItecValorD
        {
            get { return this.consitec_valord; }
            set { this.consitec_valord = value; }
        }
        private string consitec_valid;
        public string ItecValid
        {
            get { return this.consitec_valid; }
            set { this.consitec_valid = value; }
        }
        public ModeloConsolidaItec()
        {

        }
        public ModeloConsolidaItec(int idconsitec, int idconta, DateTime itecdtlanc, string itechist, int itecfilial,
            DateTime itecdia, decimal itecprot, decimal itecvalorc, decimal itecvalord, string itecvalid)
        {
            this.IdConsItec = idconsitec;
            this.IdConta = idconta;
            this.ItecDtLanc = itecdtlanc;
            this.ItecHist = itechist;
            this.ItecFilial = itecfilial;
            this.ItecDia = itecdia;
            this.ItecProt = itecprot;
            this.ItecValorC = itecvalorc;
            this.ItecValorD = itecvalord;
            this.ItecValid = itecvalid;

        }
    }
}

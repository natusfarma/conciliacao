using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ModeloErro
    {
        private int err_id;
        public int IdErro
        {
            get { return this.err_id; }
            set { this.err_id = value; }
        }
        private int err_filial;
        public int ErrFilial
        {
            get { return this.err_filial; }
            set { this.err_filial = value; }
        }
        private string err_tipoerro;
        public string ErrTipoErro
        {
            get { return this.err_tipoerro; }
            set { this.err_tipoerro = value; }
        }
        private decimal err_valor;
        public decimal ErrValor
        {
            get { return this.err_valor; }
            set { this.err_valor = value; }
        }
        private string err_erroidentificado;
        public string ErrIdentificado
        {
            get { return this.err_erroidentificado; }
            set { this.err_erroidentificado = value; }
        }
        private string err_errocorrigir;
        public string ErrCorrigir
        {
            get { return this.err_errocorrigir; }
            set { this.err_errocorrigir = value; }
        }
        private DateTime err_dtmov;
        public DateTime ErrDtMov
        {
            get { return this.err_dtmov; }
            set { this.err_dtmov = value; }
        }
        public ModeloErro()
        {

        }
        public ModeloErro(int iderro, int errfilial, string errtipoerro, decimal errovalor,string erroidentificado,string errcorrigir, DateTime errdtmov)
        {
            this.IdErro = iderro;
            this.ErrFilial = errfilial;
            this.ErrTipoErro = errtipoerro;
            this.ErrValor = errovalor;
            this.ErrIdentificado = erroidentificado;
            this.ErrCorrigir = errcorrigir;
            this.ErrDtMov = errdtmov;

        }
    }
}

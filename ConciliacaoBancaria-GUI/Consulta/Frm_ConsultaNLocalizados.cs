using BLL;
using DAL;
using MODELO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConciliacaoBancaria_GUI.Consulta
{
    public partial class Frm_ConsultaNaoLocalizados : Form
    {
        public int idConta;
        public string banco;
        public string conta;
        public Frm_ConsultaNaoLocalizados()
        {
            InitializeComponent();
        }

        private void Frm_ConsultaProtocoDifValor_Load(object sender, EventArgs e)
        {
            dgvItecN.RowsDefaultCellStyle.BackColor = Color.White;
            dgvItecN.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvExtratoN.RowsDefaultCellStyle.BackColor = Color.White;
            dgvExtratoN.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvLanctoDebitos.RowsDefaultCellStyle.BackColor = Color.White;
            dgvLanctoDebitos.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void btContas_Click(object sender, EventArgs e)
        {
            Frm_ConsultaContas f = new Frm_ConsultaContas();
            f.ShowDialog();
            if (f.idConta != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLContas bll = new BLLContas(cx);
                ModeloContas modelo = bll.CarregaModeloContas(f.idConta);
                idConta = f.idConta;
                banco = modelo.ConBanc;
                txtConta2.Text = modelo.ConNum;
                txtBanco2.Text = modelo.ConBanc;
                txtRazao2.Text = modelo.ConRaz;
                txtConta3.Text = modelo.ConNum;
                txtBanco3.Text = modelo.ConBanc;
                txtRazao3.Text = modelo.ConRaz;
                txtConta5.Text = modelo.ConNum;
                txtBanco5.Text = modelo.ConBanc;
                txtRazao5.Text = modelo.ConRaz;
            }
            f.Dispose();
        }

        private void btConsProtItecN_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLConsolidaItec bll = new BLLConsolidaItec(cx);
            dgvItecN.DataSource = bll.LocalizarItecNaoExtrato(idConta);
            this.SomaNValidadosItec();
        }
        private void SomaNValidadosItec()
        {
            lbNvalItec.Text = dgvItecN.RowCount.ToString();
            //
            decimal totalitec = 0;

            foreach (DataGridViewRow row in dgvItecN.Rows)
            {
                totalitec += Convert.ToDecimal(row.Cells[8].Value);
            }
            label11.Text = Convert.ToString(totalitec);
            label11.Text = String.Format("{0:N}", totalitec);
        }

        private void btConsExtratoN_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLConsolidaExtrato bll = new BLLConsolidaExtrato(cx);
            dgvExtratoN.DataSource = bll.LocalizarSobraExtrato(idConta);
            this.SomaNValidadosEXtrato();
        }
        private void SomaNValidadosEXtrato()
        {
            lbRegNValExt.Text = dgvExtratoN.RowCount.ToString();
            decimal totalExtrato = 0;

            foreach (DataGridViewRow row in dgvExtratoN.Rows)
            {
                totalExtrato += Convert.ToDecimal(row.Cells[6].Value);
            }
            label19.Text = Convert.ToString(totalExtrato);
            label19.Text = String.Format("{0:N}", totalExtrato);
        }

        private void btLancDebit_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLConsolidaItec bll = new BLLConsolidaItec(cx);
            dgvLanctoDebitos.DataSource = bll.LocalizarLancamentosDebitos(idConta);
            lbLancDebito.Text = dgvLanctoDebitos.RowCount.ToString();
        }
    }
}

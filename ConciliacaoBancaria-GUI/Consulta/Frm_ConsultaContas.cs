using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace ConciliacaoBancaria_GUI.Consulta
{
    public partial class Frm_ConsultaContas : Form
    {
        public int idConta;
        public Frm_ConsultaContas()
        {
            InitializeComponent();
        }

        private void Frm_ConsultaContas_Load(object sender, EventArgs e)
        {
            dgvDados.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDados.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            btPesquisa_Click(sender, e);
        }

        private void btPesquisa_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLContas bll = new BLLContas(cx);
            dgvDados.DataSource = bll.Localizar(txtBusca.Text);
            lbRegist.Text = dgvDados.RowCount.ToString();
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                this.idConta = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }

        private void txtBusca_Enter(object sender, EventArgs e)
        {
            btPesquisa_Click(sender, e);
        }

        private void Frm_ConsultaContas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}

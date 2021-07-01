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
    public partial class Frm_Consulta_Agencia_Filial : Form
    {
        public int filial;
        public string banco;
        public Frm_Consulta_Agencia_Filial()
        {
            InitializeComponent();            
        }
        public Frm_Consulta_Agencia_Filial(int nrFilial, string banco_)
        {
            InitializeComponent();
            filial = nrFilial;
            banco = banco_;
        }

        private void Frm_Consulta_Agencia_Filial_Load(object sender, EventArgs e)
        {
            dgvDados.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDados.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLAgencia bll = new BLLAgencia(cx);
            dgvDados.DataSource = bll.ListarAgencias(filial,banco);
        }
    }
}

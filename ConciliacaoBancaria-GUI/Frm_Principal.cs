using ConciliacaoBancaria_GUI.Consulta;
using ConciliacaoBancaria_GUI.Importar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConciliacaoBancaria_GUI
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void mpSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MsImportItec_Click(object sender, EventArgs e)
        {
            Frm_ImportarItec f = new Frm_ImportarItec();
            f.MdiParent = this;
            f.Show();
            //f.Dispose();
        }

        private void MpImportExt_Click(object sender, EventArgs e)
        {
            Frm_ImportarExtrato f = new Frm_ImportarExtrato();
            f.MdiParent = this;
            f.Show();
            //f.Dispose();
        }

        private void msConsItec_Extrato_Click(object sender, EventArgs e)
        {
            Frm_Validar_Itec_Extrato f = new Frm_Validar_Itec_Extrato();
            f.MdiParent = this;
            f.Show();
            //f.Dispose();
        }

        private void MsConsIndicador_Click(object sender, EventArgs e)
        {
            Frm_ConsultaIndicador f = new Frm_ConsultaIndicador();
            f.MdiParent = this;
            f.Show();
            //f.Dispose();
        }

        private void msConsulErros_Click(object sender, EventArgs e)
        {
            Frm_ConsultaErros f = new Frm_ConsultaErros();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_ConsultaNaoLocalizados f = new Frm_ConsultaNaoLocalizados();
            f.MdiParent = this;
            f.Show();
        }
    }
}

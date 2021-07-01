using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using DAL;
using BLL;

namespace ConciliacaoBancaria_GUI.Consulta
{
    public partial class Frm_ConsultaErros : Form
    {
        public Frm_ConsultaErros()
        {
            InitializeComponent();
        }

        private void Frm_ConsultaErros_Load(object sender, EventArgs e)
        {
            dgvDados.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDados.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }
        private void btPesquisar_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            
            if ((rbFilial.Checked) && (txtBusca.Text) != "")
            {
                BLLErro bll = new BLLErro(cx);
                dgvDados.DataSource = bll.LocalizarMovimento(Convert.ToInt32(txtBusca.Text), dtpInicio.Value.Date, dtpFim.Value.Date);
            }
            if ((rbFilial.Checked) && (txtBusca.Text) == "")
            {
                MessageBox.Show("Informe o Nº da Filial que deseja fazer o filtro!!!", "Aviso");
                txtBusca.Focus();
                BLLErro bll = new BLLErro(cx);
                dgvDados.DataSource = bll.LocalizarMovimento(dtpInicio.Value.Date, dtpFim.Value.Date);
            }
            if ((rbMovimento.Checked))
            {
                BLLErro bll = new BLLErro(cx);
                dgvDados.DataSource = bll.LocalizarMovimento(dtpInicio.Value.Date,dtpFim.Value.Date);
            }
            //this.OrdernarGrid();
            lbReg.Text = dgvDados.RowCount.ToString();
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog salvar = new SaveFileDialog();


            Excel.Application App; // Aplicação Excel 
            Excel.Workbook WorkBook; // Pasta 
            Excel.Worksheet WorkSheet; // Planilha 
            object misValue = System.Reflection.Missing.Value;

            App = new Excel.Application();
            WorkBook = App.Workbooks.Add(misValue);
            WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;


            for (int c = 1; c < dgvDados.Columns.Count + 1; c++)
            {

                WorkSheet.Cells[1, c] = dgvDados.Columns[c - 1].HeaderText;

            }

            // passa as celulas do DataGridView para a Pasta do Excel 
            for (i = 0; i <= dgvDados.RowCount - 1; i++)
            {

                for (j = 0; j <= dgvDados.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dgvDados[j, i];
                    WorkSheet.Cells[i + 2, j + 1] = cell.Value;
                }
            }

            // define algumas propriedades da caixa salvar 
            salvar.Title = "Meu Titulo";
            salvar.Filter = "Arquivo do Excel *.xls | *.xls";
            salvar.ShowDialog(); // mostra 

            // salva o arquivo 
            WorkBook.SaveAs(salvar.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,

            Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            WorkBook.Close(true, misValue, misValue);
            App.Quit(); // encerra o excel 

            MessageBox.Show("Exportado com sucesso!");
        }

        private void rbMovimento_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMovimento.Checked)
            {
                dtpFim.Enabled = true;
            }
            if (rbFilial.Checked)
            {
                dtpFim.Enabled = true;
                txtBusca.Enabled = true;
            }
        }
    }
}

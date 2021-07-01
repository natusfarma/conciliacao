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
using Excel = Microsoft.Office.Interop.Excel;

namespace ConciliacaoBancaria_GUI.Consulta
{
    public partial class Frm_ConsultaIndicador : Form
    {
        public Frm_ConsultaIndicador()
        {
            InitializeComponent();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (rbLancamento.Checked)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLIndicador bll = new BLLIndicador(cx);
                dgvDados.DataSource = bll.LocalizarDtLancamento(dtpInicio.Value.Date, dtpFim.Value.Date);
                lbReg.Text = dgvDados.RowCount.ToString();
            }
            else
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLIndicador bll = new BLLIndicador(cx);
                dgvDados.DataSource = bll.LocalizarDtMovimento(dtpInicio.Value.Date, dtpFim.Value.Date);
                lbReg.Text = dgvDados.RowCount.ToString();
            }
            
        }

        private void rbLancamento_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLancamento.Checked)
            {
                dtpFim.Enabled = false;
            }
            if (rbMovimento.Checked)
            {
                dtpFim.Enabled = true;
            }
        }

        private void Frm_ConsultaIndicador_Load(object sender, EventArgs e)
        {
            dgvDados.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDados.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            btPesquisar_Click(sender, e);
            rbLancamento_CheckedChanged(sender, e);
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
    }
}

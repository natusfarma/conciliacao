using BLL;
using ConciliacaoBancaria_GUI.Consulta;
using DAL;
using MODELO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConciliacaoBancaria_GUI.Importar
{
    public partial class Frm_ImportarItec : Form
    {
        public string arquivoExcel;
        public int idConta;
        public DateTime dtLanc;
        public string historico;
        public int filial;
        public DateTime dtDia;
        public decimal protocolo;
        public decimal valorc;
        public decimal valord;
        public Frm_ImportarItec()
        {
            InitializeComponent();
        }

        private void Frm_ImportarItec_Load(object sender, EventArgs e)
        {
            dgvDadosItec.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDadosItec.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque;
        }
        private void CarregaDadosExcel()
        {
            try
            {
                //converte os dados do Excel para um DataTable
                DataTable dt = GetTabelaExcel(arquivoExcel);

                //ajusta a largura das colunas aos dados
                dgvDadosItec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvDadosItec.DataSource = dt;

                //No total de registros
                lbRegItec.Text = (dgvDadosItec.Rows.Count).ToString();

                string[] listaNomeColunas = dt.Columns.OfType<DataColumn>().Select(x => x.ColumnName).ToArray();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro :" + ex.Message);
            }
        }
        private List<String> erros;

        public List<string> Erros { get => erros; set => erros = value; }

        private DataTable GetTabelaExcel(string arquivoExcel)
        {
            DataTable dt = new DataTable();
            try
            {
                //pega a extensão do arquivo
                string Ext = Path.GetExtension(arquivoExcel);
                string connectionString = "";
                //verifica a versão do Excel pela extensão
                if (Ext == ".xls")
                { //para o  Excel 97-03    
                    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source =" + arquivoExcel + "; Extended Properties = 'Excel 8.0;HDR=YES'";
                }
                else if (Ext == ".xlsx")
                { //para o  Excel 07 e superior
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" + arquivoExcel + "; Extended Properties = 'Excel 8.0;HDR=YES'";
                }
                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
                cmd.Connection = conn;
                conn.Open();
                DataTable dtSchema;
                dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string nomePlanilha = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                conn.Close();
                //le todos os dados da planilha para o Data Table    
                conn.Open();
                cmd.CommandText = "SELECT * From [" + nomePlanilha + "]";
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dt);
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        private void btLocalArqItec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd1 = new OpenFileDialog();
            DialogResult drResult = ofd1.ShowDialog();
            if (drResult == System.Windows.Forms.DialogResult.OK)
                txtArqExcelItec.Text = ofd1.FileName;
        }

        private void btImporExcItec_Click(object sender, EventArgs e)
        {
            if (txtArqExcelItec.Text == "")
            {
                MessageBox.Show("Você não selecionou o arquivo para importar.\nSelecione primeiro para prosseguir.");
                btLocalArqItec.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(txtArqExcelItec.Text) && File.Exists(txtArqExcelItec.Text))
            {
                arquivoExcel = txtArqExcelItec.Text;
                this.CarregaDadosExcel();
            }
            else
            {
                this.CarregaDadosExcel();
            }
            string data = dgvDadosItec.Rows[3].Cells[0].Value.ToString();
            if(data != null)
            {
                dtpMovimento.Value = Convert.ToDateTime(data);
            }
        }
        private void LimparVariaveis()
        {
            valorc = 0;
            valord = 0;
            historico = "";
            protocolo = 0;
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
                txtConta.Text = modelo.ConNum;
                txtBanco.Text = modelo.ConBanc;
                txtRazao.Text = modelo.ConRaz;
            }
            f.Dispose();
        }
        private void TratarDadosContaItec()    // DADOS DO ITEC
        {
            progressBar1.Visible = true;
            lblPercent.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Convert.ToInt32(dgvDadosItec.RowCount);
            progressBar1.Step = 1;
            System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(2));
            progressBar1.Value = 0;
            lblPercent.Text = "";


            try
            {
                for (int i = 0; i < dgvDadosItec.RowCount; i++)
                {
                    progressBar1.PerformStep();
                    lblPercent.Text = "Processando..." + progressBar1.Value.ToString() + "%";

                    string dts = dgvDadosItec.Rows[i].Cells[0].Value.ToString().Substring(0, 10);
                    string resul1 = dgvDadosItec.Rows[i].Cells[1].Value.ToString();

                    if ((dts != "") && (resul1 != ""))
                    {
                        DateTime dt = DateTime.ParseExact(dts, "dd/MM/yyyy", null);

                        string s = dgvDadosItec.Rows[i].Cells[1].Value.ToString();
                        char[] separators = new char[] { ' ' };
                        string[] subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                        dtLanc = Convert.ToDateTime(dgvDadosItec.Rows[i].Cells[0].Value);
                        if ((subs[0] == "DEPOSITO") && (subs[1] == "CHEQUES"))
                        {
                            historico = subs[0] + " " + subs[1];
                            filial = 0;
                            protocolo = Convert.ToDecimal(subs[3] + subs[4]);
                            dtDia = Convert.ToDateTime(dt.ToString("yyyy/MM/dd").Substring(0, 10).Trim().Replace('/', '-'));
                            valord = 0;
                            valorc = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[3].Value);
                        }
                        if ((subs[0] == "RECEBIMENTO") && (subs[1] == "DE") && (subs[2] == "DUPLICATAS"))
                        {
                            historico = dgvDadosItec.Rows[i].Cells[1].Value.ToString();
                            filial = 0;
                            protocolo = Convert.ToDecimal(subs[8]);
                            dtDia = Convert.ToDateTime(dgvDadosItec.Rows[i].Cells[0].Value);
                            valord = 0;
                            valorc = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[3].Value);
                        }
                        if ((subs[0] == "RECEBIMENTO") && (subs[1] == "OPERADORA"))
                        {
                            historico = dgvDadosItec.Rows[i].Cells[1].Value.ToString();
                            filial = 0;
                            protocolo = 0;
                            dtDia = Convert.ToDateTime(dgvDadosItec.Rows[i].Cells[0].Value);
                            valord = 0;
                            valorc = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[3].Value);
                        }
                        if ((subs[0] == "PROT"))
                        {
                            historico = "DEPOSITO";
                            filial = Convert.ToInt32(subs[3]);
                            protocolo = Convert.ToDecimal(subs[1]);
                            dtDia = Convert.ToDateTime(dts);
                            valord = 0;
                            valorc = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[3].Value);
                        }
                        if ((subs[0] == "DEP") && (subs[1] == "FIL"))
                        {
                            historico = subs[0];
                            filial = Convert.ToInt32(subs[2]);
                            dtDia = Convert.ToDateTime("20" + subs[8] + "-" + subs[7] + "-" + subs[6]);
                            protocolo = Convert.ToDecimal(subs[10]);
                            valord = 0;
                            valorc = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[3].Value);
                        }

                        if ((subs[0] == "PAGTO") || (subs[0] == "TRANSF") || (subs[0] == "PGTO"))
                        {
                            historico = subs[0] + " " + subs[1] + " " + subs[2] + " " + subs[3];
                            filial = 0;
                            dtDia = Convert.ToDateTime(dgvDadosItec.Rows[i].Cells[0].Value);
                            protocolo = 0;
                            valord = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[2].Value);
                            valorc = 0;
                        }
                        if ((subs[0] == "TRANSF"))
                        {
                            historico = subs[0] + " " + subs[1] + " " + subs[2] + " " + subs[3];
                            filial = 0;
                            dtDia = Convert.ToDateTime(dgvDadosItec.Rows[i].Cells[0].Value);
                            protocolo = 0;
                            decimal valor1 = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[2].Value);
                            if (valor1 <= 0)
                            {
                                valorc = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[3].Value);
                            }
                            else
                            {
                                valord = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[2].Value);
                            }
                        }
                        if ((subs[0] == "CORRESPONDENTE"))
                        {
                            historico = Convert.ToString(dgvDadosItec.Rows[i].Cells[1].Value);
                            filial = 0;
                            dtDia = Convert.ToDateTime(dgvDadosItec.Rows[i].Cells[0].Value);
                            protocolo = 0;
                            valorc = 0;
                            valord = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[2].Value);
                        }
                        if ((subs[0] == "SERVFARMA"))
                        {
                            historico = subs[0];
                            filial = 0;
                            dtDia = Convert.ToDateTime(dgvDadosItec.Rows[i].Cells[0].Value);
                            protocolo = 0;
                            valord = 0;
                            valorc = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[3].Value);
                        }
                        if ((subs[0] == null))
                        {
                            historico = "linha" + " " + i;
                            filial = 0;
                            dtDia = Convert.ToDateTime(dgvDadosItec.Rows[i].Cells[0].Value); ;
                            protocolo = 0;
                            decimal val = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[2].Value);
                            if (val > 0)
                            {
                                valord = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[2].Value);
                                valorc = 0;
                            }
                            else
                            {
                                valorc = Convert.ToDecimal(dgvDadosItec.Rows[i].Cells[2].Value);
                                valord = 0;
                            }
                        }
                    }
                    this.GravarDadosItec();
                    this.LimparVariaveis();
                }
            }
            catch (Exception)
            {
            }
            
            progressBar1.Visible = false;
            lblPercent.Visible = false;
        }
        private void GravarDadosItec()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            try
            {
                
                ModeloConsolidaItec modelo = new ModeloConsolidaItec();
                BLLConsolidaItec bll = new BLLConsolidaItec(cx);
                modelo.IdConta = idConta;
                modelo.ItecDtLanc = dtLanc;
                modelo.ItecHist = historico;
                modelo.ItecFilial = Convert.ToInt32(filial);
                modelo.ItecProt = protocolo;
                modelo.ItecDia = dtDia;
                modelo.ItecValorC = valorc;
                modelo.ItecValorD = valord;
                bll.Incluir(modelo);
            }
            catch (Exception)// erro)
            {
                //MessageBox.Show("Não foi possível Realizar a Operação!!!\n\nContate o Administrador do sistema!!!\n\nErro Ocorrido:" + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           

        }



        private void btExcluirContaItec_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLConsolidaItec bll = new BLLConsolidaItec(cx);
            if(dtpMovimento.Value.Date == DateTime.Today)
            {
                MessageBox.Show("Verifique a data informada!!!!");
                dtpMovimento.Focus();
                return;
            }
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o Lançamento do dia informado?", "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (d.ToString() == "Yes")
                {
                    int retorno = bll.VerificaLancamento(idConta, dtpMovimento.Value.Date);
                    if (retorno != 0)
                    {
                        bll.Excluir(idConta, dtpMovimento.Value.Date);
                        MessageBox.Show("Lançamento Excluido!!!");
                    }
                    else
                    {
                        MessageBox.Show("Não foi encontrado registro desta conta na data informada","Aviso");
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possível Realizar a Operação!!!\n\nContate o Administrador do sistema!!!\n\nErro Ocorrido:" + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LimparGridItec()
        {
            dgvDadosItec.DataSource = null;
            txtArqExcelItec.Clear();
            lbRegItec.Text = "";
            txtConta.Clear();
            txtBanco.Clear();
            txtRazao.Clear();
        }

        private void btGravarItec_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLConsolidaItec bll = new BLLConsolidaItec(cx);
            int retorno = bll.VerificaLancamento(idConta, dtpMovimento.Value.Date);
            if (retorno > 0)
            {
                bll.Excluir(idConta, dtpMovimento.Value.Date);               
            }
            if (txtConta.Text == "")
            {
                MessageBox.Show("Informe uma conta para prosseguir.");
                btContas.Focus();
                return;
            }
            if (dgvDadosItec.RowCount <= 0)
            {
                MessageBox.Show("Você não fez a importação do arquivo.\nImporte primeiro para prosseguir.");
                btImporExcItec.Focus();
                return;
            }

            this.TratarDadosContaItec();
            bll.ExcluirValidados(idConta);
            MessageBox.Show("Dados importados", "Aviso");
            this.LimparGridItec();
        }

        private void btLimpDados_Click(object sender, EventArgs e)
        {
            this.LimparGridItec();
        }
    }
}

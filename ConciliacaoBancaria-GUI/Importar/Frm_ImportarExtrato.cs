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
    public partial class Frm_ImportarExtrato : Form
    {
        string arquivoExcel;
        public int idConta;
        public string banco;
        public DateTime dtLanc_;
        public string agencia_;
        public string historico_;
        public decimal protocolo_;
        public decimal valorc_;
        public decimal valord_;
        public Frm_ImportarExtrato()
        {
            InitializeComponent();
        }

        private void Frm_ImportarExtrato_Load(object sender, EventArgs e)
        {
            dgvExtrato.RowsDefaultCellStyle.BackColor = Color.White;
            dgvExtrato.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }
        private DataTable GetTabelaExcel1(string arquivoExcel)
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
        private void CarregaDadosExcel()
        {
            try
            {
                //converte os dados do Excel para um DataTable
                DataTable dt = GetTabelaExcel1(arquivoExcel);

                //ajusta a largura das colunas aos dados
                dgvExtrato.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvExtrato.DataSource = dt;

                //No total de registros
                lbRegExtrato.Text = (dgvExtrato.Rows.Count - 1).ToString();

                string[] listaNomeColunas = dt.Columns.OfType<DataColumn>().Select(x => x.ColumnName).ToArray();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro :" + ex.Message);
            }
        }
        private void LimparGrid()
        {
            dgvExtrato.DataSource = null;
            txtArqExcelBb.Clear();
            lbRegExtrato.Text = "";
            txtConta.Clear();
            txtBanco.Clear();
            txtRazao.Clear();
        }

        private void btLocArqBb_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult drResult = ofd.ShowDialog();
            if (drResult == System.Windows.Forms.DialogResult.OK)
                txtArqExcelBb.Text = ofd.FileName;
        }

        private void btImportExcBB_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtArqExcelBb.Text) && File.Exists(txtArqExcelBb.Text))
            {
                arquivoExcel = txtArqExcelBb.Text;
                this.CarregaDadosExcel();
            }
            else
            {
                this.CarregaDadosExcel();
            }
            string data = dgvExtrato.Rows[5].Cells[0].Value.ToString();
            if (data != null)
            {
                dtpMovimento.Value = Convert.ToDateTime(data);
            }
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
                txtConta.Text = modelo.ConNum;
                txtBanco.Text = modelo.ConBanc;
                txtRazao.Text = modelo.ConRaz;
            }
            f.Dispose();
        }
        private void GravarDadosExtratoBancario()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            try
            {

                ModeloConsolidaExtrato modelo = new ModeloConsolidaExtrato();
                BLLConsolidaExtrato bll = new BLLConsolidaExtrato(cx);
                modelo.IdConta = idConta;
                modelo.ExtDrLanc = dtLanc_;
                modelo.ExtAgenc = agencia_;
                modelo.ExtHist = historico_;
                modelo.ExtProt = protocolo_;
                modelo.ExtValorC = valorc_;
                modelo.ExtValorD = valord_;
                bll.Incluir(modelo);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possível Realizar a Operação!!!\n\nContate o Administrador do sistema!!!\n\nErro Ocorrido:" + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public string[] quebraLinha(string linha, char separador, char separador1, char separador2)
        {
            return linha.Split(separador, separador1, separador2);
        }
        public string[] quebraLinha(string linha, char separador, char separador1)
        {
            return linha.Split(separador, separador1);
        }
        public string[] quebraLinha(string linha, char separador)
        {
            return linha.Split(separador);
        }

        public string[] quebraLinha(string linha)
        {
            return quebraLinha(linha, ' ', '.', '*');
        }
        private void TratarExtratoBB()   //  BANCO DO BRASIL
        {
            this.ProgressBar();
            for (int i = 0; i < dgvExtrato.RowCount; i++)
            {
                progressBar1.PerformStep();
                lblPercent.Text = "Processando..." + progressBar1.Value.ToString() + "%";

                string col0 = dgvExtrato.Rows[i].Cells[0].Value.ToString();  // identificar a 1ª coluna                  

                if ((col0 != ""))
                {
                    string col9 = dgvExtrato.Rows[i].Cells[9].Value.ToString();  // identificar a 1ª coluna 

                    if ((col9 != "") && (col9 != "*") && (col9 != "Inf."))
                    {
                        string[] col_1 = quebraLinha(dgvExtrato.Rows[i].Cells[0].Value.ToString(), ' ', '*', '.');    //  Verificar o historico diferente de data

                        if ((col_1[0] != "Extrato") || (col_1[0] != "Agencia") || (col_1[0] != "Data") || (col_1[0] != "Saldo") || (col_1[0] != "Invest") || (col_1[0] != "Juros") || (col_1[0] != "IOF"))
                        {
                            string validaCol7 = dgvExtrato.Rows[i].Cells[7].Value.ToString();
                            string[] histo = quebraLinha(dgvExtrato.Rows[i].Cells[7].Value.ToString(), ' ');


                            if ((validaCol7 != "") && (histo[0] + " " + histo[1] != "BB RF"))
                            {
                                string validaCol7_ = dgvExtrato.Rows[i].Cells[7].Value.ToString().Trim().Replace(" ", "");

                                if ((validaCol7_ != "SaldoAnterior") && (validaCol7_ != "SALDO"))
                                {
                                    string[] subv = quebraLinha(dgvExtrato.Rows[i].Cells[8].Value.ToString(), '*', ' ');  // Identificar a coluna valor (C-D-*) 

                                    dtLanc_ = Convert.ToDateTime(dgvExtrato.Rows[i].Cells[0].Value);
                                    agencia_ = Convert.ToString(dgvExtrato.Rows[i].Cells[3].Value);
                                    historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[7].Value);
                                    protocolo_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[5].Value);
                                    if (col9 == "*")
                                    {
                                        valorc_ = Convert.ToDecimal(subv[0]);
                                        valord_ = 0;
                                    }
                                    if (col9 == "C")
                                    {
                                        valorc_ = Convert.ToDecimal(subv[0]);
                                        valord_ = 0;
                                    }
                                    if (col9 == "D")
                                    {
                                        valord_ = Convert.ToDecimal(subv[0]);
                                        valorc_ = 0;
                                    }
                                    this.GravarDadosExtratoBancario();
                                }
                            }
                            valorc_ = 0;
                            valord_ = 0;
                        }
                    }

                }
            }
            progressBar1.Visible = false;
            lblPercent.Visible = false;
        }
        private void TratarExtratoItau()  // BANCO ITAU
        {
            this.ProgressBar();
            for (int i = 0; i < dgvExtrato.RowCount; i++)
            {
                progressBar1.PerformStep();
                lblPercent.Text = "Processando..." + progressBar1.Value.ToString() + "%";
                string col0 = dgvExtrato.Rows[i].Cells[0].Value.ToString();  // identificar a 1ª coluna "DATA"  

                if (col0 != "")
                {
                    string[] subs = quebraLinha(dgvExtrato.Rows[i].Cells[1].Value.ToString(), ' ');    //  Tratar o historico

                    string[] verifv = quebraLinha(dgvExtrato.Rows[i].Cells[1].Value.ToString(), ' ', '-');

                    decimal valor = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[4].Value);

                    if (((subs[0] == "CXE") || (subs[0] == "CEI") || (subs[0] == "TBI") || (subs[0] == "TED") || (subs[0] == "SISPAG") || (verifv[0].Trim() == "C")))
                    {
                        dtLanc_ = Convert.ToDateTime(dgvExtrato.Rows[i].Cells[0].Value);
                        agencia_ = Convert.ToString(dgvExtrato.Rows[i].Cells[3].Value);
                        if ((subs[0] == "SISPAG") || (subs[0] == "TED"))
                        {
                            historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                            protocolo_ = 0;
                        }
                        if ((subs[0] == "CEI") || (subs[0] == "CXE"))
                        {
                            historico_ = subs[0] + " " + subs[2];
                            protocolo_ = Convert.ToDecimal(subs[1]);
                        }
                        if ((subs[0] == "TBI"))
                        {
                            historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                            protocolo_ = Convert.ToDecimal(subs[1]);
                        }
                        if (verifv[0] == "C")
                        {
                            string[] subsv_ = quebraLinha(dgvExtrato.Rows[1 + i].Cells[1].Value.ToString(), ' ', '-');

                            historico_ = subsv_[0] + " " + subsv_[2] + " " + subsv_[3];
                            protocolo_ = Convert.ToDecimal(subs[1]);
                        }
                        if (valor < 0)
                        {
                            valord_ = (Convert.ToDecimal(dgvExtrato.Rows[i].Cells[4].Value) * -1);
                            valorc_ = 0;
                        }
                        else
                        {
                            valorc_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[4].Value);
                            valord_ = 0;
                        }
                        this.GravarDadosExtratoBancario();
                        valorc_ = 0;
                        valord_ = 0;
                    }

                }

            }
            progressBar1.Visible = false;
            lblPercent.Visible = false;
        }
        private void TratarExtratoCEF()         //  BANCO CEF
        {
            this.ProgressBar();
            for (int i = 0; i < dgvExtrato.RowCount; i++)
            {
                progressBar1.PerformStep();
                lblPercent.Text = "Processando..." + progressBar1.Value.ToString() + "%";

                string col0 = dgvExtrato.Rows[i].Cells[0].Value.ToString();  // identificar a 1ª coluna "DATA"                

                if ((col0 != ""))
                {
                    string s = dgvExtrato.Rows[i].Cells[2].Value.ToString();    //  Tratar o historico
                    char[] separar = new char[] { ' ' };
                    string[] subs = s.Split(separar, StringSplitOptions.RemoveEmptyEntries);

                    string v = dgvExtrato.Rows[i].Cells[3].Value.ToString();  // Identificar a coluna valor (C-D-*) 
                    char[] separare = new char[] { ' ' };
                    string[] subv = v.Split(separare, StringSplitOptions.RemoveEmptyEntries);

                    decimal valor = Convert.ToDecimal(subv[0]);

                    if (((subs[0] == "DP") || (subs[0] == "PG") || (subs[0] == "ENVIO") || (subs[0] == "T") || (subs[0] == "TR") || (subs[0] == "TEV")))
                    {
                        dtLanc_ = Convert.ToDateTime(dgvExtrato.Rows[i].Cells[0].Value);
                        agencia_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                        if ((subs[0] == "DP") || (subs[0] == "PG") || (subs[0] == "ENVIO") || (subs[0] == "TEV"))
                        {
                            historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[2].Value);
                            protocolo_ = 0;
                        }
                        if ((subs[0] == "T") || (subs[0] == "TR"))
                        {
                            historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[2].Value);
                            protocolo_ = 0;
                        }

                        if (subv[1] == "C")
                        {
                            valorc_ = valor;
                            valord_ = 0;
                        }
                        else
                        {
                            valord_ = valor;
                            valorc_ = 0;
                        }
                        this.GravarDadosExtratoBancario();
                    }

                }
            }
            progressBar1.Visible = false;
            lblPercent.Visible = false;
        }
        private void TratarExtratoBrdesco()  // BANCO BRADESCO
        {
            this.ProgressBar();
            for (int i = 0; i < dgvExtrato.RowCount; i++)
            {
                progressBar1.PerformStep();
                lblPercent.Text = "Processando..." + progressBar1.Value.ToString() + "%";

                string col0 = dgvExtrato.Rows[i].Cells[0].Value.ToString();  // identificar a 1ª coluna "DATA"                

                if (col0 != "")
                {
                    string col1 = dgvExtrato.Rows[i].Cells[1].Value.ToString();  // saldo anterior

                    if (col1 != "SALDO ANTERIOR")
                    {
                        string s = dgvExtrato.Rows[i].Cells[1].Value.ToString();    //  Tratar o historico
                        char[] separar = new char[] { ' ', '.', '-' };
                        string[] subs = s.Split(separar, StringSplitOptions.RemoveEmptyEntries);


                        if ((col0 != "Data") || (col0 != "Total") || (col0 != "Total do dia"))
                        {
                            dtLanc_ = Convert.ToDateTime(dgvExtrato.Rows[i].Cells[0].Value);
                            if (subs[0] == "RESGATE")
                            {
                                agencia_ = " ";
                                historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                                protocolo_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[2].Value);
                                valorc_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[3].Value);
                                valord_ = 0;
                            }
                            if (subs[0] == "LIQUIDACAO")
                            {
                                agencia_ = " ";
                                historico_ = subs[0] + " " + subs[1] + " " + subs[3];
                                protocolo_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[2].Value);
                                valorc_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[3].Value);
                                valord_ = 0;
                            }
                            if (subs[0] == "TED")
                            {
                                agencia_ = " ";
                                historico_ = subs[0] + "-" + subs[4] + " " + subs[5] + " " + subs[6];
                                protocolo_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[2].Value);
                                valorc_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[3].Value);
                                valord_ = 0;
                            }
                            if ((subs[0] == "TRANSF") && (Convert.ToString(dgvExtrato.Rows[i].Cells[3].Value) != ""))
                            {
                                agencia_ = " ";
                                historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                                protocolo_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[2].Value);
                                valorc_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[3].Value);
                                valord_ = 0;
                            }
                            if ((subs[0] == "TRANSF") && (Convert.ToString(dgvExtrato.Rows[i].Cells[4].Value) != ""))
                            {
                                agencia_ = " ";
                                historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                                protocolo_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[2].Value);
                                valord_ = (Convert.ToDecimal(dgvExtrato.Rows[i].Cells[4].Value) * -1);
                                valorc_ = 0;
                            }

                            if ((subs[0] == "REDE") && (subs[1] == "MASTER"))
                            {
                                agencia_ = " ";
                                historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                                protocolo_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[2].Value);
                                valorc_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[3].Value);
                                valord_ = 0;
                            }
                            if ((subs[0] == "TARIFA") || (subs[0] == "APLICACAO") || (subs[0] == "TAR"))
                            {
                                agencia_ = " ";
                                historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                                protocolo_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[2].Value);
                                valord_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[4].Value.ToString().Trim().Replace("-", ""));
                                valorc_ = 0;
                            }
                            if ((subs[0] == "PAGTO") || (subs[0] == "CONTA") || (subs[0] == "PFOR"))
                            {
                                agencia_ = " ";
                                historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                                protocolo_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[2].Value);
                                valord_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[4].Value.ToString().Trim().Replace("-", ""));
                                valorc_ = 0;
                            }
                            if ((subs[0] == "BRADESCO") || (subs[1] == "NET"))
                            {
                                agencia_ = " ";
                                historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                                protocolo_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[2].Value);
                                valord_ = Convert.ToDecimal(Convert.ToDecimal(dgvExtrato.Rows[i].Cells[4].Value.ToString().Trim().Replace("-", "")));
                                valorc_ = 0;
                            }
                            if ((subs[0] == "DEP") && (subs[1] == "DINH"))
                            {
                                agencia_ = subs[5].Substring(2, 5);
                                historico_ = subs[0] + " " + subs[1];
                                protocolo_ = Convert.ToDecimal(subs[5].Substring(19, 5));
                                valorc_ = (Convert.ToDecimal(dgvExtrato.Rows[i].Cells[3].Value));
                                valord_ = 0;
                            }
                            if ((subs[0] == "DEP") && (subs[1] == "DINHEIRO"))
                            {
                                agencia_ = subs[4].Substring(2, 5);
                                historico_ = subs[0] + " " + subs[1];
                                protocolo_ = Convert.ToDecimal(subs[4].Substring(19, 5));
                                valorc_ = (Convert.ToDecimal(dgvExtrato.Rows[i].Cells[3].Value));
                                valord_ = 0;
                            }
                            if ((subs[0] == "DEPOSITO"))
                            {
                                agencia_ = "";
                                historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                                protocolo_ = 0;
                                valorc_ = (Convert.ToDecimal(dgvExtrato.Rows[i].Cells[3].Value));
                                valord_ = 0;
                            }
                            if ((subs[0] == "GOODCARD"))
                            {
                                agencia_ = "";
                                historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                                protocolo_ = Convert.ToInt32(dgvExtrato.Rows[i].Cells[2].Value);
                                valorc_ = (Convert.ToDecimal(dgvExtrato.Rows[i].Cells[3].Value));
                                valord_ = 0;
                            }
                            if ((subs[0] == "RECEBIMENTO") && (subs[1] == "FORNECEDOR"))
                            {
                                agencia_ = " ";
                                historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                                protocolo_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[2].Value);
                                valorc_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[3].Value);
                                valord_ = 0;
                            }
                            if ((subs[0] == "RECEBIMENTO") && (subs[1] == "TED"))
                            {
                                agencia_ = "";
                                historico_ = Convert.ToString(dgvExtrato.Rows[i].Cells[1].Value);
                                protocolo_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[2].Value);
                                valorc_ = Convert.ToDecimal(dgvExtrato.Rows[i].Cells[3].Value);
                                valord_ = 0;
                            }
                            this.GravarDadosExtratoBancario();
                        }
                    }
                }
            }
            progressBar1.Visible = false;
            lblPercent.Visible = false;
        }
        private void TratarExtratoSicoob()      // BANCO SICOOB
        {
            this.ProgressBar();
            for (int i = 0; i < dgvExtrato.RowCount; i++)
            {
                progressBar1.PerformStep();
                lblPercent.Text = "Processando..." + progressBar1.Value.ToString() + "%";

                string col0 = dgvExtrato.Rows[i].Cells[0].Value.ToString();  // identificar a 1ª coluna "DATA"
                string col1 = dgvExtrato.Rows[i].Cells[2].Value.ToString();  // identificar a 3ª coluna "Historico"


                if ((col0 != ""))
                {
                    if (col0 != "DATA")
                    {
                        if ((col1 != "SALDO ANTERIOR") && (col1 != "SALDO BLOQUEADO ANTERIOR"))
                        {
                            string ss;
                            if (dgvExtrato.RowCount > 2 + i)
                            {
                                ss = dgvExtrato.Rows[i].Cells[2].Value.ToString() + " " +
                                            dgvExtrato.Rows[1 + i].Cells[2].Value.ToString() + " " +
                                            dgvExtrato.Rows[2 + i].Cells[2].Value.ToString();
                            }
                            else
                            {
                                ss = dgvExtrato.Rows[i].Cells[2].Value.ToString();
                            }
                            string s = ss;
                            char[] separators = new char[] { ' ', '.' };
                            string[] subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                            string v = dgvExtrato.Rows[i].Cells[3].Value.ToString();    //  Tratar o VALOR
                            char[] separarv = new char[] { 'C', 'D', '*' };
                            string[] subsv = v.Split(separarv, StringSplitOptions.RemoveEmptyEntries);

                            var a = dgvExtrato.Rows[i].Cells[3].Value.ToString();   // VERIFICAR SE É DEBITO OU CREDITO
                            int q = a.Length;
                            string vallor = a.Substring(q - 1);

                            dtLanc_ = Convert.ToDateTime(dgvExtrato.Rows[i].Cells[0].Value);
                            if ((subs[0] == "DEP") && (subs[1] == "DINHEIRO"))
                            {
                                agencia_ = " ";
                                historico_ = col1;
                                protocolo_ = Convert.ToInt32(subs[7]);
                            }
                            if ((subs[0] == "DEP") && (subs[1] == "DINHEIRO") && (subs[2] == "NOME:"))
                            {
                                agencia_ = ""; historico_ = ""; protocolo_ = 0;
                                string t = s + " " + dgvExtrato.Rows[3 + i].Cells[2].Value.ToString();
                                char[] separatort = new char[] { ' ', '.' };
                                string[] subst = t.Split(separatort, StringSplitOptions.RemoveEmptyEntries);

                                agencia_ = " ";
                                historico_ = col1;
                                protocolo_ = Convert.ToInt32(subst[9]);
                            }
                            if ((subs[0] == "DEP") && (subs[1] == "CHEQUE"))
                            {
                                agencia_ = " ";
                                historico_ = col1;
                                protocolo_ = Convert.ToInt32(subs[7]);
                            }
                            if ((subs[0] == "DEP") && (subs[1] == "CHEQUE") && (subs[2] == "BLOQ"))
                            {
                                agencia_ = " ";
                                historico_ = col1;
                                protocolo_ = Convert.ToInt32(subs[9]);
                            }
                            if ((subs[0] == "DÉB") || (subs[0] == "DEBITO"))
                            {
                                agencia_ = " ";
                                historico_ = subs[0] + " - " + dgvExtrato.Rows[1 + i].Cells[2].Value.ToString();
                                protocolo_ = 0;
                            }
                            if ((subs[0] == "DEVOL"))
                            {
                                agencia_ = " ";
                                historico_ = subs[0] + " - " + dgvExtrato.Rows[1 + i].Cells[2].Value.ToString();
                                protocolo_ = 0;
                            }
                            if ((subs[0] == "TED"))
                            {
                                agencia_ = " ";
                                historico_ = dgvExtrato.Rows[i].Cells[2].Value.ToString(); ;
                                protocolo_ = 0;
                            }
                            if ((subs[0] == "CRÉD"))
                            {
                                agencia_ = " ";
                                historico_ = subs[0] + " " + dgvExtrato.Rows[1 + i].Cells[2].Value.ToString(); ;
                                protocolo_ = 0;
                            }
                            if ((subs[0] == "LIBERAÇÃO"))
                            {
                                agencia_ = " ";
                                historico_ = dgvExtrato.Rows[i].Cells[2].Value.ToString();
                                protocolo_ = 0;
                            }
                            if (vallor == "C")
                            {
                                valorc_ = Convert.ToDecimal(subsv[0]);
                                valord_ = 0;
                            }
                            if (vallor == "D")
                            {
                                valord_ = Convert.ToDecimal(subsv[0]);
                                valorc_ = 0;
                            }
                            if (vallor == "*")
                            {
                                valorc_ = Convert.ToDecimal(subsv[0]);
                                valord_ = 0;
                            }
                            this.GravarDadosExtratoBancario();
                        }
                    }
                }
            }
            progressBar1.Visible = false;
            lblPercent.Visible = false;
        }

        private void btTratarExtrato_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLConsolidaExtrato bll = new BLLConsolidaExtrato(cx);
            int retorno = bll.VerificaLancamento(idConta, dtpMovimento.Value.Date);
            if (retorno > 0)
            {
                bll.Excluir(idConta, dtpMovimento.Value.Date);
            }

            if (txtArqExcelBb.Text == "")
            {
                MessageBox.Show("Você não selecionou o arquivo para importar.\nSelecione primeiro para prosseguir.");
                btLocArqBb.Focus();
                return;
            }
            if (txtConta.Text == "")
            {
                MessageBox.Show("Informe uma conta para prosseguir.");
                btContas.Focus();
                return;
            }
            if (dgvExtrato.RowCount <= 0)
            {
                MessageBox.Show("Você não fez a importação do arquivo.\nImporte primeiro para prosseguir.");
                btImportExcBB.Focus();
                return;
            }
            if (banco == "BB")                      //  BANCO DO BRASIL
            {
                this.TratarExtratoBB();
                MessageBox.Show("Dados importados");
                this.LimparGrid();
            }
            if (banco == "Itau")                    //  BANCO ITAU
            {
                this.TratarExtratoItau();
                MessageBox.Show("Dados importados");
                this.LimparGrid();
            }
            if (banco == "CEF")                  //  BANCO CEF
            {
                this.TratarExtratoCEF();
                MessageBox.Show("Dados importados");
                this.LimparGrid();
            }
            if (banco == "Bradesco")                  //  BANCO BRADESCO
            {
                this.TratarExtratoBrdesco();
                MessageBox.Show("Dados importados");
                this.LimparGrid();
            }
            if (banco == "Sicoob")                  //  BANCO SICOOB
            {
                this.TratarExtratoSicoob();
                MessageBox.Show("Dados importados");
                this.LimparGrid();
            }
            bll.ExcluirValidado(idConta);

        }
        private void ProgressBar() 
        {
            progressBar1.Visible = true;
            lblPercent.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Convert.ToInt32(dgvExtrato.RowCount);
            progressBar1.Step = 1;
            System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(2));
            progressBar1.Value = 0;
            lblPercent.Text = "";
        }


        private void btLimparDados_Click(object sender, EventArgs e)
        {
            this.LimparGrid();
        }

        private void btExcluirDadosConta_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);

            BLLConsolidaExtrato bll = new BLLConsolidaExtrato(cx);
            if (dtpMovimento.Value.Date == DateTime.Today)
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
                        MessageBox.Show("Não foi encontrado registro desta conta na data informada", "Aviso");
                    }

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possível Realizar a Operação!!!\n\nContate o Administrador do sistema!!!\n\nErro Ocorrido:" + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvExtrato_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lbRegExtrato.Text = dgvExtrato.RowCount.ToString();
        }
    }
}

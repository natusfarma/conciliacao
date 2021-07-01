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
    public partial class Frm_Validar_Itec_Extrato : Form
    {
        public int idConta;
        public string banco;
        public string conta;
        public int nrFilial;        
        public string origem;
        public int idItec;
        public int idExtrato;
        public DateTime dtMov;
        public decimal valorMov;
        public string indicador;
        public string validado;
        public string agencias;
        public int linha;
        
        public Frm_Validar_Itec_Extrato()
        {
            InitializeComponent();
        }

        private void Frm_Validar_Itec_Extrato_Load(object sender, EventArgs e)
        {
            dgvProt_Valor.RowsDefaultCellStyle.BackColor = Color.White;
            dgvProt_Valor.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvProv_ValorN.RowsDefaultCellStyle.BackColor = Color.White;
            dgvProv_ValorN.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvChq.RowsDefaultCellStyle.BackColor = Color.White;
            dgvChq.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;            
            dgvConsultaItec.RowsDefaultCellStyle.BackColor = Color.White;
            dgvConsultaItec.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque;
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
                txtConta1.Text = modelo.ConNum;
                txtBanco1.Text = modelo.ConBanc;
                txtRazao1.Text = modelo.ConRaz;
                textBox1.Text = modelo.ConNum;
                textBox3.Text = modelo.ConBanc;
                textBox2.Text = modelo.ConRaz;
                txtConta4.Text = modelo.ConNum;
                txtBanco4.Text = modelo.ConBanc;
                txtRazao4.Text = modelo.ConRaz;
            }
            f.Dispose();
        }
        private void SomaValidadosItecExt()
        {
            lbRegValidados.Text = dgvProt_Valor.RowCount.ToString();
            //
            decimal totalitec = 0;
            decimal totalext = 0;

            foreach (DataGridViewRow row in dgvProt_Valor.Rows)
            {
                totalitec += Convert.ToDecimal(row.Cells[3].Value);
                totalext += Convert.ToDecimal(row.Cells[6].Value);
            }
            lbVrItec.Text = Convert.ToString(totalitec);
            lbVrItec.Text = String.Format("{0:N}", totalitec);
            lbVrExt.Text = Convert.ToString(totalext);
            lbVrExt.Text = String.Format("{0:N}", totalext);
        }

        private void btConsProtValor_Click(object sender, EventArgs e)
        {
            if(txtConta.Text == "")
            {
                txtConta.Text = "";
                MessageBox.Show("Conta não informada!!!\nInforme uma conta para continuar.", "Aviso");
                btContas.Focus();
                return;
            }
            if (rbTodos.Checked)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLConsolidaItec bll = new BLLConsolidaItec(cx);
                dgvProt_Valor.DataSource = bll.LocalizarProtocoloProtocolo(idConta);
                this.SomaValidadosItecExt();
            }
            if (rbDtMov.Checked)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLConsolidaItec bll = new BLLConsolidaItec(cx);
                dgvProt_Valor.DataSource = bll.LocalizarProtocoloProtocolo(idConta,dtpDtMov.Value.Date);
                this.SomaValidadosItecExt();
            }
        }

        private void btValidar_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLConsolidaExtrato blle = new BLLConsolidaExtrato(cx);
            BLLConsolidaItec blli = new BLLConsolidaItec(cx);

            try
            {
                progressBar1.Visible = true;
                lblPercent.Visible = false;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = Convert.ToInt32(dgvProt_Valor.RowCount);
                progressBar1.Step = 1;
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(2));
                progressBar1.Value = 0;
                lblPercent.Text = "";

                for (int i = 0; i < dgvProt_Valor.RowCount; i++)
                {
                    progressBar1.PerformStep();
                    lblPercent.Text = "Processando..." + progressBar1.Value.ToString() + "%";

                    idItec = Convert.ToInt32(dgvProt_Valor.Rows[i].Cells[0].Value);
                    idExtrato = Convert.ToInt32(dgvProt_Valor.Rows[i].Cells[9].Value);
                    blli.ValidarItec(idItec);
                    blle.ValidarEXtrato(idExtrato);                   
                }
                MessageBox.Show("Registros validados!!!");
            }
            catch (Exception)
            {
                throw;
            }
            progressBar1.Visible = false;
            lblPercent.Visible = false;
            btConsProtValor_Click(sender, e);
        }

        private void btConsProt_Valor_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLConsolidaItec bll = new BLLConsolidaItec(cx);
            dgvProv_ValorN.DataSource = bll.LocalizarProtocoloProtocoloValor(idConta);
            this.SomaNValidadosItecExt();
        }
        private void SomaNValidadosItecExt()
        {
            lbRegNv.Text = dgvProv_ValorN.RowCount.ToString();
            //
            decimal totalitec = 0;
            decimal totalext = 0;

            foreach (DataGridViewRow row in dgvProv_ValorN.Rows)
            {
                totalitec += Convert.ToDecimal(row.Cells[3].Value);
                totalext += Convert.ToDecimal(row.Cells[6].Value);
            }
            lbSomaItecNv.Text = Convert.ToString(totalitec);
            lbSomaItecNv.Text = String.Format("{0:N}", totalitec);
            lbSomaExtNv.Text = Convert.ToString(totalext);
            lbSomaExtNv.Text = String.Format("{0:N}", totalext);
        }

        private void btConsultaItec_Click(object sender, EventArgs e)
        {
            if(txtConta.Text == "")
            {
                MessageBox.Show("Conta não Informada!!!\nInforme uma conta para continuar.");
                this.tabControl1.SelectTab(0);
            }
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            if (rbTodos2.Checked)
            {
                BLLConsolidaItec bll = new BLLConsolidaItec(cx);
                dgvConsultaItec.DataSource = bll.LocalizarProtocolosNaoValidados(idConta, txtValor.Text);                
            }
            if (rbMovimento2.Checked)
            {
                BLLConsolidaItec bll = new BLLConsolidaItec(cx);
                dgvConsultaItec.DataSource = bll.LocalizarProtocolosNaoValidados(idConta, txtValor.Text,dtpMov2.Value.Date);
            }
            lbNaoLocalizados.Text = dgvConsultaItec.RowCount.ToString();
        }

        private void dgvConsultaItec_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvConsultaItec.Rows)
            {
                if (Convert.ToString(row.Cells[10].Value) == "Itec")
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue; // Cor Vermelho
                }
            }
        }

        private void LimparPainelIndicador()
        {
            foreach (Control c in pnIndicador.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                mtbDtCorrigir.Text = "";
            }
        }
        private void dgvConsultaItec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                origem = dgvConsultaItec.Rows[e.RowIndex].Cells[10].Value.ToString();
                if (origem == "Extrato")
                {
                    idExtrato = Convert.ToInt32(dgvConsultaItec.Rows[e.RowIndex].Cells[3].Value);
                }
            }            
        }
        private void dgvConsultaItec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                linha = e.RowIndex;
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                ModeloConsolidaItec modeloi = new ModeloConsolidaItec();
                BLLConsolidaItec blli = new BLLConsolidaItec(cx);

                ModeloConsolidaExtrato modeloe = new ModeloConsolidaExtrato();
                BLLConsolidaExtrato blle = new BLLConsolidaExtrato(cx);

                var senderGrid = (DataGridView)sender;
                string nrfilial = dgvConsultaItec.Rows[e.RowIndex].Cells[6].Value.ToString();
                nrFilial = Convert.ToInt32(nrfilial);
                origem = dgvConsultaItec.Rows[e.RowIndex].Cells[10].Value.ToString();

                if (e.ColumnIndex == 0)   // botao Editar
                {
                    if (senderGrid.Columns[0] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        if (origem == "Itec")
                        {                       // dialog
                            modeloi.IdConsItec = Convert.ToInt32(dgvConsultaItec.Rows[e.RowIndex].Cells[3].Value);
                            idItec = modeloi.IdConsItec;
                            modeloi.ItecProt = Convert.ToDecimal(dgvConsultaItec.Rows[e.RowIndex].Cells[8].Value.ToString());
                            modeloi.ItecValorC = Convert.ToDecimal(dgvConsultaItec.Rows[e.RowIndex].Cells[9].Value);
                            blli.AlterarProtocoloValor(modeloi);
                            //      chama o painel 
                            pnIndicador.Visible = true;
                            this.LimparPainelIndicador();
                            nrfilial = dgvConsultaItec.Rows[e.RowIndex].Cells[6].Value.ToString();
                            dtMov = Convert.ToDateTime(dgvConsultaItec.Rows[e.RowIndex].Cells[7].Value);
                            valorMov = Convert.ToDecimal(dgvConsultaItec.Rows[e.RowIndex].Cells[9].Value);
                            lbFilial.Text = nrFilial.ToString();
                            lbData.Text = dtMov.ToString().Substring(0, 10);
                        }
                        if (origem == "Extrato")
                        {
                            modeloe.IdConExt = Convert.ToInt32(dgvConsultaItec.Rows[e.RowIndex].Cells[3].Value);
                            modeloe.ExtProt = Convert.ToDecimal(dgvConsultaItec.Rows[e.RowIndex].Cells[8].Value.ToString());
                            modeloe.ExtValorC = Convert.ToDecimal(dgvConsultaItec.Rows[e.RowIndex].Cells[9].Value);
                            blle.AlterarProtocoloValor(modeloe);
                        }
                    }
                }
                if (e.ColumnIndex == 1)   // botao validar
                {
                    if (senderGrid.Columns[1] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        if (origem == "Itec")
                        {
                            modeloi.IdConsItec = Convert.ToInt32(dgvConsultaItec.Rows[e.RowIndex].Cells[3].Value);
                            blli.ValidarItec(modeloi.IdConsItec);
                        }
                        if (origem == "Extrato")
                        {
                            modeloe.IdConExt = Convert.ToInt32(dgvConsultaItec.Rows[e.RowIndex].Cells[3].Value);
                            blle.ValidarEXtrato(modeloe.IdConExt);
                        }
                    }
                }
                if (e.ColumnIndex == 2)  // botao agencia
                {
                    if (senderGrid.Columns[2] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        if ((origem == "Itec") && (nrfilial != ""))
                        {
                            pnAgencia.Visible = true;
                            nrFilial = Convert.ToInt32(dgvConsultaItec.Rows[e.RowIndex].Cells[6].Value);
                            BLLAgencia bll = new BLLAgencia(cx);
                            dgvAgencia.DataSource = bll.ListarAgencias(nrFilial, banco);
                        }
                    }
                }
            }           
        }
        
        private void dgvConsultaItec_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLAgencia blla = new BLLAgencia(cx);
                BLLConsolidaItec blli = new BLLConsolidaItec(cx);
                DataTable tabela = new DataTable();
                string nFilial = dgvConsultaItec.Rows[e.RowIndex].Cells[6].Value.ToString();

                decimal valorP = Convert.ToDecimal(dgvConsultaItec.Rows[e.RowIndex].Cells[9].Value);

                tabela = blla.ListarAgencias(Convert.ToInt32(nFilial));
                string filial = "";
                string rec = "";
                int qtdeAgenc = blla.ListarAgencias(Convert.ToInt32(nFilial)).Rows.Count;
                if (qtdeAgenc > 1)
                {

                    for (int i = 1; i <= qtdeAgenc; i++)
                    {
                        string rec1 = "";
                        if (i < qtdeAgenc)
                        {
                            rec = tabela.Rows[i - 1][0].ToString() + ",";
                            rec1 = rec;
                        }
                        if (i == qtdeAgenc)
                        {
                            rec = tabela.Rows[i - 1][0].ToString();
                            rec1 = rec;
                        }
                        filial = filial + rec1;
                        rec = "";
                    }
                    agencias = filial;
                    dgvConsultaItec.DataSource = blli.LocalizarProtocolosNaoValidadosPorAgencia(idConta, nFilial, valorP, txtValor.Text, agencias);
                    lbNaoLocalizados.Text = dgvConsultaItec.RowCount.ToString();
                }
                if (qtdeAgenc == 1)
                {
                    agencias = blla.RetornaAgencia(Convert.ToInt32(nFilial), banco);
                    dgvConsultaItec.DataSource = blli.LocalizarProtocolosNaoValidadosPorAgencia(idConta, nFilial, valorP, txtValor.Text, agencias);
                    lbNaoLocalizados.Text = dgvConsultaItec.RowCount.ToString();
                }
            }
        }
        private void btFecharPnAgen_Click(object sender, EventArgs e)
        {
            pnAgencia.Visible = false;
        }
        private Indicador ValorIndicador()
        {
            Indicador valor = 0;

            if (ckbProtDup.Checked && ckbProt.Checked && ckbData.Checked && ckbConta.Checked && ckbValor.Checked) //29
            {
                valor = Indicador.PD_P_D_C_V;
            }
            else if (ckbProtDup.Checked && ckbProt.Checked && ckbData.Checked && ckbConta.Checked) // 28
            {
                valor = Indicador.PD_P_C_V;
            }
            else if (ckbProtDup.Checked && ckbData.Checked && ckbConta.Checked && ckbValor.Checked) //27
            {
                valor = Indicador.PD_D_C_V;
            }
            else if (ckbProt.Checked && ckbData.Checked && ckbConta.Checked && ckbValor.Checked) //26
            {
                valor = Indicador.P_D_C_V;
            }
            else if (ckbProtDup.Checked && ckbProt.Checked && ckbData.Checked && ckbConta.Checked) //25
            {
                valor = Indicador.PD_P_D_C;
            }
            else if (ckbProtDup.Checked && ckbData.Checked && ckbConta.Checked) //24
            {
                valor = Indicador.PD_D_C;
            }
            else if (ckbProt.Checked && ckbConta.Checked && ckbValor.Checked) //23
            {
                valor = Indicador.P_C_V;
            }
            else if (ckbProtDup.Checked && ckbConta.Checked && ckbValor.Checked) //22
            {
                valor = Indicador.PD_C_V;
            }
            else if (ckbData.Checked && ckbConta.Checked && ckbValor.Checked) //21
            {
                valor = Indicador.D_C_V;
            }
            else if (ckbProt.Checked && ckbData.Checked && ckbValor.Checked) //20
            {
                valor = Indicador.P_D_V;
            }
            else if (ckbProt.Checked && ckbData.Checked && ckbConta.Checked) //19
            {
                valor = Indicador.P_D_C;
            }
            else if (ckbProtDup.Checked && ckbProt.Checked && ckbValor.Checked) //18
            {
                valor = Indicador.PD_P_V;
            }
            else if (ckbProtDup.Checked && ckbProt.Checked && ckbConta.Checked) //17
            {
                valor = Indicador.PD_P_C;
            }
            else if (ckbProtDup.Checked && ckbProt.Checked && ckbData.Checked)  //16
            {
                valor = Indicador.PD_P_D;
            }
            else if (ckbConta.Checked && ckbValor.Checked) // 15
            {
                valor = Indicador.C_V;
            }
            else if (ckbData.Checked && ckbValor.Checked) // 14
            {
                valor = Indicador.D_V;
            }
            else if (ckbData.Checked && ckbConta.Checked) // 13
            {
                valor = Indicador.D_C;
            }
            else if (ckbProt.Checked && ckbValor.Checked) // 12
            {
                valor = Indicador.P_V;
            }
            else if (ckbProt.Checked && ckbConta.Checked) // 11
            {
                valor = Indicador.P_C;
            }
            else if (ckbProt.Checked && ckbData.Checked) // 10
            {
                valor = Indicador.P_D;
            }
            else if (ckbProtDup.Checked && ckbValor.Checked) // 9
            {
                valor = Indicador.PD_V;
            }
            else if (ckbProtDup.Checked && ckbConta.Checked) // 8
            {
                valor = Indicador.PD_C;
            }
            else if (ckbProtDup.Checked && ckbData.Checked) // 7
            {
                valor = Indicador.PD_D;
            }
            else if (ckbProtDup.Checked && ckbProt.Checked) // 6
            {
                valor = Indicador.PD_P;
            }
            else if (ckbValor.Checked) // 5
            {
                valor = Indicador.V;
            }
            else if (ckbConta.Checked) // 4
            {
                valor = Indicador.C;
            }
            else if (ckbData.Checked) // 3
            {
                valor = Indicador.D;
            }
            else if (ckbProt.Checked)  //2
            {
                valor = Indicador.P;
            }
            else if (ckbProtDup.Checked) //1
            {
                valor = Indicador.PD;
            }
            
            return valor;
        }

        public enum Indicador
        {
            PD = 1,
            P = 2,
            D = 3,
            C = 4,
            V = 5,
            PD_P = 6,
            PD_D = 7,
            PD_C = 8,
            PD_V = 9,
            P_D = 10,
            P_C = 11,
            P_V = 12,
            D_C = 13,
            D_V = 14,
            C_V = 15,
            PD_P_D = 16,
            PD_P_C = 17,
            PD_P_V = 18,
            P_D_C = 19,
            P_D_V = 20,
            D_C_V = 21,
            PD_C_V = 22,
            P_C_V = 23,
            PD_D_C = 24,
            PD_P_D_C = 25,
            P_D_C_V = 26,
            PD_D_C_V = 27,
            PD_P_C_V = 28,
            PD_P_D_C_V = 29,
        }

        private void btFecharIndicador_Click(object sender, EventArgs e)
        {
            pnIndicador.Visible = false;
            ckbProtDup.Checked = false;
            ckbProt.Checked = false;
            ckbData.Checked = false;
            ckbConta.Checked = false;
            ckbValor.Checked = false;
        }
        private ModeloIndicador GravarIndicador(ModeloIndicador modelo)
        {
            modelo.IndDtMov = dtMov;
            modelo.IndFilial = nrFilial;
            modelo.IndTpErro = ((int)this.ValorIndicador()).ToString();
            return modelo;
        }
        private ModeloErro GravarErro(ModeloErro modelo)
        {
            modelo.ErrFilial = nrFilial;
            modelo.ErrDtMov = dtMov;
            modelo.ErrTipoErro = this.TipoErro();
            modelo.ErrValor = valorMov;
            modelo.ErrIdentificado = this.ErroIdentificado();
            modelo.ErrCorrigir = this.ErroCorrigir();
            return modelo;
        }
        private string TipoErro()
        {
            string tperro = "";
            if (ckbProt.Checked)
            {
                tperro = "Protocolo";
            }
            if (ckbData.Checked)
            {
                tperro = "Data";
            }
            if (ckbConta.Checked)
            {
                tperro = "Conta";
            }
            if (ckbValor.Checked)
            {
                tperro = "Valor";
            }
            return tperro;
        }
        private string ErroIdentificado()
        {
            string erroIdent="";
            if (ckbProt.Checked)
            {
                erroIdent = dgvConsultaItec.Rows[linha].Cells[8].Value.ToString(); 
            }
            if (ckbData.Checked)
            {
                erroIdent = dgvConsultaItec.Rows[linha].Cells[4].Value.ToString().Substring(0,10).Replace("/","-")+" - "+ dgvConsultaItec.Rows[linha].Cells[8].Value.ToString();
            }
            if (ckbConta.Checked)
            {
                erroIdent = txtConta4.Text + " - " + dgvConsultaItec.Rows[linha].Cells[8].Value.ToString(); ;
            }
            if (ckbValor.Checked)
            {
                erroIdent = dgvConsultaItec.Rows[linha].Cells[8].Value.ToString();
            }
            return erroIdent;
        }
        private string ErroCorrigir()
        {
            string errcorrigir = "";
            if (ckbProt.Checked)
            {
                errcorrigir = txtProtCorrigir.Text;
            }
            if (ckbData.Checked)
            {
                errcorrigir = mtbDtCorrigir.Text.Substring(0, 10).Replace("/", "-");
            }
            if (ckbConta.Checked)
            {
                errcorrigir = txtContCorrigir.Text;
            }
            if (ckbValor.Checked)
            {
                errcorrigir = txtValorCorrigir.Text;
            }
            return errcorrigir;
        }
        private void btSalvarIndic_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            try
            {
                BLLIndicador bll = new BLLIndicador(cx);
                ModeloIndicador modelo = new ModeloIndicador();                
                bll.Incluir(this.GravarIndicador(modelo));
                BLLErro blle = new BLLErro(cx);
                ModeloErro modeloe = new ModeloErro();
                blle.Incluir(this.GravarErro(modeloe));

                this.ValidarLançamentos();
                MessageBox.Show("Registrado");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possível Realizar a Operação!!!\n\nContate o Administrador do sistema!!!\n\nErro Ocorrido:" + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btFecharIndicador_Click(sender,e);
            btConsultaItec_Click(sender, e);
        }
        private void ValidarLançamentos()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            ModeloConsolidaItec modeloi = new ModeloConsolidaItec();
            BLLConsolidaItec blli = new BLLConsolidaItec(cx);

            ModeloConsolidaExtrato modeloe = new ModeloConsolidaExtrato();
            BLLConsolidaExtrato blle = new BLLConsolidaExtrato(cx);
            //ITEC            
            blli.ValidarItec(idItec);
            //EXTRATO            
            blle.ValidarEXtrato(idExtrato);
        }
 

        private void ckbProt_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbProt.Checked)
            {
                txtProtCorrigir.Enabled = true;
            }
            else
            {
                txtProtCorrigir.Enabled = false;
            }
        }

        private void ckbData_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbData.Checked)
            {
                mtbDtCorrigir.Enabled = true;
            }
            else
            {
                mtbDtCorrigir.Enabled = false;
            }
        }

        private void ckbConta_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbConta.Checked)
            {
                txtContCorrigir.Enabled = true;
            }
            else
            {
                txtContCorrigir.Enabled = false;
            }
        }

        private void ckbValor_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbValor.Checked)
            {
                txtValorCorrigir.Enabled = true;
            }
            else
            {
                txtValorCorrigir.Enabled = false;
            }
        }

        private void dgvConsultaItec_MouseHover(object sender, EventArgs e)
        {
            label51.Visible = true;
        }

        private void dgvConsultaItec_MouseLeave(object sender, EventArgs e)
        {
            label51.Visible = false;
        }

        private void btFiltroChq_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLConsolidaItec bll = new BLLConsolidaItec(cx);
            dgvChq.DataSource = bll.LocalizarChequesProtocolosNaoValidados(idConta, "");
            label11.Text = dgvChq.RowCount.ToString();
        }

        private void dgvChq_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvChq.Rows)
            {
                if (Convert.ToString(row.Cells[10].Value) == "Itec")
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue; // Cor Vermelho
                }
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbTodos2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

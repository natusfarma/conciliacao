
namespace ConciliacaoBancaria_GUI.Consulta
{
    partial class Frm_ConsultaErros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConsultaErros));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btExcel = new System.Windows.Forms.Button();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.lbReg = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.rbMovimento = new System.Windows.Forms.RadioButton();
            this.rbFilial = new System.Windows.Forms.RadioButton();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btImprimir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.err_dtmov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.err_filial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.err_tipoerro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.err_erroidentificado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.err_errocorrigir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btExcel
            // 
            this.btExcel.BackColor = System.Drawing.Color.Transparent;
            this.btExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btExcel.BackgroundImage")));
            this.btExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btExcel.FlatAppearance.BorderSize = 0;
            this.btExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcel.Location = new System.Drawing.Point(687, 12);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(65, 44);
            this.btExcel.TabIndex = 252;
            this.btExcel.UseVisualStyleBackColor = false;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btPesquisar
            // 
            this.btPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.btPesquisar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btPesquisar.BackgroundImage")));
            this.btPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btPesquisar.FlatAppearance.BorderSize = 0;
            this.btPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPesquisar.Location = new System.Drawing.Point(529, 12);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(65, 44);
            this.btPesquisar.TabIndex = 251;
            this.btPesquisar.UseVisualStyleBackColor = false;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // lbReg
            // 
            this.lbReg.AutoSize = true;
            this.lbReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReg.ForeColor = System.Drawing.Color.Maroon;
            this.lbReg.Location = new System.Drawing.Point(129, 450);
            this.lbReg.Name = "lbReg";
            this.lbReg.Size = new System.Drawing.Size(14, 13);
            this.lbReg.TabIndex = 250;
            this.lbReg.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 449);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 249;
            this.label3.Text = "Nº de Registro(s):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 248;
            this.label2.Text = "Data Fim:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 247;
            this.label1.Text = "Data Inicio:";
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(182, 35);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(99, 20);
            this.dtpFim.TabIndex = 246;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(182, 11);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(99, 20);
            this.dtpInicio.TabIndex = 245;
            // 
            // rbMovimento
            // 
            this.rbMovimento.AutoSize = true;
            this.rbMovimento.Checked = true;
            this.rbMovimento.Location = new System.Drawing.Point(20, 16);
            this.rbMovimento.Name = "rbMovimento";
            this.rbMovimento.Size = new System.Drawing.Size(77, 17);
            this.rbMovimento.TabIndex = 244;
            this.rbMovimento.TabStop = true;
            this.rbMovimento.Text = "Movimento";
            this.rbMovimento.UseVisualStyleBackColor = true;
            this.rbMovimento.CheckedChanged += new System.EventHandler(this.rbMovimento_CheckedChanged);
            // 
            // rbFilial
            // 
            this.rbFilial.AutoSize = true;
            this.rbFilial.Location = new System.Drawing.Point(21, 38);
            this.rbFilial.Name = "rbFilial";
            this.rbFilial.Size = new System.Drawing.Size(45, 17);
            this.rbFilial.TabIndex = 243;
            this.rbFilial.Text = "Filial";
            this.rbFilial.UseVisualStyleBackColor = true;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.err_dtmov,
            this.err_filial,
            this.err_tipoerro,
            this.Column1,
            this.err_erroidentificado,
            this.err_errocorrigir});
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.Size = new System.Drawing.Size(758, 356);
            this.dgvDados.TabIndex = 242;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btImprimir);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtBusca);
            this.panel1.Controls.Add(this.btExcel);
            this.panel1.Controls.Add(this.btPesquisar);
            this.panel1.Location = new System.Drawing.Point(16, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 68);
            this.panel1.TabIndex = 253;
            // 
            // btImprimir
            // 
            this.btImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btImprimir.BackgroundImage")));
            this.btImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btImprimir.Enabled = false;
            this.btImprimir.FlatAppearance.BorderSize = 0;
            this.btImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btImprimir.Location = new System.Drawing.Point(608, 12);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(65, 44);
            this.btImprimir.TabIndex = 256;
            this.btImprimir.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbMovimento);
            this.groupBox1.Controls.Add(this.rbFilial);
            this.groupBox1.Controls.Add(this.dtpFim);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpInicio);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 61);
            this.groupBox1.TabIndex = 255;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 254;
            this.label4.Text = "Campo de busca: (Filial)";
            // 
            // txtBusca
            // 
            this.txtBusca.Enabled = false;
            this.txtBusca.Location = new System.Drawing.Point(318, 39);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(205, 20);
            this.txtBusca.TabIndex = 253;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvDados);
            this.panel2.Location = new System.Drawing.Point(16, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(762, 360);
            this.panel2.TabIndex = 254;
            // 
            // err_dtmov
            // 
            this.err_dtmov.DataPropertyName = "err_dtmov";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.err_dtmov.DefaultCellStyle = dataGridViewCellStyle1;
            this.err_dtmov.HeaderText = "Dt. Mov.";
            this.err_dtmov.Name = "err_dtmov";
            this.err_dtmov.ReadOnly = true;
            // 
            // err_filial
            // 
            this.err_filial.DataPropertyName = "err_filial";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.err_filial.DefaultCellStyle = dataGridViewCellStyle2;
            this.err_filial.HeaderText = "Filial";
            this.err_filial.Name = "err_filial";
            this.err_filial.ReadOnly = true;
            this.err_filial.Width = 60;
            // 
            // err_tipoerro
            // 
            this.err_tipoerro.DataPropertyName = "err_tipoerro";
            this.err_tipoerro.HeaderText = "Tipo do Erro";
            this.err_tipoerro.Name = "err_tipoerro";
            this.err_tipoerro.ReadOnly = true;
            this.err_tipoerro.Width = 150;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "err_valor";
            this.Column1.HeaderText = "Valor R$";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // err_erroidentificado
            // 
            this.err_erroidentificado.DataPropertyName = "err_erroidentificado";
            this.err_erroidentificado.HeaderText = "Lançamento";
            this.err_erroidentificado.Name = "err_erroidentificado";
            this.err_erroidentificado.ReadOnly = true;
            this.err_erroidentificado.Width = 150;
            // 
            // err_errocorrigir
            // 
            this.err_errocorrigir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.err_errocorrigir.DataPropertyName = "err_errocorrigir";
            this.err_errocorrigir.HeaderText = "Lançamento a Corrigir";
            this.err_errocorrigir.Name = "err_errocorrigir";
            this.err_errocorrigir.ReadOnly = true;
            // 
            // Frm_ConsultaErros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(790, 471);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbReg);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(120, 100);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConsultaErros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tela: Consulta aos Erros da Conciliação";
            this.Load += new System.EventHandler(this.Frm_ConsultaErros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.Label lbReg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.RadioButton rbMovimento;
        private System.Windows.Forms.RadioButton rbFilial;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn err_dtmov;
        private System.Windows.Forms.DataGridViewTextBoxColumn err_filial;
        private System.Windows.Forms.DataGridViewTextBoxColumn err_tipoerro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn err_erroidentificado;
        private System.Windows.Forms.DataGridViewTextBoxColumn err_errocorrigir;
    }
}
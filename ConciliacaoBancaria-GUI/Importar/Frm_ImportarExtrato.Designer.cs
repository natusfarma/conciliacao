namespace ConciliacaoBancaria_GUI.Importar
{
    partial class Frm_ImportarExtrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ImportarExtrato));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvExtrato = new System.Windows.Forms.DataGridView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblPercent = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btLocArqBb = new System.Windows.Forms.Button();
            this.lbRegExtrato = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btImportExcBB = new System.Windows.Forms.Button();
            this.txtArqExcelBb = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpMovimento = new System.Windows.Forms.DateTimePicker();
            this.btExcluirDadosConta = new System.Windows.Forms.Button();
            this.btLimparDados = new System.Windows.Forms.Button();
            this.btContas = new System.Windows.Forms.Button();
            this.txtConta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRazao = new System.Windows.Forms.TextBox();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.btTratarExtrato = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtrato)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(973, 533);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvExtrato);
            this.tabPage1.Controls.Add(this.panel9);
            this.tabPage1.Controls.Add(this.panel10);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(965, 507);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Extrato Bancário";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvExtrato
            // 
            this.dgvExtrato.AllowUserToAddRows = false;
            this.dgvExtrato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExtrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtrato.Location = new System.Drawing.Point(6, 48);
            this.dgvExtrato.Name = "dgvExtrato";
            this.dgvExtrato.ReadOnly = true;
            this.dgvExtrato.Size = new System.Drawing.Size(953, 408);
            this.dgvExtrato.TabIndex = 23;
            this.dgvExtrato.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvExtrato_RowsRemoved);
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel9.Controls.Add(this.lblPercent);
            this.panel9.Controls.Add(this.progressBar1);
            this.panel9.Controls.Add(this.btLocArqBb);
            this.panel9.Controls.Add(this.lbRegExtrato);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Controls.Add(this.btImportExcBB);
            this.panel9.Controls.Add(this.txtArqExcelBb);
            this.panel9.Location = new System.Drawing.Point(6, 458);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(953, 45);
            this.panel9.TabIndex = 22;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.ForeColor = System.Drawing.Color.Black;
            this.lblPercent.Location = new System.Drawing.Point(698, 1);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(14, 15);
            this.lblPercent.TabIndex = 236;
            this.lblPercent.Text = "0";
            this.lblPercent.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(695, 18);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(225, 23);
            this.progressBar1.TabIndex = 235;
            this.progressBar1.Visible = false;
            // 
            // btLocArqBb
            // 
            this.btLocArqBb.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btLocArqBb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLocArqBb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLocArqBb.Location = new System.Drawing.Point(321, 11);
            this.btLocArqBb.Name = "btLocArqBb";
            this.btLocArqBb.Size = new System.Drawing.Size(31, 26);
            this.btLocArqBb.TabIndex = 14;
            this.btLocArqBb.Text = "...";
            this.btLocArqBb.UseVisualStyleBackColor = false;
            this.btLocArqBb.Click += new System.EventHandler(this.btLocArqBb_Click);
            // 
            // lbRegExtrato
            // 
            this.lbRegExtrato.BackColor = System.Drawing.SystemColors.Window;
            this.lbRegExtrato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRegExtrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbRegExtrato.Location = new System.Drawing.Point(594, 18);
            this.lbRegExtrato.Name = "lbRegExtrato";
            this.lbRegExtrato.Size = new System.Drawing.Size(74, 20);
            this.lbRegExtrato.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(495, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "No.  Registros :";
            // 
            // btImportExcBB
            // 
            this.btImportExcBB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btImportExcBB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btImportExcBB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImportExcBB.Location = new System.Drawing.Point(368, 10);
            this.btImportExcBB.Name = "btImportExcBB";
            this.btImportExcBB.Size = new System.Drawing.Size(106, 27);
            this.btImportExcBB.TabIndex = 11;
            this.btImportExcBB.Text = "Importar Excel";
            this.btImportExcBB.UseVisualStyleBackColor = false;
            this.btImportExcBB.Click += new System.EventHandler(this.btImportExcBB_Click);
            // 
            // txtArqExcelBb
            // 
            this.txtArqExcelBb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArqExcelBb.Location = new System.Drawing.Point(4, 17);
            this.txtArqExcelBb.Name = "txtArqExcelBb";
            this.txtArqExcelBb.Size = new System.Drawing.Size(310, 20);
            this.txtArqExcelBb.TabIndex = 10;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.SystemColors.Control;
            this.panel10.Controls.Add(this.label4);
            this.panel10.Controls.Add(this.dtpMovimento);
            this.panel10.Controls.Add(this.btExcluirDadosConta);
            this.panel10.Controls.Add(this.btLimparDados);
            this.panel10.Controls.Add(this.btContas);
            this.panel10.Controls.Add(this.txtConta);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Controls.Add(this.txtRazao);
            this.panel10.Controls.Add(this.txtBanco);
            this.panel10.Controls.Add(this.btTratarExtrato);
            this.panel10.Controls.Add(this.label11);
            this.panel10.Location = new System.Drawing.Point(6, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(953, 43);
            this.panel10.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(832, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 244;
            this.label4.Text = "Data Movimento";
            // 
            // dtpMovimento
            // 
            this.dtpMovimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMovimento.Location = new System.Drawing.Point(829, 17);
            this.dtpMovimento.Name = "dtpMovimento";
            this.dtpMovimento.Size = new System.Drawing.Size(101, 20);
            this.dtpMovimento.TabIndex = 243;
            // 
            // btExcluirDadosConta
            // 
            this.btExcluirDadosConta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btExcluirDadosConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcluirDadosConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcluirDadosConta.ForeColor = System.Drawing.Color.Black;
            this.btExcluirDadosConta.Location = new System.Drawing.Point(674, 7);
            this.btExcluirDadosConta.Name = "btExcluirDadosConta";
            this.btExcluirDadosConta.Size = new System.Drawing.Size(138, 33);
            this.btExcluirDadosConta.TabIndex = 19;
            this.btExcluirDadosConta.Text = "Excluir Dados Conta";
            this.btExcluirDadosConta.UseVisualStyleBackColor = false;
            this.btExcluirDadosConta.Click += new System.EventHandler(this.btExcluirDadosConta_Click);
            // 
            // btLimparDados
            // 
            this.btLimparDados.BackColor = System.Drawing.SystemColors.Window;
            this.btLimparDados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimparDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimparDados.Location = new System.Drawing.Point(559, 6);
            this.btLimparDados.Name = "btLimparDados";
            this.btLimparDados.Size = new System.Drawing.Size(95, 33);
            this.btLimparDados.TabIndex = 18;
            this.btLimparDados.Text = "Limpar Tela";
            this.btLimparDados.UseVisualStyleBackColor = false;
            this.btLimparDados.Click += new System.EventHandler(this.btLimparDados_Click);
            // 
            // btContas
            // 
            this.btContas.BackColor = System.Drawing.SystemColors.Control;
            this.btContas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btContas.BackgroundImage")));
            this.btContas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btContas.FlatAppearance.BorderSize = 0;
            this.btContas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btContas.Location = new System.Drawing.Point(358, 4);
            this.btContas.Name = "btContas";
            this.btContas.Size = new System.Drawing.Size(57, 37);
            this.btContas.TabIndex = 17;
            this.btContas.UseVisualStyleBackColor = false;
            this.btContas.Click += new System.EventHandler(this.btContas_Click);
            // 
            // txtConta
            // 
            this.txtConta.BackColor = System.Drawing.SystemColors.Window;
            this.txtConta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtConta.Location = new System.Drawing.Point(3, 20);
            this.txtConta.Name = "txtConta";
            this.txtConta.ReadOnly = true;
            this.txtConta.Size = new System.Drawing.Size(93, 20);
            this.txtConta.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(227, 4);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Grupo Econômico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Banco";
            // 
            // txtRazao
            // 
            this.txtRazao.BackColor = System.Drawing.SystemColors.Window;
            this.txtRazao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtRazao.Location = new System.Drawing.Point(223, 20);
            this.txtRazao.Multiline = true;
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.Size = new System.Drawing.Size(129, 20);
            this.txtRazao.TabIndex = 13;
            // 
            // txtBanco
            // 
            this.txtBanco.BackColor = System.Drawing.SystemColors.Window;
            this.txtBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBanco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBanco.Location = new System.Drawing.Point(105, 20);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.ReadOnly = true;
            this.txtBanco.Size = new System.Drawing.Size(109, 20);
            this.txtBanco.TabIndex = 12;
            // 
            // btTratarExtrato
            // 
            this.btTratarExtrato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btTratarExtrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTratarExtrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTratarExtrato.Location = new System.Drawing.Point(440, 6);
            this.btTratarExtrato.Name = "btTratarExtrato";
            this.btTratarExtrato.Size = new System.Drawing.Size(95, 33);
            this.btTratarExtrato.TabIndex = 9;
            this.btTratarExtrato.Text = "Tratar Dados";
            this.btTratarExtrato.UseVisualStyleBackColor = false;
            this.btTratarExtrato.Click += new System.EventHandler(this.btTratarExtrato_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 4);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Conta Nº";
            // 
            // Frm_ImportarExtrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(997, 555);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(120, 120);
            this.MaximizeBox = false;
            this.Name = "Frm_ImportarExtrato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tela: Importar dados Extrato Bancário";
            this.Load += new System.EventHandler(this.Frm_ImportarExtrato_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtrato)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvExtrato;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btLocArqBb;
        private System.Windows.Forms.Label lbRegExtrato;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btImportExcBB;
        private System.Windows.Forms.TextBox txtArqExcelBb;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btExcluirDadosConta;
        private System.Windows.Forms.Button btLimparDados;
        private System.Windows.Forms.Button btContas;
        private System.Windows.Forms.TextBox txtConta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRazao;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Button btTratarExtrato;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpMovimento;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label lblPercent;
    }
}
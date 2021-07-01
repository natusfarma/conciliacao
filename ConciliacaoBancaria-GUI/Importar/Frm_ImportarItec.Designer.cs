namespace ConciliacaoBancaria_GUI.Importar
{
    partial class Frm_ImportarItec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ImportarItec));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDadosItec = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPercent = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btLocalArqItec = new System.Windows.Forms.Button();
            this.lbRegItec = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btImporExcItec = new System.Windows.Forms.Button();
            this.txtArqExcelItec = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btExcluirContaItec = new System.Windows.Forms.Button();
            this.dtpMovimento = new System.Windows.Forms.DateTimePicker();
            this.btLimpDados = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtConta = new System.Windows.Forms.TextBox();
            this.btContas = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtRazao = new System.Windows.Forms.TextBox();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.btGravarItec = new System.Windows.Forms.Button();
            this.ckbValidados = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDadosItec)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(11, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(974, 533);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDadosItec);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(966, 507);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados Itec";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDadosItec
            // 
            this.dgvDadosItec.AllowUserToAddRows = false;
            this.dgvDadosItec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDadosItec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDadosItec.Location = new System.Drawing.Point(7, 51);
            this.dgvDadosItec.Name = "dgvDadosItec";
            this.dgvDadosItec.ReadOnly = true;
            this.dgvDadosItec.Size = new System.Drawing.Size(953, 400);
            this.dgvDadosItec.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.lblPercent);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.btLocalArqItec);
            this.panel3.Controls.Add(this.lbRegItec);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btImporExcItec);
            this.panel3.Controls.Add(this.txtArqExcelItec);
            this.panel3.Location = new System.Drawing.Point(7, 457);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(953, 45);
            this.panel3.TabIndex = 7;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.ForeColor = System.Drawing.Color.Black;
            this.lblPercent.Location = new System.Drawing.Point(723, 2);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(14, 15);
            this.lblPercent.TabIndex = 238;
            this.lblPercent.Text = "0";
            this.lblPercent.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(720, 19);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(225, 23);
            this.progressBar1.TabIndex = 237;
            this.progressBar1.Visible = false;
            // 
            // btLocalArqItec
            // 
            this.btLocalArqItec.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btLocalArqItec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLocalArqItec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLocalArqItec.Location = new System.Drawing.Point(321, 11);
            this.btLocalArqItec.Name = "btLocalArqItec";
            this.btLocalArqItec.Size = new System.Drawing.Size(31, 26);
            this.btLocalArqItec.TabIndex = 14;
            this.btLocalArqItec.Text = "...";
            this.btLocalArqItec.UseVisualStyleBackColor = false;
            this.btLocalArqItec.Click += new System.EventHandler(this.btLocalArqItec_Click);
            // 
            // lbRegItec
            // 
            this.lbRegItec.BackColor = System.Drawing.SystemColors.Window;
            this.lbRegItec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRegItec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbRegItec.Location = new System.Drawing.Point(619, 17);
            this.lbRegItec.Name = "lbRegItec";
            this.lbRegItec.Size = new System.Drawing.Size(74, 20);
            this.lbRegItec.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(519, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "No.  Registros :";
            // 
            // btImporExcItec
            // 
            this.btImporExcItec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btImporExcItec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btImporExcItec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImporExcItec.Location = new System.Drawing.Point(372, 10);
            this.btImporExcItec.Name = "btImporExcItec";
            this.btImporExcItec.Size = new System.Drawing.Size(126, 27);
            this.btImporExcItec.TabIndex = 11;
            this.btImporExcItec.Text = "Importar Excel";
            this.btImporExcItec.UseVisualStyleBackColor = false;
            this.btImporExcItec.Click += new System.EventHandler(this.btImporExcItec_Click);
            // 
            // txtArqExcelItec
            // 
            this.txtArqExcelItec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArqExcelItec.Location = new System.Drawing.Point(4, 17);
            this.txtArqExcelItec.Name = "txtArqExcelItec";
            this.txtArqExcelItec.Size = new System.Drawing.Size(310, 20);
            this.txtArqExcelItec.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btExcluirContaItec);
            this.panel4.Controls.Add(this.dtpMovimento);
            this.panel4.Controls.Add(this.btLimpDados);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.btGravarItec);
            this.panel4.Controls.Add(this.ckbValidados);
            this.panel4.Location = new System.Drawing.Point(7, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(953, 43);
            this.panel4.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(822, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 242;
            this.label4.Text = "Data Movimento";
            // 
            // btExcluirContaItec
            // 
            this.btExcluirContaItec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btExcluirContaItec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcluirContaItec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcluirContaItec.ForeColor = System.Drawing.Color.Black;
            this.btExcluirContaItec.Location = new System.Drawing.Point(670, 11);
            this.btExcluirContaItec.Name = "btExcluirContaItec";
            this.btExcluirContaItec.Size = new System.Drawing.Size(129, 28);
            this.btExcluirContaItec.TabIndex = 241;
            this.btExcluirContaItec.Text = "Excluir Lançamento";
            this.btExcluirContaItec.UseVisualStyleBackColor = false;
            this.btExcluirContaItec.Click += new System.EventHandler(this.btExcluirContaItec_Click);
            // 
            // dtpMovimento
            // 
            this.dtpMovimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMovimento.Location = new System.Drawing.Point(819, 19);
            this.dtpMovimento.Name = "dtpMovimento";
            this.dtpMovimento.Size = new System.Drawing.Size(101, 20);
            this.dtpMovimento.TabIndex = 241;
            // 
            // btLimpDados
            // 
            this.btLimpDados.BackColor = System.Drawing.SystemColors.Window;
            this.btLimpDados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpDados.Location = new System.Drawing.Point(566, 11);
            this.btLimpDados.Name = "btLimpDados";
            this.btLimpDados.Size = new System.Drawing.Size(96, 28);
            this.btLimpDados.TabIndex = 240;
            this.btLimpDados.Text = "Limpar Tela";
            this.btLimpDados.UseVisualStyleBackColor = false;
            this.btLimpDados.Click += new System.EventHandler(this.btLimpDados_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtConta);
            this.panel1.Controls.Add(this.btContas);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.txtRazao);
            this.panel1.Controls.Add(this.txtBanco);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 40);
            this.panel1.TabIndex = 238;
            // 
            // txtConta
            // 
            this.txtConta.BackColor = System.Drawing.SystemColors.Window;
            this.txtConta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtConta.Location = new System.Drawing.Point(5, 17);
            this.txtConta.Name = "txtConta";
            this.txtConta.ReadOnly = true;
            this.txtConta.Size = new System.Drawing.Size(93, 20);
            this.txtConta.TabIndex = 240;
            // 
            // btContas
            // 
            this.btContas.BackColor = System.Drawing.Color.Transparent;
            this.btContas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btContas.BackgroundImage")));
            this.btContas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btContas.FlatAppearance.BorderSize = 0;
            this.btContas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btContas.Location = new System.Drawing.Point(372, 4);
            this.btContas.Name = "btContas";
            this.btContas.Size = new System.Drawing.Size(52, 34);
            this.btContas.TabIndex = 239;
            this.btContas.UseVisualStyleBackColor = false;
            this.btContas.Click += new System.EventHandler(this.btContas_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 237;
            this.label3.Text = "Grupo Econômico";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(110, 3);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(38, 13);
            this.label28.TabIndex = 236;
            this.label28.Text = "Banco";
            // 
            // txtRazao
            // 
            this.txtRazao.BackColor = System.Drawing.SystemColors.Window;
            this.txtRazao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtRazao.Location = new System.Drawing.Point(225, 17);
            this.txtRazao.Multiline = true;
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.Size = new System.Drawing.Size(129, 20);
            this.txtRazao.TabIndex = 235;
            // 
            // txtBanco
            // 
            this.txtBanco.BackColor = System.Drawing.SystemColors.Window;
            this.txtBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBanco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBanco.Location = new System.Drawing.Point(107, 17);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.ReadOnly = true;
            this.txtBanco.Size = new System.Drawing.Size(109, 20);
            this.txtBanco.TabIndex = 234;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 3);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(50, 13);
            this.label29.TabIndex = 233;
            this.label29.Text = "Conta Nº";
            // 
            // btGravarItec
            // 
            this.btGravarItec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btGravarItec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGravarItec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGravarItec.Location = new System.Drawing.Point(455, 11);
            this.btGravarItec.Name = "btGravarItec";
            this.btGravarItec.Size = new System.Drawing.Size(101, 28);
            this.btGravarItec.TabIndex = 9;
            this.btGravarItec.Text = "Tratar Arquivo";
            this.btGravarItec.UseVisualStyleBackColor = false;
            this.btGravarItec.Click += new System.EventHandler(this.btGravarItec_Click);
            // 
            // ckbValidados
            // 
            this.ckbValidados.AutoSize = true;
            this.ckbValidados.Location = new System.Drawing.Point(580, 21);
            this.ckbValidados.Name = "ckbValidados";
            this.ckbValidados.Size = new System.Drawing.Size(72, 17);
            this.ckbValidados.TabIndex = 239;
            this.ckbValidados.Text = "Validados";
            this.ckbValidados.UseVisualStyleBackColor = true;
            this.ckbValidados.Visible = false;
            // 
            // Frm_ImportarItec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 555);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(120, 100);
            this.MaximizeBox = false;
            this.Name = "Frm_ImportarItec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tela: Importar dados ITEC";
            this.Load += new System.EventHandler(this.Frm_ImportarItec_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDadosItec)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvDadosItec;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btLocalArqItec;
        private System.Windows.Forms.Label lbRegItec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btImporExcItec;
        private System.Windows.Forms.TextBox txtArqExcelItec;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btExcluirContaItec;
        private System.Windows.Forms.Button btLimpDados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpMovimento;
        private System.Windows.Forms.TextBox txtConta;
        private System.Windows.Forms.Button btContas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtRazao;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btGravarItec;
        private System.Windows.Forms.CheckBox ckbValidados;
        public System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
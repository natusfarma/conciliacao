namespace ConciliacaoBancaria_GUI.Consulta
{
    partial class Frm_ConsultaContas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.conta_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conta_banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btPesquisa = new System.Windows.Forms.Button();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRegist = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.conta_id,
            this.conta_banco,
            this.Column3,
            this.Column4});
            this.dgvDados.Location = new System.Drawing.Point(12, 43);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(626, 300);
            this.dgvDados.TabIndex = 7;
            this.dgvDados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellDoubleClick);
            // 
            // conta_id
            // 
            this.conta_id.DataPropertyName = "conta_id";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.conta_id.DefaultCellStyle = dataGridViewCellStyle6;
            this.conta_id.HeaderText = "Nº Id";
            this.conta_id.Name = "conta_id";
            this.conta_id.ReadOnly = true;
            this.conta_id.Width = 60;
            // 
            // conta_banco
            // 
            this.conta_banco.DataPropertyName = "conta_banco";
            this.conta_banco.HeaderText = "Banco";
            this.conta_banco.Name = "conta_banco";
            this.conta_banco.ReadOnly = true;
            this.conta_banco.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "conta_num";
            this.Column3.HeaderText = "N° da Conta";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "conta_razao";
            this.Column4.HeaderText = "Grupo Econômico";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // btPesquisa
            // 
            this.btPesquisa.BackColor = System.Drawing.SystemColors.Window;
            this.btPesquisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPesquisa.Location = new System.Drawing.Point(295, 12);
            this.btPesquisa.Name = "btPesquisa";
            this.btPesquisa.Size = new System.Drawing.Size(121, 23);
            this.btPesquisa.TabIndex = 6;
            this.btPesquisa.Text = "Pesquisa";
            this.btPesquisa.UseVisualStyleBackColor = false;
            this.btPesquisa.Click += new System.EventHandler(this.btPesquisa_Click);
            // 
            // txtBusca
            // 
            this.txtBusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBusca.Location = new System.Drawing.Point(69, 14);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(200, 20);
            this.txtBusca.TabIndex = 5;
            this.txtBusca.Enter += new System.EventHandler(this.txtBusca_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Busca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nº de registro(s):";
            // 
            // lbRegist
            // 
            this.lbRegist.AutoSize = true;
            this.lbRegist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbRegist.Location = new System.Drawing.Point(121, 348);
            this.lbRegist.Name = "lbRegist";
            this.lbRegist.Size = new System.Drawing.Size(14, 13);
            this.lbRegist.TabIndex = 9;
            this.lbRegist.Text = "0";
            // 
            // Frm_ConsultaContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 388);
            this.Controls.Add(this.lbRegist);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.btPesquisa);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConsultaContas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela: Consulta de Contas Bancárias";
            this.Load += new System.EventHandler(this.Frm_ConsultaContas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_ConsultaContas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn conta_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn conta_banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btPesquisa;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRegist;
    }
}
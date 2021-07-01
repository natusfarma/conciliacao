namespace ConciliacaoBancaria_GUI.Consulta
{
    partial class Frm_ConsultaIndicador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConsultaIndicador));
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbLancamento = new System.Windows.Forms.RadioButton();
            this.rbMovimento = new System.Windows.Forms.RadioButton();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbReg = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.btExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6});
            this.dgvDados.Location = new System.Drawing.Point(21, 55);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.Size = new System.Drawing.Size(716, 356);
            this.dgvDados.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ind_id";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Nº Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ind_dtlanc";
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Data Lancto";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ind_dtmov";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Data Mov";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ind_filial_id";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "Filial";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "tipoErro";
            this.Column6.HeaderText = "Tipo de Erro";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // rbLancamento
            // 
            this.rbLancamento.AutoSize = true;
            this.rbLancamento.Checked = true;
            this.rbLancamento.Location = new System.Drawing.Point(189, 11);
            this.rbLancamento.Name = "rbLancamento";
            this.rbLancamento.Size = new System.Drawing.Size(125, 17);
            this.rbLancamento.TabIndex = 1;
            this.rbLancamento.TabStop = true;
            this.rbLancamento.Text = "Data de Lançamento";
            this.rbLancamento.UseVisualStyleBackColor = true;
            this.rbLancamento.CheckedChanged += new System.EventHandler(this.rbLancamento_CheckedChanged);
            // 
            // rbMovimento
            // 
            this.rbMovimento.AutoSize = true;
            this.rbMovimento.Location = new System.Drawing.Point(189, 32);
            this.rbMovimento.Name = "rbMovimento";
            this.rbMovimento.Size = new System.Drawing.Size(118, 17);
            this.rbMovimento.TabIndex = 2;
            this.rbMovimento.Text = "Data de Movimento";
            this.rbMovimento.UseVisualStyleBackColor = true;
            this.rbMovimento.CheckedChanged += new System.EventHandler(this.rbLancamento_CheckedChanged);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(445, 7);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(99, 20);
            this.dtpInicio.TabIndex = 3;
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(445, 31);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(99, 20);
            this.dtpFim.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(376, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data Inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data Fim:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nº de Registro(s):";
            // 
            // lbReg
            // 
            this.lbReg.AutoSize = true;
            this.lbReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReg.ForeColor = System.Drawing.Color.Maroon;
            this.lbReg.Location = new System.Drawing.Point(132, 417);
            this.lbReg.Name = "lbReg";
            this.lbReg.Size = new System.Drawing.Size(14, 13);
            this.lbReg.TabIndex = 8;
            this.lbReg.Text = "0";
            // 
            // btPesquisar
            // 
            this.btPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.btPesquisar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btPesquisar.BackgroundImage")));
            this.btPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btPesquisar.FlatAppearance.BorderSize = 0;
            this.btPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPesquisar.Location = new System.Drawing.Point(562, 7);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(65, 44);
            this.btPesquisar.TabIndex = 240;
            this.btPesquisar.UseVisualStyleBackColor = false;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // btExcel
            // 
            this.btExcel.BackColor = System.Drawing.Color.Transparent;
            this.btExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btExcel.BackgroundImage")));
            this.btExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btExcel.FlatAppearance.BorderSize = 0;
            this.btExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcel.Location = new System.Drawing.Point(648, 7);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(65, 44);
            this.btExcel.TabIndex = 241;
            this.btExcel.UseVisualStyleBackColor = false;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // Frm_ConsultaIndicador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(758, 447);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.btPesquisar);
            this.Controls.Add(this.lbReg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFim);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.rbMovimento);
            this.Controls.Add(this.rbLancamento);
            this.Controls.Add(this.dgvDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(120, 100);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConsultaIndicador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tela: Consulta de Indicadores";
            this.Load += new System.EventHandler(this.Frm_ConsultaIndicador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.RadioButton rbLancamento;
        private System.Windows.Forms.RadioButton rbMovimento;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbReg;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
namespace ConciliacaoBancaria_GUI
{
    partial class Frm_Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MpCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.contasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agênciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MpImportacao = new System.Windows.Forms.ToolStripMenuItem();
            this.MsImportItec = new System.Windows.Forms.ToolStripMenuItem();
            this.MpImportExt = new System.Windows.Forms.ToolStripMenuItem();
            this.mpConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.msConsItec_Extrato = new System.Windows.Forms.ToolStripMenuItem();
            this.msConsIndicador = new System.Windows.Forms.ToolStripMenuItem();
            this.msConsulErros = new System.Windows.Forms.ToolStripMenuItem();
            this.mpSair = new System.Windows.Forms.ToolStripMenuItem();
            this.MpJanelas = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MpCadastro,
            this.MpImportacao,
            this.mpConsulta,
            this.mpSair,
            this.MpJanelas});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.MpJanelas;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(841, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MpCadastro
            // 
            this.MpCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contasToolStripMenuItem,
            this.agênciasToolStripMenuItem});
            this.MpCadastro.Name = "MpCadastro";
            this.MpCadastro.Size = new System.Drawing.Size(66, 20);
            this.MpCadastro.Text = "Cadastro";
            // 
            // contasToolStripMenuItem
            // 
            this.contasToolStripMenuItem.Enabled = false;
            this.contasToolStripMenuItem.Name = "contasToolStripMenuItem";
            this.contasToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.contasToolStripMenuItem.Text = "Contas";
            // 
            // agênciasToolStripMenuItem
            // 
            this.agênciasToolStripMenuItem.Enabled = false;
            this.agênciasToolStripMenuItem.Name = "agênciasToolStripMenuItem";
            this.agênciasToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.agênciasToolStripMenuItem.Text = "Agências/Filial";
            // 
            // MpImportacao
            // 
            this.MpImportacao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsImportItec,
            this.MpImportExt});
            this.MpImportacao.Name = "MpImportacao";
            this.MpImportacao.Size = new System.Drawing.Size(80, 20);
            this.MpImportacao.Text = "Importação";
            // 
            // MsImportItec
            // 
            this.MsImportItec.Name = "MsImportItec";
            this.MsImportItec.Size = new System.Drawing.Size(165, 22);
            this.MsImportItec.Text = "Importar Itec";
            this.MsImportItec.Click += new System.EventHandler(this.MsImportItec_Click);
            // 
            // MpImportExt
            // 
            this.MpImportExt.Name = "MpImportExt";
            this.MpImportExt.Size = new System.Drawing.Size(165, 22);
            this.MpImportExt.Text = "Importar Extratos";
            this.MpImportExt.Click += new System.EventHandler(this.MpImportExt_Click);
            // 
            // mpConsulta
            // 
            this.mpConsulta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msConsItec_Extrato,
            this.toolStripMenuItem1,
            this.msConsIndicador,
            this.msConsulErros});
            this.mpConsulta.Name = "mpConsulta";
            this.mpConsulta.Size = new System.Drawing.Size(66, 20);
            this.mpConsulta.Text = "Consulta";
            // 
            // msConsItec_Extrato
            // 
            this.msConsItec_Extrato.Name = "msConsItec_Extrato";
            this.msConsItec_Extrato.Size = new System.Drawing.Size(239, 22);
            this.msConsItec_Extrato.Text = "Consulta: Itec x Extrato";
            this.msConsItec_Extrato.Click += new System.EventHandler(this.msConsItec_Extrato_Click);
            // 
            // msConsIndicador
            // 
            this.msConsIndicador.Name = "msConsIndicador";
            this.msConsIndicador.Size = new System.Drawing.Size(239, 22);
            this.msConsIndicador.Text = "Indicador";
            this.msConsIndicador.Click += new System.EventHandler(this.MsConsIndicador_Click);
            // 
            // msConsulErros
            // 
            this.msConsulErros.Name = "msConsulErros";
            this.msConsulErros.Size = new System.Drawing.Size(239, 22);
            this.msConsulErros.Text = "Erros a corrigir";
            this.msConsulErros.Click += new System.EventHandler(this.msConsulErros_Click);
            // 
            // mpSair
            // 
            this.mpSair.Name = "mpSair";
            this.mpSair.Size = new System.Drawing.Size(38, 20);
            this.mpSair.Text = "Sair";
            this.mpSair.Click += new System.EventHandler(this.mpSair_Click);
            // 
            // MpJanelas
            // 
            this.MpJanelas.Name = "MpJanelas";
            this.MpJanelas.Size = new System.Drawing.Size(56, 20);
            this.MpJanelas.Text = "Janelas";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(1, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 43);
            this.panel1.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(841, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem1.Text = "Não Localizados - Itex x Extrato";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "Frm_Principal";
            this.Text = "NATUS FARMA - Conciliação Bancária";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MpCadastro;
        private System.Windows.Forms.ToolStripMenuItem contasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agênciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MpImportacao;
        private System.Windows.Forms.ToolStripMenuItem MsImportItec;
        private System.Windows.Forms.ToolStripMenuItem MpImportExt;
        private System.Windows.Forms.ToolStripMenuItem mpConsulta;
        private System.Windows.Forms.ToolStripMenuItem msConsItec_Extrato;
        private System.Windows.Forms.ToolStripMenuItem mpSair;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem msConsIndicador;
        private System.Windows.Forms.ToolStripMenuItem MpJanelas;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem msConsulErros;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}


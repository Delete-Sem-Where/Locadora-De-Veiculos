namespace LocadoraDeVeiculos.WinApp
{
    partial class TelaPrincipalForm
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pessoaJurídicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pessoasFísicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupoVeículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planoDeCobrançaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbox = new System.Windows.Forms.ToolStrip();
            this.btnInserir = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnDevolucao = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.menu.SuspendLayout();
            this.toolbox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menu.Size = new System.Drawing.Size(1168, 25);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funcionárioToolStripMenuItem,
            this.pessoaJurídicaToolStripMenuItem,
            this.pessoasFísicasToolStripMenuItem,
            this.taxasToolStripMenuItem,
            this.grupoVeículosToolStripMenuItem,
            this.veículosToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.condutorToolStripMenuItem,
            this.planoDeCobrançaToolStripMenuItem,
            this.locaçãoToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 19);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // funcionárioToolStripMenuItem
            // 
            this.funcionárioToolStripMenuItem.Name = "funcionárioToolStripMenuItem";
            this.funcionárioToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.funcionárioToolStripMenuItem.Text = "Funcionário";
            this.funcionárioToolStripMenuItem.Click += new System.EventHandler(this.funcionárioToolStripMenuItem_Click);
            // 
            // pessoaJurídicaToolStripMenuItem
            // 
            this.pessoaJurídicaToolStripMenuItem.Name = "pessoaJurídicaToolStripMenuItem";
            this.pessoaJurídicaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pessoaJurídicaToolStripMenuItem.Text = "Pessoa Jurídica";
            this.pessoaJurídicaToolStripMenuItem.Click += new System.EventHandler(this.pessoaJurídicaToolStripMenuItem_Click);
            // 
            // pessoasFísicasToolStripMenuItem
            // 
            this.pessoasFísicasToolStripMenuItem.Name = "pessoasFísicasToolStripMenuItem";
            this.pessoasFísicasToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pessoasFísicasToolStripMenuItem.Text = "Pessoa Física";
            this.pessoasFísicasToolStripMenuItem.Click += new System.EventHandler(this.pessoasFísicasToolStripMenuItem_Click);
            // 
            // taxasToolStripMenuItem
            // 
            this.taxasToolStripMenuItem.Name = "taxasToolStripMenuItem";
            this.taxasToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.taxasToolStripMenuItem.Text = "Taxas";
            this.taxasToolStripMenuItem.Click += new System.EventHandler(this.taxasToolStripMenuItem_Click);
            // 
            // grupoVeículosToolStripMenuItem
            // 
            this.grupoVeículosToolStripMenuItem.Name = "grupoVeículosToolStripMenuItem";
            this.grupoVeículosToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.grupoVeículosToolStripMenuItem.Text = "Grupo Veículos";
            this.grupoVeículosToolStripMenuItem.Click += new System.EventHandler(this.grupoVeículosToolStripMenuItem_Click);
            // 
            // veículosToolStripMenuItem
            // 
            this.veículosToolStripMenuItem.Name = "veículosToolStripMenuItem";
            this.veículosToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.veículosToolStripMenuItem.Text = "Veículos";
            this.veículosToolStripMenuItem.Click += new System.EventHandler(this.veículosToolStripMenuItem_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // condutorToolStripMenuItem
            // 
            this.condutorToolStripMenuItem.Name = "condutorToolStripMenuItem";
            this.condutorToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.condutorToolStripMenuItem.Text = "Condutor";
            this.condutorToolStripMenuItem.Click += new System.EventHandler(this.condutorToolStripMenuItem_Click);
            // 
            // planoDeCobrançaToolStripMenuItem
            // 
            this.planoDeCobrançaToolStripMenuItem.Name = "planoDeCobrançaToolStripMenuItem";
            this.planoDeCobrançaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.planoDeCobrançaToolStripMenuItem.Text = "Plano de Cobrança";
            this.planoDeCobrançaToolStripMenuItem.Click += new System.EventHandler(this.planoDeCobrançaToolStripMenuItem_Click);
            // 
            // locaçãoToolStripMenuItem
            // 
            this.locaçãoToolStripMenuItem.Name = "locaçãoToolStripMenuItem";
            this.locaçãoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.locaçãoToolStripMenuItem.Text = "Locação";
            this.locaçãoToolStripMenuItem.Click += new System.EventHandler(this.locacaoToolStripMenuItem_Click);
            // 
            // toolbox
            // 
            this.toolbox.Enabled = false;
            this.toolbox.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInserir,
            this.btnEditar,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.btnDevolucao,
            this.toolStripSeparator4,
            this.labelTipoCadastro});
            this.toolbox.Location = new System.Drawing.Point(0, 25);
            this.toolbox.Name = "toolbox";
            this.toolbox.Size = new System.Drawing.Size(1168, 41);
            this.toolbox.TabIndex = 1;
            this.toolbox.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            this.btnInserir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInserir.Image = global::LocadoraDeVeiculos.WinApp.Properties.Resources.outline_add_circle_outline_black_24dp;
            this.btnInserir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Padding = new System.Windows.Forms.Padding(5);
            this.btnInserir.Size = new System.Drawing.Size(38, 38);
            this.btnInserir.Text = "Inserir";
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = global::LocadoraDeVeiculos.WinApp.Properties.Resources.outline_mode_edit_black_24dp;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(5);
            this.btnEditar.Size = new System.Drawing.Size(38, 38);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnDevolucao
            // 
            this.btnDevolucao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDevolucao.Image = global::LocadoraDeVeiculos.WinApp.Properties.Resources.no_crash_FILL0_wght400_GRAD0_opsz24;
            this.btnDevolucao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDevolucao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevolucao.Name = "btnDevolucao";
            this.btnDevolucao.Padding = new System.Windows.Forms.Padding(5);
            this.btnDevolucao.Size = new System.Drawing.Size(38, 38);
            this.btnDevolucao.Text = "Devolucao";
            this.btnDevolucao.Click += new System.EventHandler(this.btnDevolucao_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(90, 38);
            this.labelTipoCadastro.Text = "[tipoCadastro]";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodape});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1168, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(52, 17);
            this.labelRodape.Text = "[rodapé]";
            // 
            // panelRegistros
            // 
            this.panelRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegistros.Location = new System.Drawing.Point(0, 66);
            this.panelRegistros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(1168, 473);
            this.panelRegistros.TabIndex = 3;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::LocadoraDeVeiculos.WinApp.Properties.Resources.outline_delete_black_24dp;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripButton2.Size = new System.Drawing.Size(38, 38);
            this.toolStripButton2.Text = "Excluir";
            // 
            // TelaPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 561);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolbox);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "TelaPrincipalForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locadora de Veículos";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolbox.ResumeLayout(false);
            this.toolbox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolbox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.ToolStripButton btnInserir;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem funcionárioToolStripMenuItem;
        private ToolStripMenuItem pessoaJurídicaToolStripMenuItem;
        private ToolStripMenuItem pessoasFísicasToolStripMenuItem;
        private ToolStripMenuItem taxasToolStripMenuItem;
        private ToolStripMenuItem grupoVeículosToolStripMenuItem;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem condutorToolStripMenuItem;
        private ToolStripMenuItem planoDeCobrançaToolStripMenuItem;
        private ToolStripMenuItem veículosToolStripMenuItem;
        private ToolStripMenuItem locaçãoToolStripMenuItem;
        private ToolStripButton btnDevolucao;
        private ToolStripButton toolStripButton2;
    }
}
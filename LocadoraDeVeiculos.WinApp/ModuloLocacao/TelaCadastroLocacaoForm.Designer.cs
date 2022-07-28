namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    partial class TelaCadastroLocacaoForm
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
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonCancelarPf = new System.Windows.Forms.Button();
            this.buttonGravarPf = new System.Windows.Forms.Button();
            this.cmbCondutores = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVeiculos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGrupoVeiculos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPlanoCobranca = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKmRodado = new System.Windows.Forms.TextBox();
            this.datePickerDataLocacao = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimeDataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.tabTaxas = new System.Windows.Forms.TabControl();
            this.pageTaxas = new System.Windows.Forms.TabPage();
            this.listTaxas = new System.Windows.Forms.CheckedListBox();
            this.txtValorTotalPrevisto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblInformacaoPlanoCobranca = new System.Windows.Forms.Label();
            this.tabTaxas.SuspendLayout();
            this.pageTaxas.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbClientes
            // 
            this.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(91, 56);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(233, 28);
            this.cmbClientes.TabIndex = 77;
            this.cmbClientes.SelectedIndexChanged += new System.EventHandler(this.cmbClientes_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 82;
            this.label9.Text = "Cliente:";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(91, 13);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(34, 27);
            this.txtNumero.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 80;
            this.label7.Text = "Numero:";
            // 
            // buttonCancelarPf
            // 
            this.buttonCancelarPf.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarPf.Location = new System.Drawing.Point(606, 421);
            this.buttonCancelarPf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancelarPf.Name = "buttonCancelarPf";
            this.buttonCancelarPf.Size = new System.Drawing.Size(94, 51);
            this.buttonCancelarPf.TabIndex = 79;
            this.buttonCancelarPf.Text = "Cancelar";
            this.buttonCancelarPf.UseVisualStyleBackColor = true;
            // 
            // buttonGravarPf
            // 
            this.buttonGravarPf.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravarPf.Location = new System.Drawing.Point(488, 421);
            this.buttonGravarPf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGravarPf.Name = "buttonGravarPf";
            this.buttonGravarPf.Size = new System.Drawing.Size(94, 51);
            this.buttonGravarPf.TabIndex = 78;
            this.buttonGravarPf.Text = "Gravar";
            this.buttonGravarPf.UseVisualStyleBackColor = true;
            this.buttonGravarPf.Click += new System.EventHandler(this.buttonGravarPf_Click);
            // 
            // cmbCondutores
            // 
            this.cmbCondutores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondutores.FormattingEnabled = true;
            this.cmbCondutores.Location = new System.Drawing.Point(467, 56);
            this.cmbCondutores.Name = "cmbCondutores";
            this.cmbCondutores.Size = new System.Drawing.Size(233, 28);
            this.cmbCondutores.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 84;
            this.label1.Text = "Condutor:";
            // 
            // cmbVeiculos
            // 
            this.cmbVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVeiculos.FormattingEnabled = true;
            this.cmbVeiculos.Location = new System.Drawing.Point(467, 111);
            this.cmbVeiculos.Name = "cmbVeiculos";
            this.cmbVeiculos.Size = new System.Drawing.Size(233, 28);
            this.cmbVeiculos.TabIndex = 87;
            this.cmbVeiculos.SelectedIndexChanged += new System.EventHandler(this.cmbVeiculos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 88;
            this.label2.Text = "Veículo:";
            // 
            // cmbGrupoVeiculos
            // 
            this.cmbGrupoVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoVeiculos.FormattingEnabled = true;
            this.cmbGrupoVeiculos.Location = new System.Drawing.Point(91, 111);
            this.cmbGrupoVeiculos.Name = "cmbGrupoVeiculos";
            this.cmbGrupoVeiculos.Size = new System.Drawing.Size(233, 28);
            this.cmbGrupoVeiculos.TabIndex = 85;
            this.cmbGrupoVeiculos.SelectedIndexChanged += new System.EventHandler(this.cmbGrupoVeiculos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 46);
            this.label3.TabIndex = 86;
            this.label3.Text = "Grupo de Veículos:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(381, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 43);
            this.label4.TabIndex = 92;
            this.label4.Text = "Km do Veículo:";
            // 
            // cmbPlanoCobranca
            // 
            this.cmbPlanoCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanoCobranca.FormattingEnabled = true;
            this.cmbPlanoCobranca.Location = new System.Drawing.Point(91, 179);
            this.cmbPlanoCobranca.Name = "cmbPlanoCobranca";
            this.cmbPlanoCobranca.Size = new System.Drawing.Size(233, 28);
            this.cmbPlanoCobranca.TabIndex = 89;
            this.cmbPlanoCobranca.SelectedIndexChanged += new System.EventHandler(this.cmbPlanoCobranca_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 46);
            this.label5.TabIndex = 90;
            this.label5.Text = "Plano de Cobrança:";
            // 
            // txtKmRodado
            // 
            this.txtKmRodado.Enabled = false;
            this.txtKmRodado.Location = new System.Drawing.Point(467, 180);
            this.txtKmRodado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKmRodado.Name = "txtKmRodado";
            this.txtKmRodado.ReadOnly = true;
            this.txtKmRodado.Size = new System.Drawing.Size(233, 27);
            this.txtKmRodado.TabIndex = 93;
            // 
            // datePickerDataLocacao
            // 
            this.datePickerDataLocacao.Location = new System.Drawing.Point(91, 248);
            this.datePickerDataLocacao.Name = "datePickerDataLocacao";
            this.datePickerDataLocacao.Size = new System.Drawing.Size(233, 27);
            this.datePickerDataLocacao.TabIndex = 94;
            this.datePickerDataLocacao.ValueChanged += new System.EventHandler(this.datePickerDataLocacao_ValueChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 46);
            this.label6.TabIndex = 95;
            this.label6.Text = "Data de Locação:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(381, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 47);
            this.label8.TabIndex = 97;
            this.label8.Text = "Devolução Prevista:";
            // 
            // dateTimeDataDevolucao
            // 
            this.dateTimeDataDevolucao.Location = new System.Drawing.Point(467, 248);
            this.dateTimeDataDevolucao.Name = "dateTimeDataDevolucao";
            this.dateTimeDataDevolucao.Size = new System.Drawing.Size(233, 27);
            this.dateTimeDataDevolucao.TabIndex = 96;
            this.dateTimeDataDevolucao.ValueChanged += new System.EventHandler(this.dateTimeDataDevolucao_ValueChanged);
            // 
            // tabTaxas
            // 
            this.tabTaxas.Controls.Add(this.pageTaxas);
            this.tabTaxas.Location = new System.Drawing.Point(10, 305);
            this.tabTaxas.Name = "tabTaxas";
            this.tabTaxas.SelectedIndex = 0;
            this.tabTaxas.Size = new System.Drawing.Size(314, 167);
            this.tabTaxas.TabIndex = 98;
            // 
            // pageTaxas
            // 
            this.pageTaxas.Controls.Add(this.listTaxas);
            this.pageTaxas.Location = new System.Drawing.Point(4, 29);
            this.pageTaxas.Name = "pageTaxas";
            this.pageTaxas.Padding = new System.Windows.Forms.Padding(3);
            this.pageTaxas.Size = new System.Drawing.Size(306, 134);
            this.pageTaxas.TabIndex = 0;
            this.pageTaxas.Text = "Taxas da Locação";
            this.pageTaxas.UseVisualStyleBackColor = true;
            // 
            // listTaxas
            // 
            this.listTaxas.CheckOnClick = true;
            this.listTaxas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTaxas.FormattingEnabled = true;
            this.listTaxas.Location = new System.Drawing.Point(3, 3);
            this.listTaxas.Name = "listTaxas";
            this.listTaxas.Size = new System.Drawing.Size(300, 128);
            this.listTaxas.TabIndex = 101;
            this.listTaxas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listTaxas_ItemCheck);
            // 
            // txtValorTotalPrevisto
            // 
            this.txtValorTotalPrevisto.Enabled = false;
            this.txtValorTotalPrevisto.Location = new System.Drawing.Point(531, 323);
            this.txtValorTotalPrevisto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtValorTotalPrevisto.Name = "txtValorTotalPrevisto";
            this.txtValorTotalPrevisto.ReadOnly = true;
            this.txtValorTotalPrevisto.Size = new System.Drawing.Size(169, 27);
            this.txtValorTotalPrevisto.TabIndex = 100;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(387, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 20);
            this.label10.TabIndex = 99;
            this.label10.Text = "Valor total previsto:";
            // 
            // lblInformacaoPlanoCobranca
            // 
            this.lblInformacaoPlanoCobranca.AutoSize = true;
            this.lblInformacaoPlanoCobranca.Font = new System.Drawing.Font("Segoe UI", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblInformacaoPlanoCobranca.Location = new System.Drawing.Point(387, 356);
            this.lblInformacaoPlanoCobranca.Name = "lblInformacaoPlanoCobranca";
            this.lblInformacaoPlanoCobranca.Size = new System.Drawing.Size(0, 17);
            this.lblInformacaoPlanoCobranca.TabIndex = 101;
            // 
            // TelaCadastroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 493);
            this.Controls.Add(this.lblInformacaoPlanoCobranca);
            this.Controls.Add(this.txtValorTotalPrevisto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tabTaxas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimeDataDevolucao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.datePickerDataLocacao);
            this.Controls.Add(this.txtKmRodado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPlanoCobranca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbVeiculos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbGrupoVeiculos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCondutores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonCancelarPf);
            this.Controls.Add(this.buttonGravarPf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroLocacaoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Locação";
            this.tabTaxas.ResumeLayout(false);
            this.pageTaxas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmbClientes;
        private Label label9;
        private TextBox txtNumero;
        private Label label7;
        private Button buttonCancelarPf;
        private Button buttonGravarPf;
        private ComboBox cmbCondutores;
        private Label label1;
        private ComboBox cmbVeiculos;
        private Label label2;
        private ComboBox cmbGrupoVeiculos;
        private Label label3;
        private Label label4;
        private ComboBox cmbPlanoCobranca;
        private Label label5;
        private TextBox txtKmRodado;
        private DateTimePicker datePickerDataLocacao;
        private Label label6;
        private Label label8;
        private DateTimePicker dateTimeDataDevolucao;
        private TabControl tabTaxas;
        private TabPage pageTaxas;
        private TextBox txtValorTotalPrevisto;
        private Label label10;
        private CheckedListBox listTaxas;
        private Label lblInformacaoPlanoCobranca;
    }
}
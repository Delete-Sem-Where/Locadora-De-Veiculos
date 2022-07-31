namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    partial class TelaCadastroDevolucaoForm
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerDataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.cmbNivelTanque = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabTaxas = new System.Windows.Forms.TabControl();
            this.pageTaxas = new System.Windows.Forms.TabPage();
            this.listTaxas = new System.Windows.Forms.CheckedListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listTaxas2 = new System.Windows.Forms.CheckedListBox();
            this.buttonCancelarPf = new System.Windows.Forms.Button();
            this.btnGravarDevolucao = new System.Windows.Forms.Button();
            this.txtValorTotalDevolucao = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePickerDataDevolucaoPrevista = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDataLocacao = new System.Windows.Forms.DateTimePicker();
            this.lblPlanoCobranca = new System.Windows.Forms.Label();
            this.lblVeiculo = new System.Windows.Forms.Label();
            this.lblGrupoVeiculos = new System.Windows.Forms.Label();
            this.lblCondutor = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.numericKm = new System.Windows.Forms.NumericUpDown();
            this.tabTaxas.SuspendLayout();
            this.pageTaxas.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericKm)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(77, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 85;
            this.label9.Text = "Cliente:";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(154, 11);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(53, 27);
            this.txtNumero.TabIndex = 84;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(73, 15);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(66, 20);
            this.lblNumero.TabIndex = 83;
            this.lblNumero.Text = "Numero:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 29);
            this.label3.TabIndex = 88;
            this.label3.Text = "Grupo de Veículos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 87;
            this.label1.Text = "Condutor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 89;
            this.label2.Text = "Veículo:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 56);
            this.label5.TabIndex = 91;
            this.label5.Text = "Modalidade do Plano de Cobrança:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(358, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 27);
            this.label6.TabIndex = 96;
            this.label6.Text = "Data de Locação:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(358, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 27);
            this.label8.TabIndex = 98;
            this.label8.Text = "Devolução Prevista:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(365, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 99;
            this.label4.Text = "Km do Veículo:";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(350, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 27);
            this.label10.TabIndex = 102;
            this.label10.Text = "Data de Devolução:";
            // 
            // dateTimePickerDataDevolucao
            // 
            this.dateTimePickerDataDevolucao.Enabled = false;
            this.dateTimePickerDataDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataDevolucao.Location = new System.Drawing.Point(514, 185);
            this.dateTimePickerDataDevolucao.Name = "dateTimePickerDataDevolucao";
            this.dateTimePickerDataDevolucao.Size = new System.Drawing.Size(266, 27);
            this.dateTimePickerDataDevolucao.TabIndex = 101;
            // 
            // cmbNivelTanque
            // 
            this.cmbNivelTanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivelTanque.FormattingEnabled = true;
            this.cmbNivelTanque.Location = new System.Drawing.Point(514, 238);
            this.cmbNivelTanque.Name = "cmbNivelTanque";
            this.cmbNivelTanque.Size = new System.Drawing.Size(266, 28);
            this.cmbNivelTanque.TabIndex = 103;
            this.cmbNivelTanque.SelectedIndexChanged += new System.EventHandler(this.nivelTanque_alterado);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(350, 229);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 47);
            this.label11.TabIndex = 104;
            this.label11.Text = "Nível do Tanque de Combustível:";
            // 
            // tabTaxas
            // 
            this.tabTaxas.Controls.Add(this.pageTaxas);
            this.tabTaxas.Controls.Add(this.tabPage1);
            this.tabTaxas.Location = new System.Drawing.Point(7, 283);
            this.tabTaxas.Name = "tabTaxas";
            this.tabTaxas.SelectedIndex = 0;
            this.tabTaxas.Size = new System.Drawing.Size(502, 252);
            this.tabTaxas.TabIndex = 105;
            // 
            // pageTaxas
            // 
            this.pageTaxas.AccessibleDescription = "";
            this.pageTaxas.Controls.Add(this.listTaxas);
            this.pageTaxas.Location = new System.Drawing.Point(4, 29);
            this.pageTaxas.Name = "pageTaxas";
            this.pageTaxas.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pageTaxas.Size = new System.Drawing.Size(494, 219);
            this.pageTaxas.TabIndex = 0;
            this.pageTaxas.Text = "Taxas da Locação";
            this.pageTaxas.UseVisualStyleBackColor = true;
            // 
            // listTaxas
            // 
            this.listTaxas.CheckOnClick = true;
            this.listTaxas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTaxas.Enabled = false;
            this.listTaxas.FormattingEnabled = true;
            this.listTaxas.Location = new System.Drawing.Point(3, 3);
            this.listTaxas.Name = "listTaxas";
            this.listTaxas.Size = new System.Drawing.Size(488, 213);
            this.listTaxas.TabIndex = 101;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listTaxas2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(494, 219);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Taxas Adicionais";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listTaxas2
            // 
            this.listTaxas2.CheckOnClick = true;
            this.listTaxas2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTaxas2.FormattingEnabled = true;
            this.listTaxas2.Location = new System.Drawing.Point(3, 4);
            this.listTaxas2.Name = "listTaxas2";
            this.listTaxas2.Size = new System.Drawing.Size(488, 211);
            this.listTaxas2.TabIndex = 102;
            this.listTaxas2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listTaxas_ItemCheck);
            // 
            // buttonCancelarPf
            // 
            this.buttonCancelarPf.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarPf.Location = new System.Drawing.Point(686, 530);
            this.buttonCancelarPf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancelarPf.Name = "buttonCancelarPf";
            this.buttonCancelarPf.Size = new System.Drawing.Size(94, 51);
            this.buttonCancelarPf.TabIndex = 107;
            this.buttonCancelarPf.Text = "Cancelar";
            this.buttonCancelarPf.UseVisualStyleBackColor = true;
            // 
            // btnGravarDevolucao
            // 
            this.btnGravarDevolucao.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravarDevolucao.Location = new System.Drawing.Point(580, 530);
            this.btnGravarDevolucao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGravarDevolucao.Name = "btnGravarDevolucao";
            this.btnGravarDevolucao.Size = new System.Drawing.Size(94, 51);
            this.btnGravarDevolucao.TabIndex = 106;
            this.btnGravarDevolucao.Text = "Gravar";
            this.btnGravarDevolucao.UseVisualStyleBackColor = true;
            this.btnGravarDevolucao.Click += new System.EventHandler(this.btnGravarDevolucao_Click);
            // 
            // txtValorTotalDevolucao
            // 
            this.txtValorTotalDevolucao.Enabled = false;
            this.txtValorTotalDevolucao.Location = new System.Drawing.Point(333, 546);
            this.txtValorTotalDevolucao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtValorTotalDevolucao.Name = "txtValorTotalDevolucao";
            this.txtValorTotalDevolucao.ReadOnly = true;
            this.txtValorTotalDevolucao.Size = new System.Drawing.Size(169, 27);
            this.txtValorTotalDevolucao.TabIndex = 109;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(166, 549);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(161, 20);
            this.label12.TabIndex = 108;
            this.label12.Text = "Valor total da Locação:";
            // 
            // dateTimePickerDataDevolucaoPrevista
            // 
            this.dateTimePickerDataDevolucaoPrevista.Enabled = false;
            this.dateTimePickerDataDevolucaoPrevista.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataDevolucaoPrevista.Location = new System.Drawing.Point(514, 100);
            this.dateTimePickerDataDevolucaoPrevista.Name = "dateTimePickerDataDevolucaoPrevista";
            this.dateTimePickerDataDevolucaoPrevista.Size = new System.Drawing.Size(266, 27);
            this.dateTimePickerDataDevolucaoPrevista.TabIndex = 110;
            // 
            // dateTimePickerDataLocacao
            // 
            this.dateTimePickerDataLocacao.Enabled = false;
            this.dateTimePickerDataLocacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataLocacao.Location = new System.Drawing.Point(514, 56);
            this.dateTimePickerDataLocacao.Name = "dateTimePickerDataLocacao";
            this.dateTimePickerDataLocacao.Size = new System.Drawing.Size(266, 27);
            this.dateTimePickerDataLocacao.TabIndex = 111;
            // 
            // lblPlanoCobranca
            // 
            this.lblPlanoCobranca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlanoCobranca.Location = new System.Drawing.Point(151, 241);
            this.lblPlanoCobranca.Name = "lblPlanoCobranca";
            this.lblPlanoCobranca.Size = new System.Drawing.Size(151, 23);
            this.lblPlanoCobranca.TabIndex = 116;
            this.lblPlanoCobranca.Text = "Plano de Cobrança";
            // 
            // lblVeiculo
            // 
            this.lblVeiculo.AutoSize = true;
            this.lblVeiculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVeiculo.Location = new System.Drawing.Point(151, 185);
            this.lblVeiculo.Name = "lblVeiculo";
            this.lblVeiculo.Size = new System.Drawing.Size(59, 20);
            this.lblVeiculo.TabIndex = 115;
            this.lblVeiculo.Text = "Veículo";
            // 
            // lblGrupoVeiculos
            // 
            this.lblGrupoVeiculos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGrupoVeiculos.Location = new System.Drawing.Point(151, 137);
            this.lblGrupoVeiculos.Name = "lblGrupoVeiculos";
            this.lblGrupoVeiculos.Size = new System.Drawing.Size(137, 29);
            this.lblGrupoVeiculos.TabIndex = 114;
            this.lblGrupoVeiculos.Text = "Grupo de Veículos";
            // 
            // lblCondutor
            // 
            this.lblCondutor.AutoSize = true;
            this.lblCondutor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCondutor.Location = new System.Drawing.Point(151, 98);
            this.lblCondutor.Name = "lblCondutor";
            this.lblCondutor.Size = new System.Drawing.Size(75, 20);
            this.lblCondutor.TabIndex = 113;
            this.lblCondutor.Text = "Condutor";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCliente.Location = new System.Drawing.Point(151, 59);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(57, 20);
            this.lblCliente.TabIndex = 112;
            this.lblCliente.Text = "Cliente";
            // 
            // numericKm
            // 
            this.numericKm.InterceptArrowKeys = false;
            this.numericKm.Location = new System.Drawing.Point(514, 143);
            this.numericKm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericKm.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericKm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericKm.Name = "numericKm";
            this.numericKm.Size = new System.Drawing.Size(265, 27);
            this.numericKm.TabIndex = 117;
            this.numericKm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericKm.ValueChanged += new System.EventHandler(this.km_alterado);
            this.numericKm.Click += new System.EventHandler(this.km_alterado);
            // 
            // TelaCadastroDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 600);
            this.Controls.Add(this.numericKm);
            this.Controls.Add(this.lblPlanoCobranca);
            this.Controls.Add(this.lblVeiculo);
            this.Controls.Add(this.lblGrupoVeiculos);
            this.Controls.Add(this.lblCondutor);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.dateTimePickerDataLocacao);
            this.Controls.Add(this.dateTimePickerDataDevolucaoPrevista);
            this.Controls.Add(this.txtValorTotalDevolucao);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.buttonCancelarPf);
            this.Controls.Add(this.btnGravarDevolucao);
            this.Controls.Add(this.tabTaxas);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbNivelTanque);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTimePickerDataDevolucao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblNumero);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroDevolucaoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução";
            this.tabTaxas.ResumeLayout(false);
            this.pageTaxas.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericKm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label9;
        private TextBox txtNumero;
        private Label lblNumero;
        private Label label3;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label4;
        private Label label10;
        private DateTimePicker dateTimePickerDataDevolucao;
        private ComboBox cmbNivelTanque;
        private Label label11;
        private TabControl tabTaxas;
        private TabPage pageTaxas;
        private CheckedListBox listTaxas;
        private Button buttonCancelarPf;
        private Button btnGravarDevolucao;
        private TextBox txtValorTotalDevolucao;
        private Label label12;
        private TabPage tabPage1;
        private CheckedListBox listTaxas2;
        private DateTimePicker dateTimePickerDataDevolucaoPrevista;
        private DateTimePicker dateTimePickerDataLocacao;
        private Label lblPlanoCobranca;
        private Label lblVeiculo;
        private Label lblGrupoVeiculos;
        private Label lblCondutor;
        private Label lblCliente;
        private NumericUpDown numericKm;
    }
}
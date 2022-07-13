namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    partial class TelaCadastroPlanoCobrancaForm
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
            this.cmbGrupoVeiculos = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtValorKm_tab1 = new System.Windows.Forms.NumericUpDown();
            this.txtValorDiaria_tab1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtValorDiaria_tab2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtLimiteKm_tab3 = new System.Windows.Forms.NumericUpDown();
            this.txtValorKm_tab3 = new System.Windows.Forms.NumericUpDown();
            this.txtValorDiaria_tab3 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCancelarPf = new System.Windows.Forms.Button();
            this.buttonGravarPlanoCobranca = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorKm_tab1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDiaria_tab1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDiaria_tab2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimiteKm_tab3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorKm_tab3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDiaria_tab3)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbGrupoVeiculos
            // 
            this.cmbGrupoVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoVeiculos.FormattingEnabled = true;
            this.cmbGrupoVeiculos.Location = new System.Drawing.Point(127, 33);
            this.cmbGrupoVeiculos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbGrupoVeiculos.Name = "cmbGrupoVeiculos";
            this.cmbGrupoVeiculos.Size = new System.Drawing.Size(187, 23);
            this.cmbGrupoVeiculos.TabIndex = 77;
            this.cmbGrupoVeiculos.SelectedIndexChanged += new System.EventHandler(this.cmbGrupoVeiculos_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 15);
            this.label9.TabIndex = 78;
            this.label9.Text = "Grupo de Veículos:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Enabled = false;
            this.tabControl.Location = new System.Drawing.Point(14, 92);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(302, 235);
            this.tabControl.TabIndex = 79;
            this.tabControl.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.txtValorKm_tab1);
            this.tabPage1.Controls.Add(this.txtValorDiaria_tab1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(294, 207);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "1";
            this.tabPage1.Text = "Diário";
            // 
            // txtValorKm_tab1
            // 
            this.txtValorKm_tab1.DecimalPlaces = 2;
            this.txtValorKm_tab1.Location = new System.Drawing.Point(23, 101);
            this.txtValorKm_tab1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtValorKm_tab1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtValorKm_tab1.Name = "txtValorKm_tab1";
            this.txtValorKm_tab1.Size = new System.Drawing.Size(175, 23);
            this.txtValorKm_tab1.TabIndex = 86;
            this.txtValorKm_tab1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtValorDiaria_tab1
            // 
            this.txtValorDiaria_tab1.DecimalPlaces = 2;
            this.txtValorDiaria_tab1.InterceptArrowKeys = false;
            this.txtValorDiaria_tab1.Location = new System.Drawing.Point(23, 35);
            this.txtValorDiaria_tab1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtValorDiaria_tab1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtValorDiaria_tab1.Name = "txtValorDiaria_tab1";
            this.txtValorDiaria_tab1.Size = new System.Drawing.Size(175, 23);
            this.txtValorDiaria_tab1.TabIndex = 85;
            this.txtValorDiaria_tab1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 84;
            this.label2.Text = "Valor por Km";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 82;
            this.label1.Text = "Valor Diária";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.txtValorDiaria_tab2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(294, 207);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "2";
            this.tabPage2.Text = "Livre";
            // 
            // txtValorDiaria_tab2
            // 
            this.txtValorDiaria_tab2.DecimalPlaces = 2;
            this.txtValorDiaria_tab2.Location = new System.Drawing.Point(23, 34);
            this.txtValorDiaria_tab2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtValorDiaria_tab2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtValorDiaria_tab2.Name = "txtValorDiaria_tab2";
            this.txtValorDiaria_tab2.Size = new System.Drawing.Size(175, 23);
            this.txtValorDiaria_tab2.TabIndex = 86;
            this.txtValorDiaria_tab2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 84;
            this.label3.Text = "Valor Diária";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage3.Controls.Add(this.txtLimiteKm_tab3);
            this.tabPage3.Controls.Add(this.txtValorKm_tab3);
            this.tabPage3.Controls.Add(this.txtValorDiaria_tab3);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(294, 207);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "3";
            this.tabPage3.Text = "Controle";
            // 
            // txtLimiteKm_tab3
            // 
            this.txtLimiteKm_tab3.DecimalPlaces = 2;
            this.txtLimiteKm_tab3.Location = new System.Drawing.Point(23, 153);
            this.txtLimiteKm_tab3.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtLimiteKm_tab3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLimiteKm_tab3.Name = "txtLimiteKm_tab3";
            this.txtLimiteKm_tab3.Size = new System.Drawing.Size(175, 23);
            this.txtLimiteKm_tab3.TabIndex = 94;
            this.txtLimiteKm_tab3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtValorKm_tab3
            // 
            this.txtValorKm_tab3.DecimalPlaces = 2;
            this.txtValorKm_tab3.Location = new System.Drawing.Point(23, 92);
            this.txtValorKm_tab3.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtValorKm_tab3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtValorKm_tab3.Name = "txtValorKm_tab3";
            this.txtValorKm_tab3.Size = new System.Drawing.Size(175, 23);
            this.txtValorKm_tab3.TabIndex = 93;
            this.txtValorKm_tab3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtValorDiaria_tab3
            // 
            this.txtValorDiaria_tab3.DecimalPlaces = 2;
            this.txtValorDiaria_tab3.Location = new System.Drawing.Point(23, 34);
            this.txtValorDiaria_tab3.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtValorDiaria_tab3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtValorDiaria_tab3.Name = "txtValorDiaria_tab3";
            this.txtValorDiaria_tab3.Size = new System.Drawing.Size(175, 23);
            this.txtValorDiaria_tab3.TabIndex = 92;
            this.txtValorDiaria_tab3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 90;
            this.label6.Text = "Valor por Km";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 88;
            this.label4.Text = "Limite de Km";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 86;
            this.label5.Text = "Valor Diária";
            // 
            // buttonCancelarPf
            // 
            this.buttonCancelarPf.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarPf.Location = new System.Drawing.Point(232, 352);
            this.buttonCancelarPf.Name = "buttonCancelarPf";
            this.buttonCancelarPf.Size = new System.Drawing.Size(82, 38);
            this.buttonCancelarPf.TabIndex = 4;
            this.buttonCancelarPf.Text = "Cancelar";
            this.buttonCancelarPf.UseVisualStyleBackColor = true;
            // 
            // buttonGravarPlanoCobranca
            // 
            this.buttonGravarPlanoCobranca.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravarPlanoCobranca.Location = new System.Drawing.Point(139, 352);
            this.buttonGravarPlanoCobranca.Name = "buttonGravarPlanoCobranca";
            this.buttonGravarPlanoCobranca.Size = new System.Drawing.Size(82, 38);
            this.buttonGravarPlanoCobranca.TabIndex = 3;
            this.buttonGravarPlanoCobranca.Text = "Gravar";
            this.buttonGravarPlanoCobranca.UseVisualStyleBackColor = true;
            this.buttonGravarPlanoCobranca.Click += new System.EventHandler(this.buttonGravarPlanoCobranca_Click);
            // 
            // TelaCadastroPlanoCobrancaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 409);
            this.Controls.Add(this.buttonCancelarPf);
            this.Controls.Add(this.buttonGravarPlanoCobranca);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cmbGrupoVeiculos);
            this.Controls.Add(this.label9);
            this.Name = "TelaCadastroPlanoCobrancaForm";
            this.Text = "Cadastro de Planos de Cobranças";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorKm_tab1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDiaria_tab1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDiaria_tab2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimiteKm_tab3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorKm_tab3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDiaria_tab3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmbGrupoVeiculos;
        private Label label9;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Button buttonCancelarPf;
        private Button buttonGravarPlanoCobranca;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label6;
        private Label label4;
        private Label label5;
        private NumericUpDown txtValorKm_tab1;
        private NumericUpDown txtValorDiaria_tab1;
        private NumericUpDown txtValorDiaria_tab2;
        private NumericUpDown txtLimiteKm_tab3;
        private NumericUpDown txtValorKm_tab3;
        private NumericUpDown txtValorDiaria_tab3;
    }
}
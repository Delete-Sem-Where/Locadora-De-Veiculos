namespace LocadoraDeVeiculos.WinApp.ModuloTaxas
{
    partial class TelaCadastroTaxaForm
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
            this.labelDescricaoTaxa = new System.Windows.Forms.Label();
            this.labelValorTaxa = new System.Windows.Forms.Label();
            this.textBoxDescricaoTaxa = new System.Windows.Forms.TextBox();
            this.buttonGravarTaxa = new System.Windows.Forms.Button();
            this.buttonCancelarTaxa = new System.Windows.Forms.Button();
            this.labelNumeroTaxa = new System.Windows.Forms.Label();
            this.textBoxNumeroTaxa = new System.Windows.Forms.TextBox();
            this.txtUpDownValor = new System.Windows.Forms.NumericUpDown();
            this.radioButtonFixo = new System.Windows.Forms.RadioButton();
            this.radioButtonDiario = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpDownValor)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDescricaoTaxa
            // 
            this.labelDescricaoTaxa.AutoSize = true;
            this.labelDescricaoTaxa.Location = new System.Drawing.Point(48, 83);
            this.labelDescricaoTaxa.Name = "labelDescricaoTaxa";
            this.labelDescricaoTaxa.Size = new System.Drawing.Size(77, 20);
            this.labelDescricaoTaxa.TabIndex = 0;
            this.labelDescricaoTaxa.Text = "Descrição:";
            // 
            // labelValorTaxa
            // 
            this.labelValorTaxa.AutoSize = true;
            this.labelValorTaxa.Location = new System.Drawing.Point(77, 129);
            this.labelValorTaxa.Name = "labelValorTaxa";
            this.labelValorTaxa.Size = new System.Drawing.Size(46, 20);
            this.labelValorTaxa.TabIndex = 1;
            this.labelValorTaxa.Text = "Valor:";
            // 
            // textBoxDescricaoTaxa
            // 
            this.textBoxDescricaoTaxa.Location = new System.Drawing.Point(138, 79);
            this.textBoxDescricaoTaxa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxDescricaoTaxa.Name = "textBoxDescricaoTaxa";
            this.textBoxDescricaoTaxa.Size = new System.Drawing.Size(262, 27);
            this.textBoxDescricaoTaxa.TabIndex = 1;
            // 
            // buttonGravarTaxa
            // 
            this.buttonGravarTaxa.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravarTaxa.Location = new System.Drawing.Point(213, 245);
            this.buttonGravarTaxa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGravarTaxa.Name = "buttonGravarTaxa";
            this.buttonGravarTaxa.Size = new System.Drawing.Size(86, 31);
            this.buttonGravarTaxa.TabIndex = 5;
            this.buttonGravarTaxa.Text = "Gravar";
            this.buttonGravarTaxa.UseVisualStyleBackColor = true;
            this.buttonGravarTaxa.Click += new System.EventHandler(this.buttonGravarTaxa_Click);
            // 
            // buttonCancelarTaxa
            // 
            this.buttonCancelarTaxa.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarTaxa.Location = new System.Drawing.Point(314, 245);
            this.buttonCancelarTaxa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancelarTaxa.Name = "buttonCancelarTaxa";
            this.buttonCancelarTaxa.Size = new System.Drawing.Size(86, 31);
            this.buttonCancelarTaxa.TabIndex = 6;
            this.buttonCancelarTaxa.Text = "Cancelar";
            this.buttonCancelarTaxa.UseVisualStyleBackColor = true;
            // 
            // labelNumeroTaxa
            // 
            this.labelNumeroTaxa.AutoSize = true;
            this.labelNumeroTaxa.Location = new System.Drawing.Point(56, 32);
            this.labelNumeroTaxa.Name = "labelNumeroTaxa";
            this.labelNumeroTaxa.Size = new System.Drawing.Size(66, 20);
            this.labelNumeroTaxa.TabIndex = 6;
            this.labelNumeroTaxa.Text = "Número:";
            // 
            // textBoxNumeroTaxa
            // 
            this.textBoxNumeroTaxa.Enabled = false;
            this.textBoxNumeroTaxa.Location = new System.Drawing.Point(138, 28);
            this.textBoxNumeroTaxa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxNumeroTaxa.Name = "textBoxNumeroTaxa";
            this.textBoxNumeroTaxa.ReadOnly = true;
            this.textBoxNumeroTaxa.Size = new System.Drawing.Size(33, 27);
            this.textBoxNumeroTaxa.TabIndex = 7;
            // 
            // txtUpDownValor
            // 
            this.txtUpDownValor.DecimalPlaces = 2;
            this.txtUpDownValor.Location = new System.Drawing.Point(138, 123);
            this.txtUpDownValor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUpDownValor.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.txtUpDownValor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtUpDownValor.Name = "txtUpDownValor";
            this.txtUpDownValor.Size = new System.Drawing.Size(263, 27);
            this.txtUpDownValor.TabIndex = 2;
            this.txtUpDownValor.ThousandsSeparator = true;
            this.txtUpDownValor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radioButtonFixo
            // 
            this.radioButtonFixo.AutoSize = true;
            this.radioButtonFixo.Location = new System.Drawing.Point(213, 183);
            this.radioButtonFixo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonFixo.Name = "radioButtonFixo";
            this.radioButtonFixo.Size = new System.Drawing.Size(57, 24);
            this.radioButtonFixo.TabIndex = 4;
            this.radioButtonFixo.TabStop = true;
            this.radioButtonFixo.Text = "Fixo";
            this.radioButtonFixo.UseVisualStyleBackColor = true;
            // 
            // radioButtonDiario
            // 
            this.radioButtonDiario.AutoSize = true;
            this.radioButtonDiario.Location = new System.Drawing.Point(138, 183);
            this.radioButtonDiario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonDiario.Name = "radioButtonDiario";
            this.radioButtonDiario.Size = new System.Drawing.Size(71, 24);
            this.radioButtonDiario.TabIndex = 3;
            this.radioButtonDiario.TabStop = true;
            this.radioButtonDiario.Text = "Diário";
            this.radioButtonDiario.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tipo de Cálculo: ";
            // 
            // TelaCadastroTaxaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 295);
            this.Controls.Add(this.radioButtonFixo);
            this.Controls.Add(this.radioButtonDiario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUpDownValor);
            this.Controls.Add(this.textBoxNumeroTaxa);
            this.Controls.Add(this.labelNumeroTaxa);
            this.Controls.Add(this.buttonCancelarTaxa);
            this.Controls.Add(this.buttonGravarTaxa);
            this.Controls.Add(this.textBoxDescricaoTaxa);
            this.Controls.Add(this.labelValorTaxa);
            this.Controls.Add(this.labelDescricaoTaxa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroTaxaForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Taxas";
            ((System.ComponentModel.ISupportInitialize)(this.txtUpDownValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelDescricaoTaxa;
        private Label labelValorTaxa;
        private TextBox textBoxDescricaoTaxa;
        private Button buttonGravarTaxa;
        private Button buttonCancelarTaxa;
        private Label labelNumeroTaxa;
        private TextBox textBoxNumeroTaxa;
        private NumericUpDown txtUpDownValor;
        private RadioButton radioButtonFixo;
        private RadioButton radioButtonDiario;
        private Label label3;
    }
}
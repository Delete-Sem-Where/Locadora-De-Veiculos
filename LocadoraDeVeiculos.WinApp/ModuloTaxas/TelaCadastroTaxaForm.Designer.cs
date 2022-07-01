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
            this.labelDescricaoTaxa.Location = new System.Drawing.Point(42, 62);
            this.labelDescricaoTaxa.Name = "labelDescricaoTaxa";
            this.labelDescricaoTaxa.Size = new System.Drawing.Size(61, 15);
            this.labelDescricaoTaxa.TabIndex = 0;
            this.labelDescricaoTaxa.Text = "Descrição:";
            // 
            // labelValorTaxa
            // 
            this.labelValorTaxa.AutoSize = true;
            this.labelValorTaxa.Location = new System.Drawing.Point(67, 97);
            this.labelValorTaxa.Name = "labelValorTaxa";
            this.labelValorTaxa.Size = new System.Drawing.Size(36, 15);
            this.labelValorTaxa.TabIndex = 1;
            this.labelValorTaxa.Text = "Valor:";
            // 
            // textBoxDescricaoTaxa
            // 
            this.textBoxDescricaoTaxa.Location = new System.Drawing.Point(121, 59);
            this.textBoxDescricaoTaxa.Name = "textBoxDescricaoTaxa";
            this.textBoxDescricaoTaxa.Size = new System.Drawing.Size(230, 23);
            this.textBoxDescricaoTaxa.TabIndex = 2;
            // 
            // buttonGravarTaxa
            // 
            this.buttonGravarTaxa.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravarTaxa.Location = new System.Drawing.Point(186, 184);
            this.buttonGravarTaxa.Name = "buttonGravarTaxa";
            this.buttonGravarTaxa.Size = new System.Drawing.Size(75, 23);
            this.buttonGravarTaxa.TabIndex = 4;
            this.buttonGravarTaxa.Text = "Gravar";
            this.buttonGravarTaxa.UseVisualStyleBackColor = true;
            this.buttonGravarTaxa.Click += new System.EventHandler(this.buttonGravarTaxa_Click);
            // 
            // buttonCancelarTaxa
            // 
            this.buttonCancelarTaxa.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarTaxa.Location = new System.Drawing.Point(267, 184);
            this.buttonCancelarTaxa.Name = "buttonCancelarTaxa";
            this.buttonCancelarTaxa.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarTaxa.TabIndex = 5;
            this.buttonCancelarTaxa.Text = "Cancelar";
            this.buttonCancelarTaxa.UseVisualStyleBackColor = true;
            // 
            // labelNumeroTaxa
            // 
            this.labelNumeroTaxa.AutoSize = true;
            this.labelNumeroTaxa.Location = new System.Drawing.Point(49, 24);
            this.labelNumeroTaxa.Name = "labelNumeroTaxa";
            this.labelNumeroTaxa.Size = new System.Drawing.Size(54, 15);
            this.labelNumeroTaxa.TabIndex = 6;
            this.labelNumeroTaxa.Text = "Número:";
            // 
            // textBoxNumeroTaxa
            // 
            this.textBoxNumeroTaxa.Enabled = false;
            this.textBoxNumeroTaxa.Location = new System.Drawing.Point(121, 21);
            this.textBoxNumeroTaxa.Name = "textBoxNumeroTaxa";
            this.textBoxNumeroTaxa.Size = new System.Drawing.Size(29, 23);
            this.textBoxNumeroTaxa.TabIndex = 7;
            // 
            // txtUpDownValor
            // 
            this.txtUpDownValor.DecimalPlaces = 2;
            this.txtUpDownValor.Location = new System.Drawing.Point(121, 92);
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
            this.txtUpDownValor.Size = new System.Drawing.Size(230, 23);
            this.txtUpDownValor.TabIndex = 8;
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
            this.radioButtonFixo.Location = new System.Drawing.Point(186, 137);
            this.radioButtonFixo.Name = "radioButtonFixo";
            this.radioButtonFixo.Size = new System.Drawing.Size(47, 19);
            this.radioButtonFixo.TabIndex = 11;
            this.radioButtonFixo.TabStop = true;
            this.radioButtonFixo.Text = "Fixo";
            this.radioButtonFixo.UseVisualStyleBackColor = true;
            // 
            // radioButtonDiario
            // 
            this.radioButtonDiario.AutoSize = true;
            this.radioButtonDiario.Location = new System.Drawing.Point(121, 137);
            this.radioButtonDiario.Name = "radioButtonDiario";
            this.radioButtonDiario.Size = new System.Drawing.Size(56, 19);
            this.radioButtonDiario.TabIndex = 10;
            this.radioButtonDiario.TabStop = true;
            this.radioButtonDiario.Text = "Diário";
            this.radioButtonDiario.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tipo de Cálculo: ";
            // 
            // TelaCadastroTaxaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 221);
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
            this.Name = "TelaCadastroTaxaForm";
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
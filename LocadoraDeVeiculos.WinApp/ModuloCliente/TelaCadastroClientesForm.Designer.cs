namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    partial class TelaCadastroClientesForm
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
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonPessoaJuridica = new System.Windows.Forms.RadioButton();
            this.radioButtonPessoaFisica = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(98, 234);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(294, 27);
            this.txtCPF.TabIndex = 5;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(98, 344);
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelefone.Mask = "(99) 00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(294, 27);
            this.txtTelefone.TabIndex = 7;
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(98, 17);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(34, 27);
            this.txtNumero.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 67;
            this.label7.Text = "Numero:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(98, 399);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(294, 27);
            this.txtEndereco.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(98, 289);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(294, 27);
            this.txtEmail.TabIndex = 6;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(98, 124);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(294, 27);
            this.txtNome.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 61;
            this.label6.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 60;
            this.label5.Text = "Telefone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 59;
            this.label4.Text = "Endereço:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 58;
            this.label2.Text = "CPF:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "Nome:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(297, 455);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 60);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(185, 455);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(95, 60);
            this.btnGravar.TabIndex = 9;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(98, 179);
            this.txtCNPJ.Mask = "00.000.000/0000-00";
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(294, 27);
            this.txtCNPJ.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 182);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 74;
            this.label3.Text = "CNPJ:";
            // 
            // radioButtonPessoaJuridica
            // 
            this.radioButtonPessoaJuridica.AutoSize = true;
            this.radioButtonPessoaJuridica.Location = new System.Drawing.Point(265, 72);
            this.radioButtonPessoaJuridica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonPessoaJuridica.Name = "radioButtonPessoaJuridica";
            this.radioButtonPessoaJuridica.Size = new System.Drawing.Size(127, 24);
            this.radioButtonPessoaJuridica.TabIndex = 2;
            this.radioButtonPessoaJuridica.TabStop = true;
            this.radioButtonPessoaJuridica.Text = "Pessoa jurídica";
            this.radioButtonPessoaJuridica.UseVisualStyleBackColor = true;
            this.radioButtonPessoaJuridica.CheckedChanged += new System.EventHandler(this.radioButtonPessoaJuridica_CheckedChanged);
            // 
            // radioButtonPessoaFisica
            // 
            this.radioButtonPessoaFisica.AutoSize = true;
            this.radioButtonPessoaFisica.Location = new System.Drawing.Point(134, 72);
            this.radioButtonPessoaFisica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonPessoaFisica.Name = "radioButtonPessoaFisica";
            this.radioButtonPessoaFisica.Size = new System.Drawing.Size(112, 24);
            this.radioButtonPessoaFisica.TabIndex = 1;
            this.radioButtonPessoaFisica.TabStop = true;
            this.radioButtonPessoaFisica.Text = "Pessoa física";
            this.radioButtonPessoaFisica.UseVisualStyleBackColor = true;
            this.radioButtonPessoaFisica.CheckedChanged += new System.EventHandler(this.radioButtonPessoaFisica_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 20);
            this.label8.TabIndex = 76;
            this.label8.Text = "Tipo de cliente:";
            // 
            // TelaCadastroClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 539);
            this.Controls.Add(this.radioButtonPessoaJuridica);
            this.Controls.Add(this.radioButtonPessoaFisica);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCNPJ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroClientesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Clientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaskedTextBox txtCPF;
        private MaskedTextBox txtTelefone;
        private TextBox txtNumero;
        private Label label7;
        private TextBox txtEndereco;
        private TextBox txtEmail;
        private TextBox txtNome;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private Button btnCancelar;
        private Button btnGravar;
        private MaskedTextBox txtCNPJ;
        private Label label3;
        private RadioButton radioButtonPessoaJuridica;
        private RadioButton radioButtonPessoaFisica;
        private Label label8;
    }
}
namespace LocadoraDeVeiculos.WinApp.ModuloPessoaFisica
{
    partial class TelaCadastroPessoaFisicaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.buttonGravarPf = new System.Windows.Forms.Button();
            this.buttonCancelarPf = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtCNH = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "CPF:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "CNH:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Endereço:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Telefone:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Email:";
            // 
            // textBoxNomePF
            // 
            this.txtNome.Location = new System.Drawing.Point(104, 69);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNome.Name = "textBoxNomePF";
            this.txtNome.Size = new System.Drawing.Size(294, 27);
            this.txtNome.TabIndex = 6;
            // 
            // textBoxEmailPF
            // 
            this.txtEmail.Location = new System.Drawing.Point(104, 175);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "textBoxEmailPF";
            this.txtEmail.Size = new System.Drawing.Size(294, 27);
            this.txtEmail.TabIndex = 8;
            // 
            // textBoxEnderecoPF
            // 
            this.txtEndereco.Location = new System.Drawing.Point(104, 281);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEndereco.Name = "textBoxEnderecoPF";
            this.txtEndereco.Size = new System.Drawing.Size(294, 27);
            this.txtEndereco.TabIndex = 10;
            // 
            // buttonGravarPf
            // 
            this.buttonGravarPf.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravarPf.Location = new System.Drawing.Point(182, 387);
            this.buttonGravarPf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGravarPf.Name = "buttonGravarPf";
            this.buttonGravarPf.Size = new System.Drawing.Size(104, 71);
            this.buttonGravarPf.TabIndex = 12;
            this.buttonGravarPf.Text = "Gravar";
            this.buttonGravarPf.UseVisualStyleBackColor = true;
            this.buttonGravarPf.Click += new System.EventHandler(this.buttonGravarPf_Click);
            // 
            // buttonCancelarPf
            // 
            this.buttonCancelarPf.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarPf.Location = new System.Drawing.Point(294, 387);
            this.buttonCancelarPf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancelarPf.Name = "buttonCancelarPf";
            this.buttonCancelarPf.Size = new System.Drawing.Size(104, 71);
            this.buttonCancelarPf.TabIndex = 13;
            this.buttonCancelarPf.Text = "Cancelar";
            this.buttonCancelarPf.UseVisualStyleBackColor = true;
            // 
            // textBoxNumeroPF
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(104, 24);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumero.Name = "textBoxNumeroPF";
            this.txtNumero.Size = new System.Drawing.Size(34, 27);
            this.txtNumero.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Numero:";
            // 
            // textBoxTelefonePF
            // 
            this.txtTelefone.Location = new System.Drawing.Point(104, 228);
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelefone.Mask = "(99) 00000-0000";
            this.txtTelefone.Name = "textBoxTelefonePF";
            this.txtTelefone.Size = new System.Drawing.Size(294, 27);
            this.txtTelefone.TabIndex = 55;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(104, 122);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(294, 27);
            this.txtCPF.TabIndex = 56;
            // 
            // txtCNH
            // 
            this.txtCNH.Location = new System.Drawing.Point(104, 334);
            this.txtCNH.Mask = "00000000000";
            this.txtCNH.Name = "txtCNH";
            this.txtCNH.Size = new System.Drawing.Size(294, 27);
            this.txtCNH.TabIndex = 57;
            // 
            // TelaCadastroPessoaFisicaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 479);
            this.Controls.Add(this.txtCNH);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonCancelarPf);
            this.Controls.Add(this.buttonGravarPf);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TelaCadastroPessoaFisicaForm";
            this.Text = "Cadastro de Pessoas Fisicas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtEndereco;
        private Button buttonGravarPf;
        private Button buttonCancelarPf;
        private TextBox txtNumero;
        private Label label7;
        private MaskedTextBox txtTelefone;
        private MaskedTextBox txtCPF;
        private MaskedTextBox txtCNH;
    }
}
namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    partial class TelaCadastroCondutorForm
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
            this.txtCNH = new System.Windows.Forms.MaskedTextBox();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonCancelarPf = new System.Windows.Forms.Button();
            this.buttonGravarPf = new System.Windows.Forms.Button();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.datePickerValidadeCNH = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.checkClienteCondutor = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtCNH
            // 
            this.txtCNH.Location = new System.Drawing.Point(102, 231);
            this.txtCNH.Mask = "00000000000";
            this.txtCNH.Name = "txtCNH";
            this.txtCNH.Size = new System.Drawing.Size(294, 27);
            this.txtCNH.TabIndex = 73;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(102, 178);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(294, 27);
            this.txtCPF.TabIndex = 72;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(102, 390);
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelefone.Mask = "(99) 00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(294, 27);
            this.txtTelefone.TabIndex = 71;
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(102, 20);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(34, 27);
            this.txtNumero.TabIndex = 70;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 69;
            this.label7.Text = "Numero:";
            // 
            // buttonCancelarPf
            // 
            this.buttonCancelarPf.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarPf.Location = new System.Drawing.Point(302, 501);
            this.buttonCancelarPf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancelarPf.Name = "buttonCancelarPf";
            this.buttonCancelarPf.Size = new System.Drawing.Size(94, 51);
            this.buttonCancelarPf.TabIndex = 68;
            this.buttonCancelarPf.Text = "Cancelar";
            this.buttonCancelarPf.UseVisualStyleBackColor = true;
            // 
            // buttonGravarPf
            // 
            this.buttonGravarPf.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravarPf.Location = new System.Drawing.Point(190, 501);
            this.buttonGravarPf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGravarPf.Name = "buttonGravarPf";
            this.buttonGravarPf.Size = new System.Drawing.Size(94, 51);
            this.buttonGravarPf.TabIndex = 67;
            this.buttonGravarPf.Text = "Gravar";
            this.buttonGravarPf.UseVisualStyleBackColor = true;
            this.buttonGravarPf.Click += new System.EventHandler(this.buttonGravarPf_Click);
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(102, 443);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(294, 27);
            this.txtEndereco.TabIndex = 66;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(102, 337);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(294, 27);
            this.txtEmail.TabIndex = 65;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(102, 125);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(294, 27);
            this.txtNome.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 63;
            this.label6.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 393);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 62;
            this.label5.Text = "Telefone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 446);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 61;
            this.label4.Text = "Endereço:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 60;
            this.label3.Text = "CNH:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 59;
            this.label2.Text = "CPF:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Nome:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 20);
            this.label8.TabIndex = 74;
            this.label8.Text = "Validade CNH:";
            // 
            // datePickerValidadeCNH
            // 
            this.datePickerValidadeCNH.Location = new System.Drawing.Point(132, 284);
            this.datePickerValidadeCNH.Name = "datePickerValidadeCNH";
            this.datePickerValidadeCNH.Size = new System.Drawing.Size(264, 27);
            this.datePickerValidadeCNH.TabIndex = 75;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 76;
            this.label9.Text = "Cliente:";
            // 
            // cmbClientes
            // 
            this.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(102, 73);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(294, 28);
            this.cmbClientes.TabIndex = 77;
            this.cmbClientes.DropDownClosed += new System.EventHandler(this.cmbClientes_DropDownClosed);
            // 
            // checkClienteCondutor
            // 
            this.checkClienteCondutor.AutoSize = true;
            this.checkClienteCondutor.Location = new System.Drawing.Point(248, 22);
            this.checkClienteCondutor.Name = "checkClienteCondutor";
            this.checkClienteCondutor.Size = new System.Drawing.Size(148, 24);
            this.checkClienteCondutor.TabIndex = 78;
            this.checkClienteCondutor.Text = "Cliente condutor?";
            this.checkClienteCondutor.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroCondutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 574);
            this.Controls.Add(this.checkClienteCondutor);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.datePickerValidadeCNH);
            this.Controls.Add(this.label8);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroCondutorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Condutor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaskedTextBox txtCNH;
        private MaskedTextBox txtCPF;
        private MaskedTextBox txtTelefone;
        private TextBox txtNumero;
        private Label label7;
        private Button buttonCancelarPf;
        private Button buttonGravarPf;
        private TextBox txtEndereco;
        private TextBox txtEmail;
        private TextBox txtNome;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label8;
        private DateTimePicker datePickerValidadeCNH;
        private Label label9;
        private ComboBox cmbClientes;
        private CheckBox checkClienteCondutor;
    }
}
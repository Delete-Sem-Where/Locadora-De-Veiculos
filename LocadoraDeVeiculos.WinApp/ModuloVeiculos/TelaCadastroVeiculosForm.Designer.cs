namespace LocadoraDeVeiculos.WinApp.ModuloVeiculos
{
    partial class TelaCadastroVeiculosForm
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelGrupo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtCor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKmPercorrido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCapacidadeTanque = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTipoCombustivel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSelecionarFoto = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmbGrupoVeiculos = new System.Windows.Forms.ComboBox();
            this.picBoxImagem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(451, 466);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 60);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(338, 466);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(95, 60);
            this.btnGravar.TabIndex = 11;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click_1);
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(111, 21);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(61, 27);
            this.txtNumero.TabIndex = 77;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 76;
            this.label7.Text = "Numero:";
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(110, 118);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(172, 27);
            this.txtPlaca.TabIndex = 4;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(111, 68);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(172, 27);
            this.txtModelo.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 75;
            this.label6.Text = "Modelo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 74;
            this.label4.Text = "Placa";
            // 
            // labelGrupo
            // 
            this.labelGrupo.AutoSize = true;
            this.labelGrupo.Location = new System.Drawing.Point(179, 25);
            this.labelGrupo.Name = "labelGrupo";
            this.labelGrupo.Size = new System.Drawing.Size(136, 20);
            this.labelGrupo.TabIndex = 73;
            this.labelGrupo.Text = "Grupo de Veiculos: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 79;
            this.label1.Text = "Marca: ";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(374, 69);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(172, 27);
            this.txtMarca.TabIndex = 3;
            // 
            // txtCor
            // 
            this.txtCor.Location = new System.Drawing.Point(374, 118);
            this.txtCor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCor.Name = "txtCor";
            this.txtCor.Size = new System.Drawing.Size(172, 27);
            this.txtCor.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 81;
            this.label2.Text = "Cor";
            // 
            // txtKmPercorrido
            // 
            this.txtKmPercorrido.Location = new System.Drawing.Point(374, 236);
            this.txtKmPercorrido.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKmPercorrido.Name = "txtKmPercorrido";
            this.txtKmPercorrido.Size = new System.Drawing.Size(172, 27);
            this.txtKmPercorrido.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 40);
            this.label5.TabIndex = 87;
            this.label5.Text = "Km \r\nPercorrido:";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(110, 236);
            this.txtAno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(172, 27);
            this.txtAno.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 86;
            this.label8.Text = "Ano: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 20);
            this.label9.TabIndex = 85;
            this.label9.Text = "Imagem:";
            // 
            // txtCapacidadeTanque
            // 
            this.txtCapacidadeTanque.Location = new System.Drawing.Point(374, 176);
            this.txtCapacidadeTanque.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCapacidadeTanque.Name = "txtCapacidadeTanque";
            this.txtCapacidadeTanque.Size = new System.Drawing.Size(172, 27);
            this.txtCapacidadeTanque.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(290, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 40);
            this.label10.TabIndex = 93;
            this.label10.Text = "Capacidade\r\n Tanque:";
            // 
            // txtTipoCombustivel
            // 
            this.txtTipoCombustivel.Location = new System.Drawing.Point(111, 176);
            this.txtTipoCombustivel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTipoCombustivel.Name = "txtTipoCombustivel";
            this.txtTipoCombustivel.Size = new System.Drawing.Size(172, 27);
            this.txtTipoCombustivel.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 40);
            this.label11.TabIndex = 92;
            this.label11.Text = "Tipo de \r\nCombustível:";
            // 
            // btnSelecionarFoto
            // 
            this.btnSelecionarFoto.Location = new System.Drawing.Point(374, 284);
            this.btnSelecionarFoto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelecionarFoto.Name = "btnSelecionarFoto";
            this.btnSelecionarFoto.Size = new System.Drawing.Size(172, 31);
            this.btnSelecionarFoto.TabIndex = 10;
            this.btnSelecionarFoto.Text = "Selecionar Foto";
            this.btnSelecionarFoto.UseVisualStyleBackColor = true;
            this.btnSelecionarFoto.Click += new System.EventHandler(this.btnSelecionarFoto_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png";
            // 
            // cmbGrupoVeiculos
            // 
            this.cmbGrupoVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoVeiculos.FormattingEnabled = true;
            this.cmbGrupoVeiculos.Location = new System.Drawing.Point(310, 21);
            this.cmbGrupoVeiculos.Name = "cmbGrupoVeiculos";
            this.cmbGrupoVeiculos.Size = new System.Drawing.Size(236, 28);
            this.cmbGrupoVeiculos.TabIndex = 1;
            // 
            // picBoxImagem
            // 
            this.picBoxImagem.BackColor = System.Drawing.SystemColors.Window;
            this.picBoxImagem.Location = new System.Drawing.Point(111, 284);
            this.picBoxImagem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.picBoxImagem.Name = "picBoxImagem";
            this.picBoxImagem.Size = new System.Drawing.Size(225, 147);
            this.picBoxImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxImagem.TabIndex = 94;
            this.picBoxImagem.TabStop = false;
            // 
            // TelaCadastroVeiculosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 546);
            this.Controls.Add(this.picBoxImagem);
            this.Controls.Add(this.cmbGrupoVeiculos);
            this.Controls.Add(this.btnSelecionarFoto);
            this.Controls.Add(this.txtCapacidadeTanque);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTipoCombustivel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtKmPercorrido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelGrupo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroVeiculosForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Veiculos";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCancelar;
        private Button btnGravar;
        private TextBox txtNumero;
        private Label label7;
        private TextBox txtPlaca;
        private TextBox txtModelo;
        private Label label6;
        private Label label4;
        private Label labelGrupo;
        private Label label1;
        private TextBox txtMarca;
        private TextBox txtCor;
        private Label label2;
        private TextBox txtKmPercorrido;
        private Label label5;
        private TextBox txtAno;
        private Label label8;
        private Label label9;
        private TextBox txtCapacidadeTanque;
        private Label label10;
        private TextBox txtTipoCombustivel;
        private Label label11;
        private Button btnSelecionarFoto;
        private OpenFileDialog openFileDialog1;
        private ComboBox cmbGrupoVeiculos;
        private PictureBox picBoxImagem;
    }
}
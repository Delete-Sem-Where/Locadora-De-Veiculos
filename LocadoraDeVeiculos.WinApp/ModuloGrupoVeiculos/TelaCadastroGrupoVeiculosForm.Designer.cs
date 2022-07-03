namespace LocadoraDeVeiculos.WinApp.ModuloGruposVeiculos
{
    partial class TelaCadastroGrupoVeiculosForm
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
            this.buttonGravarGrupoVeiculos = new System.Windows.Forms.Button();
            this.buttonCancelarGrupoVeiculos = new System.Windows.Forms.Button();
            this.labelNomeGrupoVeiculos = new System.Windows.Forms.Label();
            this.textBoxNomeGrupoVeiculos = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonGravarGrupoVeiculos
            // 
            this.buttonGravarGrupoVeiculos.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravarGrupoVeiculos.Location = new System.Drawing.Point(100, 118);
            this.buttonGravarGrupoVeiculos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGravarGrupoVeiculos.Name = "buttonGravarGrupoVeiculos";
            this.buttonGravarGrupoVeiculos.Size = new System.Drawing.Size(86, 31);
            this.buttonGravarGrupoVeiculos.TabIndex = 2;
            this.buttonGravarGrupoVeiculos.Text = "Gravar";
            this.buttonGravarGrupoVeiculos.UseVisualStyleBackColor = true;
            this.buttonGravarGrupoVeiculos.Click += new System.EventHandler(this.buttonGravarGrupoVeiculos_Click_1);
            // 
            // buttonCancelarGrupoVeiculos
            // 
            this.buttonCancelarGrupoVeiculos.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarGrupoVeiculos.Location = new System.Drawing.Point(244, 118);
            this.buttonCancelarGrupoVeiculos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancelarGrupoVeiculos.Name = "buttonCancelarGrupoVeiculos";
            this.buttonCancelarGrupoVeiculos.Size = new System.Drawing.Size(86, 31);
            this.buttonCancelarGrupoVeiculos.TabIndex = 3;
            this.buttonCancelarGrupoVeiculos.Text = "Cancelar";
            this.buttonCancelarGrupoVeiculos.UseVisualStyleBackColor = true;
            // 
            // labelNomeGrupoVeiculos
            // 
            this.labelNomeGrupoVeiculos.AutoSize = true;
            this.labelNomeGrupoVeiculos.Location = new System.Drawing.Point(30, 56);
            this.labelNomeGrupoVeiculos.Name = "labelNomeGrupoVeiculos";
            this.labelNomeGrupoVeiculos.Size = new System.Drawing.Size(53, 20);
            this.labelNomeGrupoVeiculos.TabIndex = 2;
            this.labelNomeGrupoVeiculos.Text = "Nome:";
            // 
            // textBoxNomeGrupoVeiculos
            // 
            this.textBoxNomeGrupoVeiculos.Location = new System.Drawing.Point(100, 52);
            this.textBoxNomeGrupoVeiculos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxNomeGrupoVeiculos.Name = "textBoxNomeGrupoVeiculos";
            this.textBoxNomeGrupoVeiculos.Size = new System.Drawing.Size(230, 27);
            this.textBoxNomeGrupoVeiculos.TabIndex = 1;
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(100, 6);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(34, 27);
            this.txtNumero.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Numero:";
            // 
            // TelaCadastroGrupoVeiculosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 173);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxNomeGrupoVeiculos);
            this.Controls.Add(this.labelNomeGrupoVeiculos);
            this.Controls.Add(this.buttonCancelarGrupoVeiculos);
            this.Controls.Add(this.buttonGravarGrupoVeiculos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroGrupoVeiculosForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Grupo Veiculos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonGravarGrupoVeiculos;
        private Button buttonCancelarGrupoVeiculos;
        private Label labelNomeGrupoVeiculos;
        private TextBox textBoxNomeGrupoVeiculos;
        private TextBox txtNumero;
        private Label label7;
    }
}
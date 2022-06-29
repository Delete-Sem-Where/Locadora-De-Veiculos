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
            this.SuspendLayout();
            // 
            // buttonGravarGrupoVeiculos
            // 
            this.buttonGravarGrupoVeiculos.Location = new System.Drawing.Point(154, 166);
            this.buttonGravarGrupoVeiculos.Name = "buttonGravarGrupoVeiculos";
            this.buttonGravarGrupoVeiculos.Size = new System.Drawing.Size(75, 23);
            this.buttonGravarGrupoVeiculos.TabIndex = 0;
            this.buttonGravarGrupoVeiculos.Text = "Gravar";
            this.buttonGravarGrupoVeiculos.UseVisualStyleBackColor = true;
            // 
            // buttonCancelarGrupoVeiculos
            // 
            this.buttonCancelarGrupoVeiculos.Location = new System.Drawing.Point(281, 166);
            this.buttonCancelarGrupoVeiculos.Name = "buttonCancelarGrupoVeiculos";
            this.buttonCancelarGrupoVeiculos.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarGrupoVeiculos.TabIndex = 1;
            this.buttonCancelarGrupoVeiculos.Text = "Cancelar";
            this.buttonCancelarGrupoVeiculos.UseVisualStyleBackColor = true;
            // 
            // labelNomeGrupoVeiculos
            // 
            this.labelNomeGrupoVeiculos.AutoSize = true;
            this.labelNomeGrupoVeiculos.Location = new System.Drawing.Point(93, 104);
            this.labelNomeGrupoVeiculos.Name = "labelNomeGrupoVeiculos";
            this.labelNomeGrupoVeiculos.Size = new System.Drawing.Size(43, 15);
            this.labelNomeGrupoVeiculos.TabIndex = 2;
            this.labelNomeGrupoVeiculos.Text = "Nome:";
            // 
            // textBoxNomeGrupoVeiculos
            // 
            this.textBoxNomeGrupoVeiculos.Location = new System.Drawing.Point(154, 101);
            this.textBoxNomeGrupoVeiculos.Name = "textBoxNomeGrupoVeiculos";
            this.textBoxNomeGrupoVeiculos.Size = new System.Drawing.Size(202, 23);
            this.textBoxNomeGrupoVeiculos.TabIndex = 3;
            // 
            // TelaCadastroGrupoVeiculosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 321);
            this.Controls.Add(this.textBoxNomeGrupoVeiculos);
            this.Controls.Add(this.labelNomeGrupoVeiculos);
            this.Controls.Add(this.buttonCancelarGrupoVeiculos);
            this.Controls.Add(this.buttonGravarGrupoVeiculos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TelaCadastroGrupoVeiculosForm";
            this.ShowIcon = false;
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
    }
}
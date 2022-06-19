
namespace WinFormGym
{
    partial class FrmInfromeDeBajas
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
            this.lstClientesDadosDeBaja = new System.Windows.Forms.ListBox();
            this.btnRecuperarCliente = new System.Windows.Forms.Button();
            this.btnCerrarInformeBajas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstClientesDadosDeBaja
            // 
            this.lstClientesDadosDeBaja.FormattingEnabled = true;
            this.lstClientesDadosDeBaja.ItemHeight = 15;
            this.lstClientesDadosDeBaja.Location = new System.Drawing.Point(-2, 12);
            this.lstClientesDadosDeBaja.Name = "lstClientesDadosDeBaja";
            this.lstClientesDadosDeBaja.Size = new System.Drawing.Size(947, 394);
            this.lstClientesDadosDeBaja.TabIndex = 0;
            // 
            // btnRecuperarCliente
            // 
            this.btnRecuperarCliente.Location = new System.Drawing.Point(12, 412);
            this.btnRecuperarCliente.Name = "btnRecuperarCliente";
            this.btnRecuperarCliente.Size = new System.Drawing.Size(122, 34);
            this.btnRecuperarCliente.TabIndex = 1;
            this.btnRecuperarCliente.Text = "Recuperar cliente";
            this.btnRecuperarCliente.UseVisualStyleBackColor = true;
            this.btnRecuperarCliente.Click += new System.EventHandler(this.btnRecuperarCliente_Click);
            // 
            // btnCerrarInformeBajas
            // 
            this.btnCerrarInformeBajas.Location = new System.Drawing.Point(810, 412);
            this.btnCerrarInformeBajas.Name = "btnCerrarInformeBajas";
            this.btnCerrarInformeBajas.Size = new System.Drawing.Size(122, 34);
            this.btnCerrarInformeBajas.TabIndex = 2;
            this.btnCerrarInformeBajas.Text = "Cerrar";
            this.btnCerrarInformeBajas.UseVisualStyleBackColor = true;
            this.btnCerrarInformeBajas.Click += new System.EventHandler(this.btnCerrarInformeBajas_Click);
            // 
            // FrmInfromeDeBajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 458);
            this.Controls.Add(this.btnCerrarInformeBajas);
            this.Controls.Add(this.btnRecuperarCliente);
            this.Controls.Add(this.lstClientesDadosDeBaja);
            this.Name = "FrmInfromeDeBajas";
            this.Text = "Informe de bajas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmInfromeDeBajas_FormClosed);
            this.Load += new System.EventHandler(this.FrmInfromeDeBajas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstClientesDadosDeBaja;
        private System.Windows.Forms.Button btnRecuperarCliente;
        private System.Windows.Forms.Button btnCerrarInformeBajas;
    }
}
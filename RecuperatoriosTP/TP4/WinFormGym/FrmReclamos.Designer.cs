
namespace WinFormGym
{
    partial class FrmReclamos
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
            this.rtbMsjReclamo = new System.Windows.Forms.RichTextBox();
            this.btnEnviarRtaReclamo = new System.Windows.Forms.Button();
            this.btnCancelarReclamo = new System.Windows.Forms.Button();
            this.btnVerRtasEnviadas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbMsjReclamo
            // 
            this.rtbMsjReclamo.Location = new System.Drawing.Point(12, 12);
            this.rtbMsjReclamo.Name = "rtbMsjReclamo";
            this.rtbMsjReclamo.Size = new System.Drawing.Size(776, 302);
            this.rtbMsjReclamo.TabIndex = 0;
            this.rtbMsjReclamo.Text = "";
            // 
            // btnEnviarRtaReclamo
            // 
            this.btnEnviarRtaReclamo.Location = new System.Drawing.Point(683, 322);
            this.btnEnviarRtaReclamo.Name = "btnEnviarRtaReclamo";
            this.btnEnviarRtaReclamo.Size = new System.Drawing.Size(105, 23);
            this.btnEnviarRtaReclamo.TabIndex = 1;
            this.btnEnviarRtaReclamo.Text = "Enviar respuesta";
            this.btnEnviarRtaReclamo.UseVisualStyleBackColor = true;
            this.btnEnviarRtaReclamo.Click += new System.EventHandler(this.btnEnviarRtaReclamo_Click);
            // 
            // btnCancelarReclamo
            // 
            this.btnCancelarReclamo.Location = new System.Drawing.Point(12, 322);
            this.btnCancelarReclamo.Name = "btnCancelarReclamo";
            this.btnCancelarReclamo.Size = new System.Drawing.Size(105, 23);
            this.btnCancelarReclamo.TabIndex = 2;
            this.btnCancelarReclamo.Text = "Cancelar";
            this.btnCancelarReclamo.UseVisualStyleBackColor = true;
            this.btnCancelarReclamo.Click += new System.EventHandler(this.btnCancelarReclamo_Click);
            // 
            // btnVerRtasEnviadas
            // 
            this.btnVerRtasEnviadas.Location = new System.Drawing.Point(553, 322);
            this.btnVerRtasEnviadas.Name = "btnVerRtasEnviadas";
            this.btnVerRtasEnviadas.Size = new System.Drawing.Size(124, 23);
            this.btnVerRtasEnviadas.TabIndex = 3;
            this.btnVerRtasEnviadas.Text = "Respuestas enviadas";
            this.btnVerRtasEnviadas.UseVisualStyleBackColor = true;
            this.btnVerRtasEnviadas.Click += new System.EventHandler(this.btnVerRtasEnviadas_Click);
            // 
            // FrmReclamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 357);
            this.Controls.Add(this.btnVerRtasEnviadas);
            this.Controls.Add(this.btnCancelarReclamo);
            this.Controls.Add(this.btnEnviarRtaReclamo);
            this.Controls.Add(this.rtbMsjReclamo);
            this.Name = "FrmReclamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atención a reclamos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMsjReclamo;
        private System.Windows.Forms.Button btnEnviarRtaReclamo;
        private System.Windows.Forms.Button btnCancelarReclamo;
        private System.Windows.Forms.Button btnVerRtasEnviadas;
    }
}
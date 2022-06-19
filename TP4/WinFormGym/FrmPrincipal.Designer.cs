
namespace WinFormGym
{
    partial class FrmPrincipal
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
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.btnVenderProducto = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCobrarServicio = new System.Windows.Forms.Button();
            this.btnBajaCliente = new System.Windows.Forms.Button();
            this.btnAtenderReclamo = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.lblClientes = new System.Windows.Forms.Label();
            this.btnInformeBajas = new System.Windows.Forms.Button();
            this.lblRecuperandoInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstClientes
            // 
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.ItemHeight = 15;
            this.lstClientes.Location = new System.Drawing.Point(-2, 17);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(1067, 439);
            this.lstClientes.TabIndex = 0;
            // 
            // btnVenderProducto
            // 
            this.btnVenderProducto.Location = new System.Drawing.Point(141, 462);
            this.btnVenderProducto.Name = "btnVenderProducto";
            this.btnVenderProducto.Size = new System.Drawing.Size(123, 34);
            this.btnVenderProducto.TabIndex = 1;
            this.btnVenderProducto.Text = "Vender producto";
            this.btnVenderProducto.UseVisualStyleBackColor = true;
            this.btnVenderProducto.Click += new System.EventHandler(this.btnVenderProducto_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(930, 462);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(123, 34);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCobrarServicio
            // 
            this.btnCobrarServicio.Location = new System.Drawing.Point(270, 462);
            this.btnCobrarServicio.Name = "btnCobrarServicio";
            this.btnCobrarServicio.Size = new System.Drawing.Size(123, 34);
            this.btnCobrarServicio.TabIndex = 3;
            this.btnCobrarServicio.Text = "Cobrar Servicio";
            this.btnCobrarServicio.UseVisualStyleBackColor = true;
            this.btnCobrarServicio.Click += new System.EventHandler(this.btnCobrarServicio_Click);
            // 
            // btnBajaCliente
            // 
            this.btnBajaCliente.Location = new System.Drawing.Point(399, 462);
            this.btnBajaCliente.Name = "btnBajaCliente";
            this.btnBajaCliente.Size = new System.Drawing.Size(123, 34);
            this.btnBajaCliente.TabIndex = 4;
            this.btnBajaCliente.Text = "Dar de baja";
            this.btnBajaCliente.UseVisualStyleBackColor = true;
            this.btnBajaCliente.Click += new System.EventHandler(this.btnBajaCliente_Click);
            // 
            // btnAtenderReclamo
            // 
            this.btnAtenderReclamo.Location = new System.Drawing.Point(528, 462);
            this.btnAtenderReclamo.Name = "btnAtenderReclamo";
            this.btnAtenderReclamo.Size = new System.Drawing.Size(123, 34);
            this.btnAtenderReclamo.TabIndex = 5;
            this.btnAtenderReclamo.Text = "Atender reclamo";
            this.btnAtenderReclamo.UseVisualStyleBackColor = true;
            this.btnAtenderReclamo.Click += new System.EventHandler(this.btnAtenderReclamo_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(12, 462);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(123, 34);
            this.btnAlta.TabIndex = 6;
            this.btnAlta.Text = "Alta de cliente";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Location = new System.Drawing.Point(12, -1);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(52, 15);
            this.lblClientes.TabIndex = 7;
            this.lblClientes.Text = "Clientes:";
            // 
            // btnInformeBajas
            // 
            this.btnInformeBajas.Location = new System.Drawing.Point(657, 462);
            this.btnInformeBajas.Name = "btnInformeBajas";
            this.btnInformeBajas.Size = new System.Drawing.Size(123, 34);
            this.btnInformeBajas.TabIndex = 8;
            this.btnInformeBajas.Text = "Informe de bajas";
            this.btnInformeBajas.UseVisualStyleBackColor = true;
            this.btnInformeBajas.Click += new System.EventHandler(this.btnInformeBajas_Click);
            // 
            // lblRecuperandoInfo
            // 
            this.lblRecuperandoInfo.Location = new System.Drawing.Point(773, -1);
            this.lblRecuperandoInfo.Name = "lblRecuperandoInfo";
            this.lblRecuperandoInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRecuperandoInfo.Size = new System.Drawing.Size(277, 15);
            this.lblRecuperandoInfo.TabIndex = 9;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 501);
            this.Controls.Add(this.lblRecuperandoInfo);
            this.Controls.Add(this.btnInformeBajas);
            this.Controls.Add(this.lblClientes);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnAtenderReclamo);
            this.Controls.Add(this.btnBajaCliente);
            this.Controls.Add(this.btnCobrarServicio);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnVenderProducto);
            this.Controls.Add(this.lstClientes);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gimnasio Punto Fisico";
            this.Load += new System.EventHandler(this.FrmAtender_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.Button btnVenderProducto;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCobrarServicio;
        private System.Windows.Forms.Button btnBajaCliente;
        private System.Windows.Forms.Button btnAtenderReclamo;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Button btnInformeBajas;
        private System.Windows.Forms.Label lblRecuperandoInfo;
    }
}
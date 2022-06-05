
namespace WinFormGym
{
    partial class FrmAlta
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
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.grpAgregarAMano = new System.Windows.Forms.GroupBox();
            this.cmbServicio = new System.Windows.Forms.ComboBox();
            this.lblServicio = new System.Windows.Forms.Label();
            this.btnAgregarManoArch = new System.Windows.Forms.Button();
            this.btnAceptarAltaArch = new System.Windows.Forms.Button();
            this.btnAtrasAlta = new System.Windows.Forms.Button();
            this.grpAgregarAMano.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(130, 31);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(268, 23);
            this.txtNombreCliente.TabIndex = 0;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(130, 61);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(268, 23);
            this.txtDni.TabIndex = 1;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(130, 90);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(268, 23);
            this.txtEdad.TabIndex = 2;
            // 
            // cmbSexo
            // 
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Location = new System.Drawing.Point(130, 119);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(268, 23);
            this.cmbSexo.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 34);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 15);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "NOMBRE: ";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(6, 64);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(33, 15);
            this.lblDni.TabIndex = 5;
            this.lblDni.Text = "DNI: ";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(6, 93);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(43, 15);
            this.lblEdad.TabIndex = 6;
            this.lblEdad.Text = "EDAD: ";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(6, 122);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(41, 15);
            this.lblSexo.TabIndex = 7;
            this.lblSexo.Text = "SEXO: ";
            // 
            // grpAgregarAMano
            // 
            this.grpAgregarAMano.Controls.Add(this.cmbServicio);
            this.grpAgregarAMano.Controls.Add(this.lblServicio);
            this.grpAgregarAMano.Controls.Add(this.btnAgregarManoArch);
            this.grpAgregarAMano.Controls.Add(this.lblNombre);
            this.grpAgregarAMano.Controls.Add(this.lblSexo);
            this.grpAgregarAMano.Controls.Add(this.txtNombreCliente);
            this.grpAgregarAMano.Controls.Add(this.lblEdad);
            this.grpAgregarAMano.Controls.Add(this.txtDni);
            this.grpAgregarAMano.Controls.Add(this.lblDni);
            this.grpAgregarAMano.Controls.Add(this.txtEdad);
            this.grpAgregarAMano.Controls.Add(this.cmbSexo);
            this.grpAgregarAMano.Location = new System.Drawing.Point(12, 12);
            this.grpAgregarAMano.Name = "grpAgregarAMano";
            this.grpAgregarAMano.Size = new System.Drawing.Size(407, 207);
            this.grpAgregarAMano.TabIndex = 8;
            this.grpAgregarAMano.TabStop = false;
            this.grpAgregarAMano.Text = "Añadir cliente a mano";
            // 
            // cmbServicio
            // 
            this.cmbServicio.FormattingEnabled = true;
            this.cmbServicio.Location = new System.Drawing.Point(130, 148);
            this.cmbServicio.Name = "cmbServicio";
            this.cmbServicio.Size = new System.Drawing.Size(268, 23);
            this.cmbServicio.TabIndex = 14;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Location = new System.Drawing.Point(6, 151);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(62, 15);
            this.lblServicio.TabIndex = 13;
            this.lblServicio.Text = "SERVICIO: ";
            // 
            // btnAgregarManoArch
            // 
            this.btnAgregarManoArch.Location = new System.Drawing.Point(326, 177);
            this.btnAgregarManoArch.Name = "btnAgregarManoArch";
            this.btnAgregarManoArch.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarManoArch.TabIndex = 11;
            this.btnAgregarManoArch.Text = "Aceptar";
            this.btnAgregarManoArch.UseVisualStyleBackColor = true;
            this.btnAgregarManoArch.Click += new System.EventHandler(this.btnAgregarManoArch_Click);
            // 
            // btnAceptarAltaArch
            // 
            this.btnAceptarAltaArch.Location = new System.Drawing.Point(12, 225);
            this.btnAceptarAltaArch.Name = "btnAceptarAltaArch";
            this.btnAceptarAltaArch.Size = new System.Drawing.Size(174, 23);
            this.btnAceptarAltaArch.TabIndex = 11;
            this.btnAceptarAltaArch.Text = "Cargar clientes desde archivo";
            this.btnAceptarAltaArch.UseVisualStyleBackColor = true;
            this.btnAceptarAltaArch.Click += new System.EventHandler(this.btnAceptarAltaArch_Click);
            // 
            // btnAtrasAlta
            // 
            this.btnAtrasAlta.Location = new System.Drawing.Point(344, 225);
            this.btnAtrasAlta.Name = "btnAtrasAlta";
            this.btnAtrasAlta.Size = new System.Drawing.Size(75, 23);
            this.btnAtrasAlta.TabIndex = 12;
            this.btnAtrasAlta.Text = "Cancelar";
            this.btnAtrasAlta.UseVisualStyleBackColor = true;
            this.btnAtrasAlta.Click += new System.EventHandler(this.btnCancelarAlta_Click);
            // 
            // FrmAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 256);
            this.Controls.Add(this.btnAceptarAltaArch);
            this.Controls.Add(this.btnAtrasAlta);
            this.Controls.Add(this.grpAgregarAMano);
            this.Name = "FrmAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAlta";
            this.grpAgregarAMano.ResumeLayout(false);
            this.grpAgregarAMano.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.GroupBox grpAgregarAMano;
        private System.Windows.Forms.Button btnAceptarAltaArch;
        private System.Windows.Forms.Button btnAtrasAlta;
        private System.Windows.Forms.Button btnAgregarManoArch;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.ComboBox cmbServicio;
    }
}
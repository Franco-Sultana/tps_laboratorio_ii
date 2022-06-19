
namespace WinFormGym
{
    partial class FrmVentaProductos
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
            this.lstProductos = new System.Windows.Forms.ListBox();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnCancelarVenta = new System.Windows.Forms.Button();
            this.txtCantidadVender = new System.Windows.Forms.TextBox();
            this.lblCantidadVender = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstProductos
            // 
            this.lstProductos.FormattingEnabled = true;
            this.lstProductos.ItemHeight = 15;
            this.lstProductos.Location = new System.Drawing.Point(12, 12);
            this.lstProductos.Name = "lstProductos";
            this.lstProductos.Size = new System.Drawing.Size(518, 379);
            this.lstProductos.TabIndex = 0;
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(280, 397);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(121, 34);
            this.btnVender.TabIndex = 1;
            this.btnVender.Text = "Confirmar venta";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnCancelarVenta
            // 
            this.btnCancelarVenta.Location = new System.Drawing.Point(407, 397);
            this.btnCancelarVenta.Name = "btnCancelarVenta";
            this.btnCancelarVenta.Size = new System.Drawing.Size(123, 34);
            this.btnCancelarVenta.TabIndex = 3;
            this.btnCancelarVenta.Text = "Cancelar venta";
            this.btnCancelarVenta.UseVisualStyleBackColor = true;
            this.btnCancelarVenta.Click += new System.EventHandler(this.btnCancelarVenta_Click);
            // 
            // txtCantidadVender
            // 
            this.txtCantidadVender.Location = new System.Drawing.Point(86, 404);
            this.txtCantidadVender.Name = "txtCantidadVender";
            this.txtCantidadVender.Size = new System.Drawing.Size(100, 23);
            this.txtCantidadVender.TabIndex = 4;
            // 
            // lblCantidadVender
            // 
            this.lblCantidadVender.AutoSize = true;
            this.lblCantidadVender.Location = new System.Drawing.Point(12, 407);
            this.lblCantidadVender.Name = "lblCantidadVender";
            this.lblCantidadVender.Size = new System.Drawing.Size(68, 15);
            this.lblCantidadVender.TabIndex = 5;
            this.lblCantidadVender.Text = "CANTIDAD:";
            // 
            // FrmVentaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 438);
            this.Controls.Add(this.lblCantidadVender);
            this.Controls.Add(this.txtCantidadVender);
            this.Controls.Add(this.btnCancelarVenta);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.lstProductos);
            this.Name = "FrmVentaProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venta de productos";
            this.Load += new System.EventHandler(this.VentaProductos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstProductos;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Button btnCancelarVenta;
        private System.Windows.Forms.TextBox txtCantidadVender;
        private System.Windows.Forms.Label lblCantidadVender;
    }
}
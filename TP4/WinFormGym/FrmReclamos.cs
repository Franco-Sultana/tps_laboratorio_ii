using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Archivos;
using System.IO;
using System.Diagnostics;

namespace WinFormGym
{
    public partial class FrmReclamos : Form
    {
        Persona persona;
        public FrmReclamos(Persona p, bool estaEnOscuro)
        {
            InitializeComponent();
            this.persona = p;
            FrmPrincipal.MostrarEnModo(estaEnOscuro, this);
        }

        private void btnEnviarRtaReclamo_Click(object sender, EventArgs e)
        {
            if(this.rtbMsjReclamo.Text == String.Empty)
            {
                MessageBox.Show("Debe escribir algo para mandar el mensaje!", "Error: Información incompleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                StringBuilder sb = new();
                sb.Append($"Enviado a {this.persona.NombreCompleto}: ");
                sb.AppendLine(this.rtbMsjReclamo.Text);

                sb.AppendLine("=========================================");

                ArchivoTxt.Escribir("ReclamosAtendidos.txt", sb.ToString());
                MessageBox.Show("Se envió el mensaje", "Información", MessageBoxButtons.OK);

                this.DialogResult = DialogResult.OK;
            }
            
        }

        private void btnCancelarReclamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerRtasEnviadas_Click(object sender, EventArgs e)
        {
            Process p = new Process();

            p.StartInfo = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "ReclamosAtendidos.txt")
            {
                UseShellExecute = true
            };
                
            p.Start();
        }
    }
}

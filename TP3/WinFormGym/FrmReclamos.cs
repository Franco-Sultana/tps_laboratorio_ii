using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormGym
{
    public partial class FrmReclamos : Form
    {
        public FrmReclamos()
        {
            InitializeComponent();
        }

        private void btnEnviarRtaReclamo_Click(object sender, EventArgs e)
        {
            if(this.rtbMsjReclamo.Text == String.Empty)
            {
                MessageBox.Show("Debe escribir algo para mandar el mensaje!", "Error: Información incompleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Se envió el mensaje", "Información", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
            }
            
        }
    }
}

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

namespace WinFormGym
{
    public partial class FrmInfromeDeBajas : Form
    {
        Gym<Persona> listaPersonasBaja;
        Gym<Persona> listaPersonas;
        InformeClienteDadoDeBaja informe;
        public FrmInfromeDeBajas(Gym<Persona> listaPersonas, InformeClienteDadoDeBaja informe)
        {
            InitializeComponent();
            this.listaPersonasBaja = new();
            this.listaPersonas = listaPersonas;
            this.informe = informe;
        }
        private void FrmInfromeDeBajas_Load(object sender, EventArgs e)
        {
            PersonaDAO pDAO = new();
            List<Persona> listaAux = new();
            listaAux = pDAO.Leer(false);
            foreach (Persona item in listaAux)
            {
                listaPersonasBaja.Agregar(item);
                lstClientesDadosDeBaja.Items.Add(informe.MostrarBaja(item));
            }
        }

        private void btnRecuperarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                PersonaDAO pDAO = new();
                Persona aux = listaPersonasBaja.Lista.ElementAt(lstClientesDadosDeBaja.SelectedIndex);
                this.DesuscribirDelEvento(aux);

                pDAO.Modificar(true, aux);
                if (MessageBox.Show("Se recuperó al cliente", "Cliente recuperado", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    lstClientesDadosDeBaja.Items.Clear();
                    listaPersonasBaja.Remover(aux);
                    foreach (Persona item in listaPersonasBaja.Lista)
                    {
                        lstClientesDadosDeBaja.Items.Add(informe.MostrarBaja(item));
                    }
                }
            }
            catch(ArgumentOutOfRangeException )
            {
                MessageBox.Show("No de click sobre el espacio en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch(Exception)
            {
                MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void btnCerrarInformeBajas_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DesuscribirDelEvento(Persona p)
        {
            TimeSpan tiempoPasado = p.DiaCobrado - DateTime.Now;
            foreach (Persona item in listaPersonas.Lista)
            {
                if(item == p)
                {
                    informe.OnNotificarBaja -= item.RecibirNotificacionBaja;
                    if (tiempoPasado.Days > 30)
                    {
                        item.ActualizarPago();
                    }
                    else
                    {
                        MessageBox.Show($"El cliente pagó la mensualidad el dia {item.DiaCobrado.ToShortDateString()}, por lo tanto tiene el mes cubierto");
                    }
                }
            }
        }

        private void FrmInfromeDeBajas_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

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
using System.Threading;

namespace WinFormGym
{

    public partial class FrmPrincipal : Form
    {
        private bool estaEnModoOscuro;
        private Gym<Persona> listaPersonas;
        private InformeClienteDadoDeBaja informe;
        public FrmPrincipal()
        {
            InitializeComponent();

            this.listaPersonas = new();
            informe = new(DateTime.Now);
            estaEnModoOscuro = false;
            

        }

        private void FrmAtender_Load(object sender, EventArgs e)
        {
           
            try
            {
                PersonaDAO pDAO = new();

                List<Persona> listaAux = pDAO.Leer(true);
                foreach (Persona item in listaAux)
                {
                    
                    this.lstClientes.Items.Add(item);
                    this.listaPersonas.Agregar(item);
                }
            }
            catch(ArchivoExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Error en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Abre el formulario de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVenderProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Persona aux = (Persona)lstClientes.SelectedItem;
                if (aux is not null)
                {
                    FrmVentaProductos frmVenta = new(estaEnModoOscuro);
                    frmVenta.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Error: Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ocurrió un error ({ex.Message})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Cobra el servicio al cliente seleccionado. Si el cliente pagó la mensualidad no se le cobrará
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCobrarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                PersonaDAO pDAO = new();
                Persona aux = (Persona)lstClientes.SelectedItem;
                if (aux is not null)
                {
                    if (aux.CobrarServicio())
                    {
                        MessageBox.Show($"Se cobró {aux.Servicio} para el cliente", "Informacion", MessageBoxButtons.OK);
                        aux.ActualizarPago();
                        pDAO.Modificar(true, aux);
                        lstClientes.Items.Clear();
                        List<Persona> listaAux = pDAO.Leer(true);
                        if (listaAux != null)
                        {
                            foreach (Persona item in listaAux)
                            {
                                this.lstClientes.Items.Add(item);
                                listaPersonas.Agregar(item);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"El cliente ya pagó el servicio, no lo cagués!!", "Servicio cobrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Error: Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (ArchivoExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Error en archivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ocurrió un error ({ex.Message})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// Da de baja un cliente seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBajaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                PersonaDAO pDAO = new();
                Persona aux = (Persona)lstClientes.SelectedItem;
                if (aux is not null)
                {
                    SuscribirAlEvento(aux);

                    informe.EnviarNotificacionBaja();
                    MessageBox.Show("Se dio de baja el cliente con éxito", "Baja de cliente", MessageBoxButtons.OK);

                    lstClientes.Items.Clear();

                    List<Persona> listaAux = pDAO.Leer(true);
                    if (listaAux != null)
                    {
                        foreach (Persona item in listaAux)
                        {
                            this.lstClientes.Items.Add(item);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Error: Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch(SqlExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Error en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error ({ex.Message})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SuscribirAlEvento(Persona p)
        {
            foreach (Persona item in this.listaPersonas.Lista)
            {
                if(p == item)
                {
                informe.OnNotificarBaja += item.RecibirNotificacionBaja;
                }
            }
        }

        /// <summary>
        /// Abre el formulario de altas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlta_Click(object sender, EventArgs e)
        {
            Gym<Persona> aux = new();
            FrmAlta frmAlta = new(aux, estaEnModoOscuro);
            if(frmAlta.ShowDialog() == DialogResult.OK)
            {
                PersonaDAO pDAO = new();
                try
                {
                    
                    foreach (Persona item in aux.Lista)
                    {
                        pDAO.Guardar(item);
                        this.lstClientes.Items.Add(item);
                        this.listaPersonas.Agregar(item);
                    }
                    
                }
                catch (SqlExcepcion ex)
                {
                    MessageBox.Show(ex.Message, "Error en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInformeBajas_Click(object sender, EventArgs e)
        {
            FrmInfromeDeBajas frmInforme = new(listaPersonas, informe,this.estaEnModoOscuro);
            if (frmInforme.ShowDialog() == DialogResult.OK)
            {
                PersonaDAO pDAO = new();

                lstClientes.Items.Clear();
                List<Persona> listaAux = pDAO.Leer(true);
                if (listaAux != null)
                {
                    foreach (Persona item in listaAux)
                    {
                        this.lstClientes.Items.Add(item);
                        listaPersonas.Agregar(item);
                    }

                }

                //this.lblRecuperandoInfo.Text = "";
            }

        }
        private void btnAtenderReclamo_Click(object sender, EventArgs e)
        {
            try
            {
                Persona p = (Persona)lstClientes.SelectedItem;
                if(p is not null)
                {
                    FrmReclamos frmReclamos = new(p, this.estaEnModoOscuro);
                    frmReclamos.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Error: Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Error: Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error", "Error: Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnCambiarModo_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                CambiarModo();
            });
        }

        private void CambiarModo()
        {
            if (this.InvokeRequired)
            {
                Action a = new(CambiarModo);
                Thread.Sleep(new Random().Next(1000, 2500));
                BeginInvoke(a);
            }
            else
            {

                MostrarEnModo(!estaEnModoOscuro, this);
                if (this.estaEnModoOscuro)
                {
                    estaEnModoOscuro = false;
                    this.btnCambiarModo.Text = "Modo oscuro";
                }
                else
                {
                    estaEnModoOscuro = true;
                    this.btnCambiarModo.Text = "Modo claro";

                }
            }
        }
        public static void MostrarEnModo(bool estaOscuro, Form frm)
        {
            if (!estaOscuro)
            {
                foreach (Control item in frm.Controls)
                {
                    item.BackColor = default;
                    item.ForeColor = default;
                }
                frm.BackColor = default;
            }
            else
            {
                foreach (Control item in frm.Controls)
                {
                    item.BackColor = Color.FromArgb(66, 66, 66);
                    item.ForeColor = Color.White;
                }
                frm.BackColor = Color.FromArgb(33, 33, 33);
            }
        }
    }
}

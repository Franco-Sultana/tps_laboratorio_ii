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

public delegate void DelegadoIniciarFormulario();
namespace WinFormGym
{
   
    public partial class FrmPrincipal : Form
    {
        private Gym<Persona> listaPersonas;
        private InformeClienteDadoDeBaja informe;
        public FrmPrincipal()
        {
            InitializeComponent();

            this.listaPersonas = new();
            informe = new(DateTime.Now);
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
                MessageBox.Show(ex.Message, "Error en archivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                Persona aux = listaPersonas.Lista.ElementAt(lstClientes.SelectedIndex);
                FrmVentaProductos frmVenta = new();
                frmVenta.ShowDialog();
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show($"Seleccione el cliente al que le quiere vender un producto", "Error: Cliente no seleccionado", MessageBoxButtons.OK, 
                                                                                                                                MessageBoxIcon.Exclamation);
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
                Persona aux = listaPersonas.Lista.ElementAt(lstClientes.SelectedIndex);
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
            catch (ArchivoExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Error en archivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Error: Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                informe.OnNotificarBaja += aux.RecibirNotificacionBaja;

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
            catch(SqlExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Error en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Error: Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error ({ex.Message})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Abre el formulario de altas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlta_Click(object sender, EventArgs e)
        {
            FrmAlta frmAlta = new(listaPersonas);
            if(frmAlta.ShowDialog() == DialogResult.OK)
            {
                PersonaDAO pDAO = new();
                try
                {
                    lstClientes.Items.Clear();
                    List<Persona> listaAux = pDAO.Leer(true);
                    if (listaAux != null)
                    {
                        foreach (Persona item in listaAux)
                        {
                            
                            listaPersonas.Agregar(item);
                        }
                        foreach (Persona item in this.listaPersonas.Lista)
                        {
                            pDAO.Guardar(item);
                            this.lstClientes.Items.Add(item);
                        }
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

        private async void btnInformeBajas_Click(object sender, EventArgs e)
        {
            this.lblRecuperandoInfo.Text = "...Recuperando información";
            await Task.Run(() => AbrirFormBajas());
        }

        private void AbrirFormBajas()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Task.Delay((new Random()).Next(3000, 6000)).Wait();
                    DelegadoIniciarFormulario delegado = new(AbrirFormBajas);
                            
                    BeginInvoke(delegado);
                }
                else
                {
                    FrmInfromeDeBajas frmInforme = new(listaPersonas, informe);
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
                        this.lblRecuperandoInfo.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAtenderReclamo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmReclamos frmReclamos = new((Persona)lstClientes.SelectedItem);
                frmReclamos.ShowDialog();
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
    }
}

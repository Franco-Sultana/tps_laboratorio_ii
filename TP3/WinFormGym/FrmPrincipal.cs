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
    public partial class FrmPrincipal : Form
    {
        private Gym<Persona> listaPersonas;
        public FrmPrincipal()
        {
            InitializeComponent();
           
            this.listaPersonas = new();
        }

        private void FrmAtender_Load(object sender, EventArgs e)
        {
            try
            {
                List<Persona> listaAux = ClasesSerializadoraXml<List<Persona>>.Leer("Xml_ClientesGym");
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
                MessageBox.Show($"Seleccione el cliente al que le quiere vender un producto", "Error: Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                Persona aux = listaPersonas.Lista.ElementAt(lstClientes.SelectedIndex);
                if (aux.CobrarServicio())
                {
                    MessageBox.Show($"Se cobró {aux.Servicio} para el cliente", "Informacion", MessageBoxButtons.OK);
                    aux.ActualizarPago();
                    ClasesSerializadoraXml<List<Persona>>.Escribir(listaPersonas.Lista, "Xml_ClientesGym");
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
                Persona aux = listaPersonas.Lista.ElementAt(lstClientes.SelectedIndex);
                listaPersonas.Remover(aux);
                MessageBox.Show("Se dio de baja el cliente con éxito", "Baja de cliente", MessageBoxButtons.OK);

                ClasesSerializadoraXml<List<Persona>>.Escribir(listaPersonas.Lista, "Xml_ClientesGym");

                lstClientes.Items.Clear();
                List<Persona> listaAux = ClasesSerializadoraXml<List<Persona>>.Leer("Xml_ClientesGym");
                if (listaAux != null)
                {
                    foreach (Persona item in listaAux)
                    {

                        this.lstClientes.Items.Add(item);
                        listaPersonas.Agregar(item);
                           
                    }
                   
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
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error ({ex.Message})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmReclamos frmReclamos = new();
            frmReclamos.ShowDialog();

        }

        private void AgregarAListaDesdeArchivo()
        {
          
            
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
                
                try
                {
                    lstClientes.Items.Clear();
                    List<Persona> listaAux = ClasesSerializadoraXml<List<Persona>>.Leer("Xml_ClientesGym");
                    if (listaAux != null)
                    {
                        foreach (Persona item in listaAux)
                        {

                                this.lstClientes.Items.Add(item);
                                listaPersonas.Agregar(item);
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error en archivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

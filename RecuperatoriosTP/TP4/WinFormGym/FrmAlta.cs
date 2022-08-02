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
    public partial class FrmAlta : Form
    {
        Gym<Persona> listaPersonas;
        PersonaDAO pDAO;
        public FrmAlta(Gym<Persona> listaPersonas)
        {
            InitializeComponent();
            this.listaPersonas = listaPersonas;
            this.pDAO = new();

            //cmbSexo.DataSource = Enum.GetValues(typeof(eSexo));
            cmbSexo.Items.Add("Femenino");
            cmbSexo.Items.Add("Masculino");
            cmbSexo.Items.Add("Sin especificar");
            //cmbSexo.SelectedIndex = 2;

            //cmbServicio.DataSource = Enum.GetValues(typeof(eServicio));
            cmbServicio.Items.Add("Clases de crossfit");
            cmbServicio.Items.Add("Clases de zumba");
            cmbServicio.Items.Add("Pase libre");
        }

        /// <summary>
        /// Escribe en el archivo y el el this.lstClientes los clientes que se encuentran cargados en otro archivo. Si se carga correctamente, se hace dialogResult.OK del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptarAltaArch_Click(object sender, EventArgs e)
        {
            try
            {
                List<Persona> auxPersonas = new();
                auxPersonas = ClasesSerializadoraXml<List<Persona>>.Leer("Xml_ClientesYaCargadosGym");
                foreach (Persona item in auxPersonas)
                {
                    this.listaPersonas.Agregar(item);
                }
                MessageBox.Show("Se cargaron los clientes del archivo", "Información", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        /// <summary>
        /// Escribe en el archivo y en el this.lstClientes el cliente cargado a mano por el usuario. Si se carga correctamente, se hace dialogResult.OK del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarManoArch_Click(object sender, EventArgs e)
        {
            bool puedo = true;
            try
            {
                foreach (Control item in this.grpAgregarAMano.Controls)

                    if (item is TextBox && item.Text == String.Empty || item is ComboBox && item.Text == String.Empty)
                    {
                        puedo = false;
                        MessageBox.Show("Completá todos los campos!", "Error: campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }

                if (puedo == true)
                {
                    Persona p = new(this.txtNombreCliente.Text, int.Parse(this.txtDni.Text), int.Parse(this.txtEdad.Text),
                                                            (eSexo)this.cmbSexo.SelectedIndex, DateTime.Now, (eServicio)cmbServicio.SelectedIndex);
                    if (listaPersonas != p)
                    {
                        listaPersonas.Agregar(p);
                        MessageBox.Show("Se dio de alta correctamente", "Información", MessageBoxButtons.OK); 
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("La persona ya se encuentra registrada", "Persona con DNI repetido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    

                    foreach (Control item in this.grpAgregarAMano.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.Text = String.Empty;
                        }
                    }
                    cmbSexo.SelectedIndex = 2;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Los campos 'dni' y 'edad' deben ser numéricos", "Valores incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex )
            {
                MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Cancela el alta y cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarAlta_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }



}

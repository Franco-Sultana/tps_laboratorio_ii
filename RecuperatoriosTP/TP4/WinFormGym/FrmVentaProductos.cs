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
    public partial class FrmVentaProductos : Form
    {
        private bool estaEnOscuro;

        Gym<IVenta> listaProductos;
        public FrmVentaProductos(bool estaEnOscuro)
        {
            InitializeComponent();
            this.listaProductos = new();
            this.estaEnOscuro = estaEnOscuro;
        }

        private void VentaProductos_Load(object sender, EventArgs e)
        {
            try
            {
                FrmPrincipal.MostrarEnModo(estaEnOscuro, this);
                List<AccesoriosDeportivos> listaAuxAccesorios = ClaseSerializadoraJson<List<AccesoriosDeportivos>>.Leer("SerializandoJson_AccesoriosDeportivos.json");
                List<IndumentariaDeportiva> listaAuxIndumentaria = ClaseSerializadoraJson<List<IndumentariaDeportiva>>.Leer("SerializandoJson_IndumentariaDeportiva.json");


                foreach (IndumentariaDeportiva item in listaAuxIndumentaria)
                {
                    listaProductos.Agregar(item);
                    lstProductos.Items.Add(item);
                }
                foreach (AccesoriosDeportivos item in listaAuxAccesorios)
                {
                    listaProductos.Agregar(item);
                    lstProductos.Items.Add(item);
                }
            }
            catch(ArchivoExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception )
            {
                MessageBox.Show($"Ocurrio un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {

                Producto productoAux = (Producto)listaProductos.Lista.ElementAt(lstProductos.SelectedIndex);

                if (this.txtCantidadVender.Text == String.Empty)
                {
                    this.txtCantidadVender.Text = "1";
                }
                ((IVenta)productoAux).Cantidad = int.Parse(this.txtCantidadVender.Text);
                MessageBox.Show($"Producto vendido, plata obtenida: ${((IVenta)productoAux).Vender()}", "Informacion", MessageBoxButtons.OK);
                List<AccesoriosDeportivos> auxA = new();
                List<IndumentariaDeportiva> auxI = new();
                lstProductos.Items.Clear();
                foreach (Producto item in listaProductos.Lista)
                {
                    if (item is AccesoriosDeportivos)
                    {
                        lstProductos.Items.Add(item);
                        auxA.Add((AccesoriosDeportivos)item);
                    }
                    if (item is IndumentariaDeportiva)
                    {
                        lstProductos.Items.Add(item);
                        auxI.Add((IndumentariaDeportiva)item);
                    }
                }
                ArchivoTxt.Escribir("DetallesVentas", ((IVenta)productoAux).DetallarVenta());
                ClaseSerializadoraJson<List<AccesoriosDeportivos>>.Escribir(auxA, "SerializandoJson_AccesoriosDeportivos.json");
                ClaseSerializadoraJson<List<IndumentariaDeportiva>>.Escribir(auxI, "SerializandoJson_IndumentariaDeportiva.json");

            }
            catch (ArchivoExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Error en archivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Seleccione un producto para poder vender!!", "Item no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (FormatException)
            {
                MessageBox.Show("La cantidad de productos debe ser numérica!!!", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (SinStockExcepcion ex)
            {
                MessageBox.Show(ex.Message, "Producto sin stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error ({ex.Message})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

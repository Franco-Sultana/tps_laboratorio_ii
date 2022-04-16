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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor del form
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Recibe los operandos y operador ingresados en el form por el usuario y llama a las funciones necesariass para operar
        /// </summary>
        /// <param name="numero1">Primer operando</param>
        /// <param name="numero2">Segundo operando</param>
        /// <param name="operador">Operador</param>
        /// <returns>Resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);
            if (string.IsNullOrWhiteSpace(operador))
            {
                operador = " ";
            }
            return Calculadora.Operar(operando1, operando2, Convert.ToChar(operador));
        }

        /// <summary>
        /// Limpia el combobox para elegir el operador, los textbox para ingresar los operandos y el label de resultado
        /// </summary>
        private void Limpiar()
        {
            this.cmbOperador.Text = null;
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
        }

        /// <summary>
        /// Evento load del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add(" ");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
            Limpiar();
        }

        /// <summary>
        /// lleva a cabo la funcion que se le asigna al boton operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador = "+";
            string numero1 = "0";
            string numero2 = "0";
            double resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
            if (!string.IsNullOrWhiteSpace(this.txtNumero1.Text))
            {
                numero1 = this.txtNumero1.Text;
            }
            if (!string.IsNullOrWhiteSpace(this.txtNumero2.Text))
            {
                numero2 = this.txtNumero2.Text;
            }
            if (!string.IsNullOrWhiteSpace(this.cmbOperador.Text))
            {
                operador = this.cmbOperador.Text;
            }
            string txtHistorial = numero1 + " " + operador + " " + numero2 + " = " + Math.Round(resultado, 3);
            lstOperaciones.Items.Add(txtHistorial);
            lblResultado.Text = "" + resultado;
        }
        /// <summary>
        /// Funcion del boton que limpia la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Funcion del boton que cierra la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Funcion del boton que convierte de decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.lblResultado.Text))
            {
                Operando numero = new Operando();
                lblResultado.Text = numero.DecimalBinario(this.lblResultado.Text);
            }
            else
            {
                MessageBox.Show("No hay resultado para convertir a binario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Funcion del boton que convierte de binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblResultado.Text))
            {
                Operando numero = new Operando();
                lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
            }
            else
            {
                MessageBox.Show("No hay resultado para convertir a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Evento closing deñ form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

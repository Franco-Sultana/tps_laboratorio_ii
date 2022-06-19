using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum eSexo
    {
        Femenino, Masculino, SinEspecificar
    }

    public class Persona
    {
        private string nombreCompleto;
        private int dni;
        private int edad;
        private eSexo sexo;
        private DateTime diaCobrado;
        private eServicio servicio;

        public event NotificarBajaCliente OnNotificarBaja;

        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
        public int Dni { get => dni; set => dni = value; }
        public int Edad { get => edad; set => edad = value; }
        public eSexo Sexo { get => sexo; set => sexo = value; }
        public DateTime DiaCobrado { get => diaCobrado; set => diaCobrado = value; }
        public eServicio Servicio { get => servicio; set => servicio = value; }

        public Persona() { }

        public Persona(string nombreCompleto, int dni, eSexo sexo, int edad, eServicio servicio)
        {
            this.servicio = servicio;
            this.edad = edad;
            this.nombreCompleto = nombreCompleto;
            this.dni = dni;
            this.sexo = sexo;
        }

        public Persona(string nombreCompleto, int dni, int edad, eSexo sexo, DateTime diaCobrado, eServicio servicio) : this(nombreCompleto, dni, sexo, edad, servicio)
        {
            this.diaCobrado = diaCobrado;
        }


        public void ActualizarPago()
        {
            this.diaCobrado = DateTime.Now;
        }

        /// <summary>
        /// Cobra el servicio si pasaron 30 dias
        /// </summary>
        /// <returns>True si pasaron 30 dias y pudo cobrar, false si no</returns>
        public bool CobrarServicio()
        {
            TimeSpan tiempoPasado = DateTime.Now - this.diaCobrado;
            if (tiempoPasado.Days >= 30)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Persona p1, Persona p2)
        {
            return !(p1 == p2);
        }
        public static bool operator ==(Persona p1, Persona p2)
        {
            return p1 is not null && p2 is not null && p1.Dni == p2.Dni;
        }
        public override bool Equals(object obj)
        {
            return obj is Persona && this == (Persona)obj;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"NOMBRE: {this.nombreCompleto} - ");
            sb.AppendLine($"DNI: {this.dni} - ");
            sb.AppendLine($"EDAD: {this.edad} - ");
            if(this.sexo == eSexo.SinEspecificar)
            {
                sb.AppendLine($"SEXO: Sin especificar - ");
            }
            else
            {
                sb.AppendLine($"SEXO: {this.sexo} - ");
            }

            switch (this.servicio)
            {
                case eServicio.ClaseCrossfit:
                    sb.AppendLine($"SERVICIO: Clases de crossfit - ");
                    break;
                case eServicio.Zumba:
                    sb.AppendLine($"SERVICIO: Clases de zumba - ");
                    break;
                case eServicio.PaseLibre:
                    sb.AppendLine($"SERVICIO: Pase libre - ");
                    break;
                default:
                    break;
            }

            
            sb.AppendLine($"DIA COBRADO: {this.diaCobrado.ToShortDateString()}");
            return sb.ToString();
        }
    }
}
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


        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
        public int Dni { get => dni; set => dni = value; }
        public int Edad { get => edad; set => edad = value; }
        public eSexo Sexo { get => sexo; set => sexo = value; }
        public DateTime DiaCobrado { get => diaCobrado; set => diaCobrado = value; }
        public eServicio Servicio { get => servicio; set => servicio = value; }

        public Persona() { }

        public Persona(string nombreCompleto, int dni, int edad, eSexo sexo, DateTime diaCobrado, eServicio servicio)
        {
            this.nombreCompleto = nombreCompleto;
            this.dni = dni;
            this.edad = edad;
            this.sexo = sexo;
            this.diaCobrado = diaCobrado;
            this.servicio = servicio;
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
            if(tiempoPasado.Days >= 30)
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
            sb.AppendLine($"SEXO: {this.sexo} - ");
            sb.AppendLine($"SERVICIO: {this.servicio} - ");
            sb.AppendLine($"DIA COBRADO: {this.diaCobrado}");
            return sb.ToString();
        }

    }
}

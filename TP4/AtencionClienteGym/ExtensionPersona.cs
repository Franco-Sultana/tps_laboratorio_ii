using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensionPersona
    {
        public static void RecibirNotificacionBaja(this Persona p, InformeClienteDadoDeBaja sender)
        {
            PersonaDAO pbDAO = new();
            pbDAO.Modificar(false, p);
        }

        public static string MostrarBaja(this InformeClienteDadoDeBaja info, Persona p)
        {
            StringBuilder sb = new();
            sb.AppendLine($"NOMBRE: {p.NombreCompleto} - ");
            sb.AppendLine($"DNI: {p.Dni} - ");
            sb.AppendLine($"EDAD: {p.Edad} - ");
            sb.AppendLine($"SEXO: {p.Sexo} - ");
            sb.AppendLine($"SERVICIO: {p.Servicio} - ");
            sb.AppendLine($"DIA DADO DE BAJA: {info.DiaBaja}");
            return sb.ToString();
        }
    }
}

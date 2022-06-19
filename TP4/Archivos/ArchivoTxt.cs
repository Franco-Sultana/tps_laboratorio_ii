using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public static class ArchivoTxt
    {
        static string path;
        static ArchivoTxt()
        {
            path = AppDomain.CurrentDomain.BaseDirectory;
        }
        public static void Escribir(string nombre, string datos)
        {
            string nombreArchivo = path + nombre;
            StreamWriter sw = null;
            try 
            {
                sw = new(nombreArchivo, true);
                if (sw != null)
                {
                    sw.WriteLine(datos);

                }
            }
            catch(Exception ex)
            {
                throw new ArchivoExcepcion($"Error en el archivo ubicado en {path}", ex); 
            }
            finally
            {
                if(sw != null)
                {
                    sw.Close();
                }
            }
            
        }
    }
}

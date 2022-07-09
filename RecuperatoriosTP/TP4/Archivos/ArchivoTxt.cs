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

        public static List<string>Leer(string nombre)
        {
            List<string> lista = new();

            string nombreArchivo = path + nombre;
            StreamReader sr = null;
            try
            {
                sr = new(nombreArchivo, true);
                string linea = sr.ReadLine();
                if (sr != null)
                {
                    while(linea != null)
                    {
                        lista.Add(linea);
                        linea = sr.ReadLine();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new ArchivoExcepcion($"Error en el archivo ubicado en {path}", ex);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }

            return lista;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Archivos
{
    public static class ClasesSerializadoraXml<T>
    {
        static string path;

        static ClasesSerializadoraXml()
        {
            //path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SerXml\\";
            path = AppDomain.CurrentDomain.BaseDirectory;
        }

        public static void Escribir(T datos, string nombre)
        {
            StreamWriter sw = null;
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                  
                }
            sw = new(path + nombre);
            if (sw != null)
                {
                    
                    XmlSerializer xml = new(typeof(T));

                    xml.Serialize(sw, datos);
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
        public static T Leer(string nombre)
        {
            StreamReader sr = null;
            string archivo = String.Empty;
            T datosRecuperados = default;

            try
            {
                if (Directory.Exists(path))
                {

                    string[] archivosEnPath = Directory.GetFiles(path);
                    foreach (string path in archivosEnPath)
                    {
                        if (path.Contains(nombre))
                        {
                            archivo = path;
                            break;
                        }
                    }
                    sr = new(archivo);
                }
                if (archivo != null && sr != null)
                {
                    XmlSerializer xmlSerializador = new(typeof(T));
                    datosRecuperados = (T)xmlSerializador.Deserialize(sr);
                }
                return datosRecuperados;
            }
            catch(Exception ex)
            {
                throw new ArchivoExcepcion($"Error en el archivo ubicado en {path}", ex);
            }
            finally
            {
                if(sr != null)
                {
                    sr.Close();
                }
                
            }
           
                
        }

    }
}

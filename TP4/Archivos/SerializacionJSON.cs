using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entidades;

namespace Archivos
{
    public static class ClaseSerializadoraJson<T>
    {

        static string path;

        static ClaseSerializadoraJson()
        {
            path = AppDomain.CurrentDomain.BaseDirectory;
        }

        public static void Escribir(T datos, string nombre)
        {
            string nombreArchivo = path + "SerializandoJson_" + nombre + ".json";
            Directory.CreateDirectory(path);
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(nombreArchivo);
                sw.WriteLine(JsonSerializer.Serialize(datos));
            sw.Close();

            }
            catch(Exception ex)
            {
                throw new ArchivoExcepcion($"Error en el archivo ubicado en {path}", ex);
            }
            finally
            {
                if (sw is not null)
                {
                    sw.Close();
                }

            }


        }


        public static T Leer(string nombre)
        { 
            string archivo = string.Empty;
            T datosRecuperados = default;
            try
            {
                if (Directory.Exists(path))
                {
                    string[] archivosEnElPath = Directory.GetFiles(path);
                    foreach (string path in archivosEnElPath)
                    {
                        if (path.Contains(nombre))
                        {
                            archivo = path;
                            break;
                        }
                    }

                    if (archivo != null)
                    {
                        datosRecuperados = JsonSerializer.Deserialize<T>(File.ReadAllText(archivo));
                    
                    }
                }
                return datosRecuperados;
            }
            catch (Exception ex)
            {
                throw new ArchivoExcepcion($"Error en el archivo ubicado en {path}", ex);

            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public class PersonaDAO
    {
        private static string cadenaConexion;
        private SqlCommand comando;
        private SqlConnection conexion;
        private SqlDataReader lector;

        static PersonaDAO()
        {
            PersonaDAO.cadenaConexion = @"Server=.;Database=GymTP4;Trusted_Connection=True;";
        }

        public PersonaDAO()
        {
            this.conexion = new(PersonaDAO.cadenaConexion);
        }

        public void Guardar(Persona p)
        {
            try
            {
                    string query = "insert into PersonasGym (dni,nombreCompleto,edad,sexo,diaCobrado,servicio,activo) VALUES (@dni,@nombre,@edad,@sexo,@dia,@servicio,@activo)";
                    this.comando = new(query, this.conexion);
                    this.comando.Parameters.AddWithValue("@dni",p.Dni);
                    this.comando.Parameters.AddWithValue("@nombre",p.NombreCompleto);
                    this.comando.Parameters.AddWithValue("@edad",p.Edad);
                    this.comando.Parameters.AddWithValue("@sexo",p.Sexo);
                    this.comando.Parameters.AddWithValue("@dia",p.DiaCobrado);
                    this.comando.Parameters.AddWithValue("@servicio",p.Servicio);
                    this.comando.Parameters.AddWithValue("@activo",true);
                    this.conexion.Open();
                    this.comando.ExecuteNonQuery();
                
            }
            catch(Exception)
            {
                throw new SqlExcepcion("Error en la base de datos");
            }
            finally
            {
                if(this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        public void Modificar(bool activo, Persona p)
        {
            try
            { 
                string query = "update PersonasGym set activo=@activo, diaCobrado=@dia where dni=@dni";
                this.comando = new(query, this.conexion);
                this.comando.Parameters.AddWithValue("@activo", activo);
                this.comando.Parameters.AddWithValue("@dni", p.Dni);
                this.comando.Parameters.AddWithValue("@dia", p.DiaCobrado);

                this.conexion.Open();
                this.comando.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw new SqlExcepcion("Error en la base de datos");
            }
            finally
            {
                if(this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        public List<Persona> Leer(bool activo)
        {
            List<Persona> lista = new();
            try
            {
                string query = "select dni,nombreCompleto,edad,sexo,diaCobrado,servicio from PersonasGym where activo=@activo";
                this.comando = new(query, this.conexion);
                this.comando.Parameters.AddWithValue("@activo", activo);
                this.conexion.Open();
                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    int dni = int.Parse(lector["dni"].ToString());
                    string nombre = lector["nombreCompleto"].ToString();
                    int edad = int.Parse(lector["edad"].ToString());
                    int sexo = int.Parse(lector["sexo"].ToString());
                    DateTime diaCobrado = lector.GetDateTime(4);
                    int servicio = int.Parse(lector["servicio"].ToString());

                    lista.Add(new Persona(nombre, dni, edad, (eSexo)sexo, diaCobrado, (eServicio)servicio));
                }
            }
            catch (Exception)
            {
                throw new SqlExcepcion("Error en la base de datos");
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return lista;
        }
    }
}

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
                    string query = "INSERT INTO PERSONAS (DNI,NOMBRE_COMPLETO,EDAD,SEXO,DIA_COBRADO,SERVICIO,ACTIVO) VALUES (@DNI,@NOMBRE,@EDAD,@SEXO,@DIA,@SERVICIO,@ACTIVO)";
                    this.comando = new(query, this.conexion);
                    this.comando.Parameters.AddWithValue("@DNI",p.Dni);
                    this.comando.Parameters.AddWithValue("@NOMBRE",p.NombreCompleto);
                    this.comando.Parameters.AddWithValue("@EDAD",p.Edad);
                    this.comando.Parameters.AddWithValue("@SEXO",p.Sexo);
                    this.comando.Parameters.AddWithValue("@DIA",p.DiaCobrado);
                    this.comando.Parameters.AddWithValue("@SERVICIO",p.Servicio);
                    this.comando.Parameters.AddWithValue("@ACTIVO",true);
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
                string query = "UPDATE PERSONAS SET ACTIVO=@ACTIVO, DIA_COBRADO=@DIA WHERE DNI=@DNI";
                this.comando = new(query, this.conexion);
                this.comando.Parameters.AddWithValue("@ACTIVO", activo);
                this.comando.Parameters.AddWithValue("@DNI", p.Dni);
                this.comando.Parameters.AddWithValue("@DIA", p.DiaCobrado);

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
                string query = "SELECT DNI,NOMBRE_COMPLETO,EDAD,SEXO,DIA_COBRADO,SERVICIO FROM PERSONAS WHERE ACTIVO=@ACTIVO";
                this.comando = new(query, this.conexion);
                this.comando.Parameters.AddWithValue("@ACTIVO", activo);
                this.conexion.Open();
                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    int dni = int.Parse(lector["DNI"].ToString());
                    string nombre = lector["NOMBRE_COMPLETO"].ToString();
                    int edad = int.Parse(lector["EDAD"].ToString());
                    int sexo = int.Parse(lector["SEXO"].ToString());
                    DateTime diaCobrado = lector.GetDateTime(4);
                    int servicio = int.Parse(lector["SERVICIO"].ToString());

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

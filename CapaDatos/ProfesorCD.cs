using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ProfesorCD
    {
        public ProfesorCE buscarId(int IdBuscado)
        {
            SqlConnection cn = ConexionCD.conectarBD();
            cn.Open();

            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from profesor where id=@id";
            cmd.Parameters.AddWithValue("@id", IdBuscado);
            SqlDataReader drProfesor = cmd.ExecuteReader();//select
            int id;
            string nombre;
            string dni;
            DateTime fechanac;
            string telefono;
            string correo;

            if (drProfesor.Read())
            {
                id = Convert.ToInt32(drProfesor["id"]);
                nombre = Convert.ToString(drProfesor["nombre"]);
                dni = Convert.ToString(drProfesor["dni"]);
                fechanac = Convert.ToDateTime(drProfesor["fechanac"]);
                telefono = Convert.ToString(drProfesor["telefono"]);
                correo = Convert.ToString(drProfesor["correo"]);
            }
            else
            {
                id = 0;
                nombre = "";
                dni = "";
                fechanac = DateTime.Now;
                telefono = "";
                correo = "";
            }
            cn.Close();
            //Asignar los valores a las propiedades de ProductoCE
            ProfesorCE profesorCE = new ProfesorCE(id, nombre, dni, fechanac, telefono, correo);
            return profesorCE;
        }
        public List<ProfesorCE> buscarNombre(string NomBuscado)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from profesor where nombre like '%' + @nombre + '%'";
            cmd.Parameters.AddWithValue("@nombre", NomBuscado);
            SqlDataReader drProfesor = cmd.ExecuteReader(); // SELECT

            List<ProfesorCE> profesoresCE = new List<ProfesorCE>();

            while (drProfesor.Read())
            {
                int id = Convert.ToInt32(drProfesor["id"]);
                string nombre = Convert.ToString(drProfesor["nombre"]);
                string dni = Convert.ToString(drProfesor["dni"]);
                DateTime fechanac = Convert.ToDateTime(drProfesor["fechanac"]);
                string telefono = Convert.ToString(drProfesor["telefono"]);
                string correo = Convert.ToString(drProfesor["correo"]);

                ProfesorCE profesorCE = new ProfesorCE(id, nombre, dni, fechanac, telefono, correo);

                profesoresCE.Add(profesorCE);

            }

            cnx.Close();

            return profesoresCE;
        }
        public int insertar(ProfesorCE profesorCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into profesor (nombre, dni, fechanac, telefono, correo) " +
                "values (@nombre, @dni, @fechanac,@telefono, @correo)";
            cmd.Parameters.AddWithValue("@nombre", profesorCE.Nombre);
            cmd.Parameters.AddWithValue("@dni", profesorCE.Dni);
            cmd.Parameters.AddWithValue("@fechanac", profesorCE.Fechanac);
            cmd.Parameters.AddWithValue("@telefono", profesorCE.Telefono);
            cmd.Parameters.AddWithValue("@correo", profesorCE.Correo);
            int numFilas = 0;

            /***********************
             * Iniciar transaccion *
            ************************/

            using (SqlTransaction transaccion = cnx.BeginTransaction())
            {
                //vincular comando a la transaccion
                cmd.Transaction = transaccion;
                try
                {
                    //Ejecutar el comando
                    numFilas = cmd.ExecuteNonQuery(); // INSERT, UPDATE, DELETE
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    numFilas = 0;
                }
            }
            int nuevoId;
            if (numFilas > 0)
            {
                cmd.CommandText = "select max(id) as nuevoId from profesor " +
                    "where nombre=@nombre";
                cmd.Parameters["@nombre"].Value = profesorCE.Nombre;
                SqlDataReader drProfesor = cmd.ExecuteReader();
                if (drProfesor.Read())
                {
                    nuevoId = Convert.ToInt32(drProfesor["nuevoId"]);
                }
                else
                {
                    nuevoId = 0;
                }
            }
            else
            {
                nuevoId = 0;
            }

            cnx.Close();

            return nuevoId;
        }
        public int actualizar(ProfesorCE profesorCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update profesor set nombre=@nombre, dni=@dni, " +
                "fechanac=@fechanac, telefono=@telefono, correo=@correo where id=@id";
            cmd.Parameters.AddWithValue("@nombre", profesorCE.Nombre);
            cmd.Parameters.AddWithValue("@dni", profesorCE.Dni);
            cmd.Parameters.AddWithValue("@fechanac", profesorCE.Fechanac);
            cmd.Parameters.AddWithValue("@telefono", profesorCE.Telefono);
            cmd.Parameters.AddWithValue("@correo", profesorCE.Correo);
            cmd.Parameters.AddWithValue("@id", profesorCE.Id);

            int numFilas = 0;

            /***********************
             * Iniciar transaccion *
            ************************/

            using (SqlTransaction transaccion = cnx.BeginTransaction())
            {
                //vincular comando a la transaccion
                cmd.Transaction = transaccion;
                try
                {
                    //Ejecutar el comando
                    numFilas = cmd.ExecuteNonQuery(); // INSERT, UPDATE, DELETE
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    numFilas = 0;
                }
            }
            cnx.Close();

            return numFilas;

        }
        public int eliminar(ProfesorCE profesorCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from profesor where id=@id";
            cmd.Parameters.AddWithValue("@id", profesorCE.Id);

            int numFilas = 0;

            /***********************
             * Iniciar transaccion *
            ************************/

            using (SqlTransaction transaccion = cnx.BeginTransaction())
            {
                //vincular comando a la transaccion
                cmd.Transaction = transaccion;
                try
                {
                    //Ejecutar el comando
                    numFilas = cmd.ExecuteNonQuery(); // INSERT, UPDATE, DELETE
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    numFilas = 0;
                }
            }
            cnx.Close();

            return numFilas;
        }
    }
}

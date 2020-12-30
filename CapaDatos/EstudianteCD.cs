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
    public class EstudianteCD
    {
        public EstudianteCE buscarId(int IdBuscado)
        {
            SqlConnection cn = ConexionCD.conectarBD();
            cn.Open();

            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from estudiante where id=@id";
            cmd.Parameters.AddWithValue("@id", IdBuscado);
            SqlDataReader drEstudiante = cmd.ExecuteReader();//select
            int id;
            string nombre;
            string dni;
            DateTime fechaNac;
            string telefono;
            string correo;
            string nivel;
            string grado;

            if (drEstudiante.Read())
            {
                id = Convert.ToInt32(drEstudiante["id"]);
                nombre = Convert.ToString(drEstudiante["nombre"]);
                dni = Convert.ToString(drEstudiante["dni"]);
                fechaNac = Convert.ToDateTime(drEstudiante["fechanac"]);
                telefono = Convert.ToString(drEstudiante["telefono"]);
                correo = Convert.ToString(drEstudiante["correo"]);
                nivel = Convert.ToString(drEstudiante["nivel"]);
                grado = Convert.ToString(drEstudiante["grado"]);
            }
            else
            {
                id = 0;
                nombre = "";
                dni = "";
                fechaNac = DateTime.Now;
                nivel = "";
                correo = "";
                telefono = "";
                grado = "";
            }
            cn.Close();
            //Asignar los valores a las propiedades de ProductoCE
            EstudianteCE estudianteCE = new EstudianteCE(id, nombre, dni, fechaNac, telefono, correo, nivel, grado);
            return estudianteCE;
        }
        public List<EstudianteCE> buscarNombre(string NomBuscado)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from estudiante " +
                "where nombre like '%' + @nombre + '%'";
            cmd.Parameters.AddWithValue("@nombre", NomBuscado);
            SqlDataReader drEstudiante = cmd.ExecuteReader(); // SELECT

            List<EstudianteCE> estudiantesCE = new List<EstudianteCE>();

            while (drEstudiante.Read())
            {
                int id = Convert.ToInt32(drEstudiante["id"]);
                string nombre = Convert.ToString(drEstudiante["nombre"]);
                string dni = Convert.ToString(drEstudiante["dni"]);
                DateTime fechanac = Convert.ToDateTime(drEstudiante["fechanac"]);
                string telefono = Convert.ToString(drEstudiante["telefono"]);
                string correo = Convert.ToString(drEstudiante["correo"]);
                string nivel = Convert.ToString(drEstudiante["nivel"]);
                string grado = Convert.ToString(drEstudiante["grado"]);

                EstudianteCE estudianteCE = new EstudianteCE(id, nombre, dni, fechanac, telefono, correo, nivel, grado);

                estudiantesCE.Add(estudianteCE);

            }

            cnx.Close();

            return estudiantesCE;
        }
        public int insertar(EstudianteCE estudianteCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into estudiante (nombre, dni, fechanac, telefono, correo, nivel, grado) " +
                "values (@nombre, @dni, @fechanac,@telefono, @correo, @nivel, @grado)";
            cmd.Parameters.AddWithValue("@nombre", estudianteCE.Nombre);
            cmd.Parameters.AddWithValue("@dni", estudianteCE.Dni);
            cmd.Parameters.AddWithValue("@fechanac", estudianteCE.Fechanac);
            cmd.Parameters.AddWithValue("@telefono", estudianteCE.Telefono);
            cmd.Parameters.AddWithValue("@correo", estudianteCE.Correo);
            cmd.Parameters.AddWithValue("@nivel", estudianteCE.Nivel);
            cmd.Parameters.AddWithValue("@grado", estudianteCE.Grado);
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
                cmd.CommandText = "select max(id) as nuevoId from estudiante " +
                    "where nombre=@nombre";
                cmd.Parameters["@nombre"].Value = estudianteCE.Nombre;
                SqlDataReader drEstudiante = cmd.ExecuteReader();
                if (drEstudiante.Read())
                {
                    nuevoId = Convert.ToInt32(drEstudiante["nuevoId"]);
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
        public int actualizar(EstudianteCE estudianteCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update estudiante set nombre=@nombre, dni=@dni, fechanac=@fechanac, " +
                "telefono=@telefono, correo=@correo, nivel=@nivel, grado=@grado where id=@id";
            cmd.Parameters.AddWithValue("@nombre", estudianteCE.Nombre);
            cmd.Parameters.AddWithValue("@dni", estudianteCE.Dni);
            cmd.Parameters.AddWithValue("@fechanac", estudianteCE.Fechanac);
            cmd.Parameters.AddWithValue("@telefono", estudianteCE.Telefono);
            cmd.Parameters.AddWithValue("@correo", estudianteCE.Correo);
            cmd.Parameters.AddWithValue("@nivel", estudianteCE.Nivel);
            cmd.Parameters.AddWithValue("@grado", estudianteCE.Grado);
            cmd.Parameters.AddWithValue("@id", estudianteCE.Id);

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
        public int eliminar(EstudianteCE estudianteCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from estudiante where id=@id";
            cmd.Parameters.AddWithValue("@id", estudianteCE.Id);

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

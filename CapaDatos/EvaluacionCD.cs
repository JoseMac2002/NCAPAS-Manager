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
    public class EvaluacionCD
    {
        public DataTable ListarEvaluacion()
        {
            SqlConnection cn = ConexionCD.conectarBD();
            cn.Open();

            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from evaluacion";
            SqlDataAdapter datos = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            datos.Fill(dt);
            cn.Close();
            return dt;
        }
        public EvaluacionCE buscarId(int IdBuscado)
        {
            SqlConnection cn = ConexionCD.conectarBD();
            cn.Open();

            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from evaluacion where id=@id";
            cmd.Parameters.AddWithValue("@id", IdBuscado);
            SqlDataReader drProfesor = cmd.ExecuteReader();//select
            int id;
            string descripcion;

            if (drProfesor.Read())
            {
                id = Convert.ToInt32(drProfesor["id"]);
                descripcion = Convert.ToString(drProfesor["descripcion"]);
            }
            else
            {
                id = 0;
                descripcion = "";
            }
            cn.Close();
            EvaluacionCE evaluacionCE = new EvaluacionCE(id, descripcion);
            return evaluacionCE;
        }
        public List<EvaluacionCE> buscarDescripcion(string DesBuscado)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from evaluacion where descripcion like '%' + @descripcion + '%'";
            cmd.Parameters.AddWithValue("@descripcion", DesBuscado);
            SqlDataReader drEvaluacion = cmd.ExecuteReader(); // SELECT

            List<EvaluacionCE> evaluacionesCE = new List<EvaluacionCE>();

            while (drEvaluacion.Read())
            {
                int id = Convert.ToInt32(drEvaluacion["id"]);
                string descripcion = Convert.ToString(drEvaluacion["descripcion"]);

                EvaluacionCE evaluacionCE = new EvaluacionCE(id, descripcion);

                evaluacionesCE.Add(evaluacionCE);

            }

            cnx.Close();

            return evaluacionesCE;
        }
        public int insertar(EvaluacionCE evaluacionCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into evaluacion (descripcion) values (@descripcion)";
            cmd.Parameters.AddWithValue("@descripcion", evaluacionCE.Descripcion);

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
                cmd.CommandText = "select max(id) as nuevoId from evaluacion " +
                    "where descripcion=@descripcion";
                cmd.Parameters["@descripcion"].Value = evaluacionCE.Descripcion;
                SqlDataReader drEvaluacion = cmd.ExecuteReader();
                if (drEvaluacion.Read())
                {
                    nuevoId = Convert.ToInt32(drEvaluacion["nuevoId"]);
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
        public int actualizar(EvaluacionCE evaluacionCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update evaluacion set descripcion=@descripcion where id=@id";
            cmd.Parameters.AddWithValue("@descripcion", evaluacionCE.Descripcion);
            cmd.Parameters.AddWithValue("@id", evaluacionCE.Id);

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
        public int eliminar(EvaluacionCE evaluacionCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from evaluacion where id=@id";
            cmd.Parameters.AddWithValue("@id", evaluacionCE.Id);

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

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
    public class NotasCD
    {
        public int insertar(NotasCE notasCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into notas (idEstudiante, idEvalucion, idRegistro, nota) " +
                "values (@idEstudiante, @idEvalucion, @idRegistro, @nota)";
            cmd.Parameters.AddWithValue("@idEstudiante", notasCE.IdEstudiante);
            cmd.Parameters.AddWithValue("@idEvalucion", notasCE.IdEvaluacion);
            cmd.Parameters.AddWithValue("@idRegistro", notasCE.IdRegistro);
            cmd.Parameters.AddWithValue("@nota", notasCE.Nota);

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
                cmd.CommandText = "select max(id) as nuevoId from notas where idEstudiante=@idEstudiante";
                cmd.Parameters["@idEstudiante"].Value = notasCE.IdEstudiante;
                SqlDataReader drNotas = cmd.ExecuteReader();
                if (drNotas.Read())
                {
                    nuevoId = Convert.ToInt32(drNotas["nuevoId"]);
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
    }
}

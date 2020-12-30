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
    public class RegistroCD
    {
        public int insertar(RegistroCE registroCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into registro (idProfesor, idCurso, fechainicio, fechatermino) " +
                "values (@idProfesor, @idCurso, @fechainicio, @fechatermino)";
            cmd.Parameters.AddWithValue("@idProfesor", registroCE.IdProfesor);
            cmd.Parameters.AddWithValue("@idCurso", registroCE.IdCurso);
            cmd.Parameters.AddWithValue("@fechainicio", registroCE.Fechainicio);
            cmd.Parameters.AddWithValue("@fechatermino", registroCE.Fechatermino);

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
                cmd.CommandText = "select max(id) as nuevoId from registro where idProfesor=@idProfesor";
                cmd.Parameters["@idProfesor"].Value = registroCE.IdProfesor;
                SqlDataReader drRegistro = cmd.ExecuteReader();
                if (drRegistro.Read())
                {
                    nuevoId = Convert.ToInt32(drRegistro["nuevoId"]);
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

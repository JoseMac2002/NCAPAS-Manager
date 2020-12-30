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
    public class CursoCD
    {
        public CursoCE buscarId(int IdBuscado)
        {
            SqlConnection cn = ConexionCD.conectarBD();
            cn.Open();

            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from curso where id=@id";
            cmd.Parameters.AddWithValue("@id", IdBuscado);
            SqlDataReader drCurso = cmd.ExecuteReader();//select
            int id;
            string nombre;

            if (drCurso.Read())
            {
                id = Convert.ToInt32(drCurso["id"]);
                nombre = Convert.ToString(drCurso["nombre"]);
            }
            else
            {
                id = 0;
                nombre = "";
            }
            cn.Close();
            CursoCE cursoCE = new CursoCE(id, nombre);
            return cursoCE;
        }
        public List<CursoCE> buscarNombre(string NomBuscado)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from curso where nombre like '%' + @nombre + '%'";
            cmd.Parameters.AddWithValue("@nombre", NomBuscado);
            SqlDataReader drCurso = cmd.ExecuteReader(); // SELECT

            List<CursoCE> cursosCE = new List<CursoCE>();

            while (drCurso.Read())
            {
                int id = Convert.ToInt32(drCurso["id"]);
                string nombre = Convert.ToString(drCurso["nombre"]);

                CursoCE cursoCE = new CursoCE(id, nombre);

                cursosCE.Add(cursoCE);

            }

            cnx.Close();

            return cursosCE;
        }
        public int insertar(CursoCE cursoCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into curso (nombre) values (@nombre)";
            cmd.Parameters.AddWithValue("@nombre", cursoCE.Nombre);

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
                cmd.CommandText = "select max(id) as nuevoId from curso " +
                    "where nombre=@nombre";
                cmd.Parameters["@nombre"].Value = cursoCE.Nombre;
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
        public int actualizar(CursoCE cursoCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update curso set nombre=@nombre where id=@id";
            cmd.Parameters.AddWithValue("@nombre", cursoCE.Nombre);
            cmd.Parameters.AddWithValue("@id", cursoCE.Id);

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
        public int eliminar(CursoCE cursoCE)
        {
            SqlConnection cnx = ConexionCD.conectarBD();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from curso where id=@id";
            cmd.Parameters.AddWithValue("@id", cursoCE.Id);

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

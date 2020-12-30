using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class RegistroCE
    {
        private int id;
        private int idProfesor;
        private int idCurso;
        private DateTime fechainicio;
        private DateTime fechatermino;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public int IdProfesor
        {
            set { idProfesor = value; }
            get { return idProfesor; }
        }
        public int IdCurso
        {
            set { idCurso = value; }
            get { return idCurso; }
        }
        public DateTime Fechainicio
        {
            set { fechainicio = value; }
            get { return fechainicio; }
        }
        public DateTime Fechatermino
        {
            set { fechatermino = value; }
            get { return fechatermino; }
        }

        public RegistroCE(){ }
        public RegistroCE(int id, int idProfesor, int idCurso, DateTime fechainicio, DateTime fechatermino)
        {
            this.id = id;
            this.idProfesor = idProfesor;
            this.idCurso = idCurso;
            this.fechainicio = fechainicio;
            this.fechatermino = fechatermino;
        }
    }
}

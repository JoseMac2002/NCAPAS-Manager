using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class NotasCE
    {
        private int id;
        private int idEstudiante;
        private int idEvaluacion;
        private int idRegistro;
        private int nota;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public int IdEstudiante
        {
            set { idEstudiante = value; }
            get { return idEstudiante; }
        }
        public int IdEvaluacion
        {
            set { idEvaluacion = value; }
            get { return idEvaluacion; }
        }
        public int IdRegistro
        {
            set { idRegistro = value; }
            get { return idRegistro; }
        }
        public int Nota
        {
            set { nota = value; }
            get { return nota; }
        }

        public NotasCE(){ }
        public NotasCE(int id, int idEstudiante, int idEvaluacion, int idRegistro, int nota)
        {
            this.id = id;
            this.idEstudiante = idEstudiante;
            this.idEvaluacion = idEvaluacion;
            this.idRegistro = idRegistro;
            this.nota = nota;
        }
    }
}

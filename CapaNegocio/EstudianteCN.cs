using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class EstudianteCN
    {
        public EstudianteCE buscarId(int IdBuscado)
        {
            EstudianteCD estudianteCD = new EstudianteCD();
            EstudianteCE estudianteCE = estudianteCD.buscarId(IdBuscado);
            return estudianteCE;
        }
        public List<EstudianteCE> buscarNombre(string DesNom)
        {
            EstudianteCD estudianteCD = new EstudianteCD();
            List<EstudianteCE> estudiantesCE = estudianteCD.buscarNombre(DesNom);
            return estudiantesCE;
        }
        public int insertar(EstudianteCE estudianteCE)
        {
            EstudianteCD estudianteCD = new EstudianteCD();
            int nunFilas = estudianteCD.insertar(estudianteCE);
            return nunFilas;
        }
        public int actualizar(EstudianteCE estudianteCE)
        {
            EstudianteCD estudianteCD = new EstudianteCD();
            int nunFilas = estudianteCD.actualizar(estudianteCE);
            return nunFilas;
        }
        public int eliminar(EstudianteCE estudianteCE)
        {
            EstudianteCD estudianteCD = new EstudianteCD();
            int nunFilas = estudianteCD.eliminar(estudianteCE);
            return nunFilas;
        }
    }
}

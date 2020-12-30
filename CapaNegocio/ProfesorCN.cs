using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ProfesorCN
    {
        public ProfesorCE buscarId(int IdBuscado)
        {
            ProfesorCD profesorCD = new ProfesorCD();
            ProfesorCE profesorCE = profesorCD.buscarId(IdBuscado);
            return profesorCE;
        }

        public List<ProfesorCE> buscarNombre(string DesNom)
        {
            ProfesorCD profesorCD = new ProfesorCD();
            List<ProfesorCE> profesoresCE = profesorCD.buscarNombre(DesNom);
            return profesoresCE;
        }
        public int insertar(ProfesorCE profesorCE)
        {
            ProfesorCD profesorCD = new ProfesorCD();
            int nunFilas = profesorCD.insertar(profesorCE);
            return nunFilas;
        }
        public int actualizar(ProfesorCE profesorCE)
        {
            ProfesorCD profesorCD = new ProfesorCD();
            int nunFilas = profesorCD.actualizar(profesorCE);
            return nunFilas;
        }
        public int eliminar(ProfesorCE profesorCE)
        {
            ProfesorCD profesorCD = new ProfesorCD();
            int nunFilas = profesorCD.eliminar(profesorCE);
            return nunFilas;
        }
    }
}

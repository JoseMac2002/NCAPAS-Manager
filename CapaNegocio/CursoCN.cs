using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CursoCN
    {
       
        public CursoCE buscarId(int IdBuscado)
        {
            CursoCD cursoCD = new CursoCD();
            CursoCE CursoCE = cursoCD.buscarId(IdBuscado);
            return CursoCE;
        }
        public List<CursoCE> buscarNombre(string DesNom)
        {
            CursoCD cursoCD = new CursoCD();
            List<CursoCE> CursosCE = cursoCD.buscarNombre(DesNom);
            return CursosCE;
        }
        public int insertar(CursoCE cursoCE)
        {
            CursoCD cursoCD = new CursoCD();
            int nunFilas = cursoCD.insertar(cursoCE);
            return nunFilas;
        }
        public int actualizar(CursoCE cursoCE)
        {
            CursoCD cursoCD = new CursoCD();
            int nunFilas = cursoCD.actualizar(cursoCE);
            return nunFilas;
        }
        public int eliminar(CursoCE cursoCE)
        {
            CursoCD cursoCD = new CursoCD();
            int nunFilas = cursoCD.eliminar(cursoCE);
            return nunFilas;
        }
        
    }
}

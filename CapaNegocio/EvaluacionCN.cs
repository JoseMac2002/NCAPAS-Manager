using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class EvaluacionCN
    {
        public DataTable ListarEvaluacion()
        {
            EvaluacionCD evaluacionCD = new EvaluacionCD(); 
            return evaluacionCD.ListarEvaluacion();
        }
        public EvaluacionCE buscarId(int IdBuscado)
        {
            EvaluacionCD evaluacionCD = new EvaluacionCD();
            EvaluacionCE evaluacionCE = evaluacionCD.buscarId(IdBuscado);
            return evaluacionCE;
        }
        public List<EvaluacionCE> buscarDescripcion(string DesBuscado)
        {
            EvaluacionCD evaluacionCD = new EvaluacionCD();
            List<EvaluacionCE> evaluacionesCE = evaluacionCD.buscarDescripcion(DesBuscado);
            return evaluacionesCE;
        }
        public int insertar(EvaluacionCE evaluacionCE)
        {
            EvaluacionCD evaluacionCD = new EvaluacionCD();
            int nunFilas = evaluacionCD.insertar(evaluacionCE);
            return nunFilas;
        }
        public int actualizar(EvaluacionCE evaluacionCE)
        {
            EvaluacionCD evaluacionCD = new EvaluacionCD();
            int nunFilas = evaluacionCD.actualizar(evaluacionCE);
            return nunFilas;
        }
        public int eliminar(EvaluacionCE evaluacionCE)
        {
            EvaluacionCD evaluacionCD = new EvaluacionCD();
            int nunFilas = evaluacionCD.eliminar(evaluacionCE);
            return nunFilas;
        }
        public List<EvaluacionCE> Leer()
        {
            // Instanciamos capaDatos
            EvaluacionCD evaluacionCD = new EvaluacionCD();

            // Creamos lista
            List<EvaluacionCE> evaluacionCEs = evaluacionCD.Leer();

            // retornamos lista
            return evaluacionCEs;
        }
    }
}

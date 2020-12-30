using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NotasCN
    {
        public int insertar(NotasCE notasCE)
        {
            NotasCD notasCD = new NotasCD();
            int nunFilas = notasCD.insertar(notasCE);
            return nunFilas;
        }
    }
}

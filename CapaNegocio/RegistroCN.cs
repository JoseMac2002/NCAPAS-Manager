using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class RegistroCN
    {
        public int insertar(RegistroCE registroCE)
        {
            RegistroCD registroCD = new RegistroCD();
            int numFilas = registroCD.Crear(registroCE);
            return numFilas;
        }
    }
}

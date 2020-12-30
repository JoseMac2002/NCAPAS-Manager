using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CursoCE
    {
        private int id;
        private string nombre;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        public CursoCE(){ }
        public CursoCE(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}

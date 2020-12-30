using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EvaluacionCE
    {
        private int id;
        private string descripcion;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Descripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }

        public EvaluacionCE() { }
        public EvaluacionCE(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

        public static implicit operator EvaluacionCE(DataTable v)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ProfesorCE
    {
        //Propiedad
        private int id;
        private string nombre;
        private string dni;
        private DateTime fechanac;
        private string telefono;
        private string correo;

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
        public string Dni
        {
            set { dni = value; }
            get { return dni; }
        }
        public DateTime Fechanac
        {
            set { fechanac = value; }
            get { return fechanac; }
        }
        public string Telefono
        {
            set { telefono = value; }
            get { return telefono; }
        }
        public string Correo
        {
            set { correo = value; }
            get { return correo; }
        }

        public ProfesorCE(){ }
        public ProfesorCE(int id, string nombre, string dni, DateTime fechanac, string telefono, string correo)
        {
            this.id = id;
            this.nombre = nombre;
            this.dni = dni;
            this.fechanac = fechanac;
            this.telefono = telefono;
            this.correo = correo;
        }
    }
}

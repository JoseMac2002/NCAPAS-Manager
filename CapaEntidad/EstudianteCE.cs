using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EstudianteCE
    {
        private int id;
        private string nombre;
        private string dni;
        private DateTime fechanac;
        private string telefono;
        private string correo;
        private string nivel;
        private string grado;

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
        public string Nivel
        {
            set { nivel = value; }
            get { return nivel; }
        }
        public string Grado
        {
            set { grado = value; }
            get { return grado; }
        }

        public EstudianteCE(){ }
        public EstudianteCE(int id, string nombre, string dni, DateTime fechanac, string telefono, 
            string correo, string nivel, string grado)
        {
            this.id = id;
            this.nombre = nombre;
            this.dni = dni;
            this.fechanac = fechanac;
            this.telefono = telefono;
            this.correo = correo;
            this.nivel = nivel;
            this.grado = grado;
        }
    }
}

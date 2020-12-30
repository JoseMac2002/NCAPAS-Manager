using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class AlumnosCP : Form
    {
        public AlumnosCP()
        {
            InitializeComponent();
        }
        private bool VerificarFormulario()
        {
            bool verificar = txtNombre.Text.Length > 0 && txtDNI.Text.Length > 0 && txtDNI.Text.Length > 0 && txtCorreo.Text.Length > 0;
            return verificar;
        }
        private void LimpiarFormulario()
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            txtDNI.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";

            dtpFechaNac.Value = DateTime.Now;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            resetControl();
        }
        private void resetControl()
        {
            txtId.Text = "0";
            txtNombre.Clear();
            txtDNI.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtBuscar.Clear();
            txtGrado.Clear();
            txtNivel.Clear();
            dgvEstudiantes.DataSource = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "0")
            {
                if (VerificarFormulario())
                {
                    string nombre = txtNombre.Text;
                    string dni = (txtDNI.Text);
                    DateTime fechaNac = dtpFechaNac.Value;
                    string telefono = (txtTelefono.Text);
                    string correo = txtCorreo.Text;
                    string nivel = txtNivel.Text;
                    string grado = (txtGrado.Text);


                    EstudianteCE estudianteCE = new EstudianteCE(0, nombre, dni, fechaNac, telefono, correo, nivel, grado);
                    EstudianteCN estudianteCN = new EstudianteCN();

                    int idNuevo = estudianteCN.insertar(estudianteCE);
                    txtId.Text = idNuevo.ToString();
                }
                else
                {
                    MessageBox.Show("Los datos del formulario no han sido rellenados correctamente.");
                }
            }
            else
            {
                LimpiarFormulario();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvEstudiantes.DataSource = null;
            string desBusqueda = txtBuscar.Text;

            //Verificar si existe algo para buscar
            if (desBusqueda.Length >= 2)
            {
                //Instanciar la CapaNegocios
                EstudianteCN estudianteCN = new EstudianteCN();
                //Ejecutar el metodo de busqueda 
                List<EstudianteCE> estudianteCE = estudianteCN.buscarNombre(desBusqueda);
                //Asignar la coleccion al grid
                dgvEstudiantes.DataSource = estudianteCE;

                dgvEstudiantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Leer las cajas de textos
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            string dni = txtDNI.Text;
            DateTime fechaNac = dtpFechaNac.Value;
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;
            string grado = txtGrado.Text;
            string nivel = txtNivel.Text;
                
            //Instanciar un ClienteCE
            EstudianteCE estudianteCE = new EstudianteCE(id, nombre, dni, fechaNac, telefono, correo,grado,nivel);
            //Instanciar un ClienteCN
            EstudianteCN estudianteCN = new EstudianteCN();

            if (txtId.Text == "0")
            {
                if ((nombre.Length > 0) && (dni.Length ==8) && (telefono.Length >= 9))
                {

                    //***** NUEVO REGISTRO *****
                    int nuevoId = estudianteCN.insertar(estudianteCE);
                    //Mostrar el nuevoId
                    txtId.Text = nuevoId.ToString();

                    //Asignar la coleccion al grid
                    dgvEstudiantes.DataSource = estudianteCE;
                    MessageBox.Show("El registro se ha insertado correctamente!",
                     "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetControl();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el nuevo registro por falta de algun dato");
                }
            }
            else
            {
                //**** ACTUALIZACION****
                estudianteCN.actualizar(estudianteCE);
                //Asignar la coleccion al grid
                dgvEstudiantes.DataSource = estudianteCE;
                MessageBox.Show("El registro se ha actualizado correctamente!",
                 "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            dgvEstudiantes.DataSource = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "0")
            {
                int id = Convert.ToInt32(txtId.Text);
                EstudianteCE estudianteCE = new EstudianteCE();
                estudianteCE.Id = id;

                EstudianteCN estudianteCN = new EstudianteCN();


                int numFile = estudianteCN.eliminar(estudianteCE);

                MessageBox.Show(numFile + " Filas eliminadas");

                if (numFile > 0)
                {
                    LimpiarFormulario();
                }
            }
            else
            {
                MessageBox.Show("No podemos eliminar con datos nulos o inexistentes.");
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Capturar letra introducida
            char letra = e.KeyChar;
            // Verificar si es:
            // Letra
            // Si es backspace
            // Si es spacebar
            // Si es "."
            bool verificar = char.IsLetter(letra) || char.IsControl(letra) || char.IsWhiteSpace(letra) || letra == '.';


            if (verificar)
            {
                // Si cumple los requisitos deja introducir la letra
                e.Handled = false;
            }
            else
            {
                // Si no, no introduzcas la letra
                e.Handled = true;
            }
            // Cambia la letra a mayuscula
            e.KeyChar = char.ToUpper(letra);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Capturar letra introducida
            char letra = e.KeyChar;
            // Verificar si es:
            // Letra
            // Si es backspace
            // Si es spacebar
            // Si es "."
            bool verificar = char.IsLetter(letra) || char.IsControl(letra) || char.IsWhiteSpace(letra) || letra == '.';


            if (verificar)
            {
                // Si cumple los requisitos deja introducir la letra
                e.Handled = false;
            }
            else
            {
                // Si no, no introduzcas la letra
                e.Handled = true;
            }
            // Cambia la letra a mayuscula
            e.KeyChar = char.ToUpper(letra);
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Capturar letra
            char letra = e.KeyChar;

            // Verificar si es:
            // Numero
            // Si es backspace
            bool verificar = char.IsNumber(letra) || char.IsControl(letra);

            if (verificar)
            {
                // Si cumple los requisitos deja introducir la letra
                e.Handled = false;
            }
            else
            {
                // Si no, no introduzcas la letra
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Capturar letra
            char letra = e.KeyChar;

            // Verificar si es:
            // Numero
            // Si es backspace

            bool verificar = char.IsNumber(letra) || char.IsControl(letra);

            if (verificar)
            {
                // Si cumple los requisitos deja introducir la letra
                e.Handled = false;
            }
            else
            {
                // Si no, no introduzcas la letra
                e.Handled = true;
            }
        }

        private void dgvEstudiantes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count >= 1)
            {
                //Recoger la fila seleccionada
                DataGridViewRow fila = dgvEstudiantes.SelectedRows[0];

                txtId.Text = fila.Cells["id"].Value.ToString();
                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                txtDNI.Text = fila.Cells["dni"].Value.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["correo"].Value.ToString();
                txtNivel.Text = fila.Cells["nivel"].Value.ToString();
                txtGrado.Text = fila.Cells["grado"].Value.ToString();

            }
        }
    }
}

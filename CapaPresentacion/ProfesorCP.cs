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
    public partial class ProfesorCP : Form
    {
        public ProfesorCP()
        {
            InitializeComponent();
        }
        private void AdministradorCP_Load(object sender, EventArgs e)
        {


        }
        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                // extraer nombre a buscar
                string name = txtBuscar.Text;
                // Instanciar objeto ProfesorCN
                ProfesorCN profesorCN = new ProfesorCN();
                // Insertar retornando los datos del metodo Buscarnombre
                dgvProfesores.DataSource = profesorCN.buscarNombre(name);
            }
            else
            {

            }
            
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


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

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
                    string telefono =(txtTelefono.Text);
                    string correo = txtCorreo.Text;

                    ProfesorCE profesorCE = new ProfesorCE(0, nombre, dni, fechaNac, telefono, correo);
                    ProfesorCN profesorCN = new ProfesorCN();

                    int idNuevo = profesorCN.insertar(profesorCE);
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

        private void dgvProfesores_SelectionChanged(object sender, EventArgs e)
        {
            // Controlar la seleccion
            if (dgvProfesores.SelectedRows.Count >= 1)
            {
                // Asignar una variable a la primera fila seleccionada
                DataGridViewRow fila = dgvProfesores.SelectedRows[0];

                // Mostrar los valores
                txtId.Text = fila.Cells["id"].Value.ToString();
                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                txtDNI.Text = fila.Cells["dni"].Value.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["correo"].Value.ToString();
                dtpFechaNac.Value = Convert.ToDateTime(fila.Cells["fechaNac"].Value);

            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "0")
            {
                if (VerificarFormulario())
                {
                    int id = Convert.ToInt32(txtId.Text);
                    string nombre = txtNombre.Text;
                    string dni = txtDNI.Text;
                    DateTime fechaNac = dtpFechaNac.Value;
                    string telefono = txtTelefono.Text;
                    string correo = txtCorreo.Text;

                    ProfesorCE profesorCE = new ProfesorCE(id, nombre, dni, fechaNac, telefono, correo);

                    ProfesorCN profesorCN = new ProfesorCN();

                    int numFile = profesorCN.actualizar(profesorCE);

                    MessageBox.Show(numFile + " Filas Actualizadas");


                }
                else
                {
                    MessageBox.Show("Al parecer no se ha llenado correctamente el formulario.");
                }
            }
            else
            {
                MessageBox.Show("No podemos actualizar con datos nulos o inexistentes.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "0")
            {
                int id = Convert.ToInt32(txtId.Text);
                ProfesorCE profesorCE = new ProfesorCE();
                profesorCE.Id = id;

                ProfesorCN profesorCN = new ProfesorCN();


                int numFile = profesorCN.eliminar(profesorCE);

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

        private void txtBuscar_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtDNI_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

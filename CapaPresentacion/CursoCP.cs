﻿using System;
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
    public partial class CursoCP : Form
    {
        public CursoCP()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvDatos.DataSource = null;
            string buscar = txtBuscar.Text;

            CursoCN clienteCN = new CursoCN();
            //Ejecutar el metodo de busqueda 
            List<CursoCE> cursoCEs = clienteCN.buscarNombre(buscar);
            //Asignar la coleccion al grid
            dgvDatos.DataSource = cursoCEs;
        }
       
      

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (VerificarFormulario())
            {
                if (txtId.Text == "0")
                {
                    // nuevo
                    string nombre = txtNombre.Text;
                    CursoCE cursoCE = new CursoCE(0, nombre);
                    CursoCN cursoCN = new CursoCN();

                    int id = cursoCN.insertar(cursoCE);

                    txtId.Text = id.ToString();
                }
                else
                {
                    // id diferente
                    Limpiar();
                }
            }
            else
            {
                MessageBox.Show("Por favor, verifique que el formulario haya sido rellenado.");
            }
        }
        private bool VerificarFormulario()
        {
            bool verificar = txtNombre.Text.Length > 0;
            return verificar;
        }
        private void Limpiar()
        {
            txtId.Text = "0";
            txtNombre.Text = "";
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvDatos.SelectedRows[0];
                txtId.Text = fila.Cells["id"].Value.ToString();
                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (VerificarFormulario())
            {
                if (txtId.Text != "0")
                {
                    int id = Convert.ToInt32(txtId.Text);
                    string nombre = txtNombre.Text;

                    CursoCE cursoCE = new CursoCE(id, nombre);

                    CursoCN cursoCN = new CursoCN();

                    int numFil = cursoCN.actualizar(cursoCE);

                    MessageBox.Show(numFil + " Filas afectadas");
                }
                else
                {
                    MessageBox.Show("No se puede editar con datos vacios.");
                }

            }
            else
            {
                MessageBox.Show("Si vas a editar, no deje vacios los valores.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "0")
            {
                int id = Convert.ToInt32(txtId.Text);
                CursoCE cursoCE = new CursoCE();
                cursoCE.Id = id;
                CursoCN cursoCN = new CursoCN();
                int numFil = cursoCN.eliminar(cursoCE);
                MessageBox.Show(numFil + " Filas afectadas");
                if (numFil > 0)
                {
                    Limpiar();
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar mientras los datos esten vacios o incompletos.");
            }
        }
    }

}

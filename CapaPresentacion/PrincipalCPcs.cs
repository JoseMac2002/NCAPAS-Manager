using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class PrincipalCPcs : Form
    {
        public PrincipalCPcs()
        {
            InitializeComponent();
        }

        private void profesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfesorCP profesorCP = new ProfesorCP();
            //establecer como hijo
            profesorCP.MdiParent = this;
            //maximizar
            profesorCP.WindowState = FormWindowState.Maximized;
            profesorCP.Show();
        }

        private void estudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnosCP alumnosCP = new AlumnosCP();
            //establecer como hijo
            alumnosCP.MdiParent = this;
            //maximizar
            alumnosCP.WindowState = FormWindowState.Maximized;
            alumnosCP.Show();
        }
    }
}

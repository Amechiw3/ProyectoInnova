using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProyectoInnovaDESK.Controllers.Helpers;
using ProyectoInnovaDESK.Reportes;

namespace ProyectoInnovaDESK.Views
{
    public partial class frmPrincipal : Form
    {
        public static UsuarioHelper uHelper;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (uHelper == null)
            {
                frmLogin vLogin = new frmLogin();
                vLogin.ShowDialog();
            }
            if (uHelper != null)
            {
                procesarPermisos();
            }
            else
            {
                MessageBox.Show("Se require se autentifique", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void procesarPermisos()
        {
            int permiso = 0;
            foreach (object obj in this.groupBox1.Controls)
            {
                if (obj is Button)
                {
                    Button tsmi = (Button)obj;
                    permiso = Convert.ToInt32(tsmi.Tag);
                    //var SessionActiva = frmMainSistema.SessionActiva;
                    tsmi.Enabled = uHelper.TienePermisos(permiso);
                    if (!tsmi.Enabled)
                    {
                        tsmi.BackColor = Color.FromArgb(211, 47, 47);
                    }
                }
            }
        }

        private void btnCandidata_Click(object sender, EventArgs e)
        {
            var frm = new frmSeaCandidata();
            frm.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            var frm = new frmSeaUsuario();
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMunicipios_Click(object sender, EventArgs e)
        { 

        }

        private void btnRestricciones_Click(object sender, EventArgs e)
        {

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            var frmreportes = new frmReportes();
            frmreportes.ShowDialog();
        }
    }
}

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
                //TODO: ACTIVAR TODOS LOS CONTROLES SEGUN EL PERMISO
            }
            else
            {
                MessageBox.Show("Se require se autentifique", "Eror..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCandidata_Click(object sender, EventArgs e)
        {
            var frm = new frmSeaCandidata();
            frm.Show();
        }
    }
}

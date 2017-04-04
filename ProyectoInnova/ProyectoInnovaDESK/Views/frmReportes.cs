using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProyectoInnovaDESK.Controllers;
using ProyectoInnovaDESK.Controllers.Helpers;
using ProyectoInnovaDESK.Reportes;

namespace ProyectoInnovaDESK.Views
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            procesarPermisos();
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
                    tsmi.Enabled = frmPrincipal.uHelper.TienePermisos(permiso);
                    if (!tsmi.Enabled)
                    {
                        tsmi.BackColor = Color.FromArgb(211, 47, 47);
                    }
                }
            }
        }

        private void btnRptcandidataporanio_Click(object sender, EventArgs e)
        {
            var frmrptcandidataanio = new frmRptCandidataConvocatoria();
            frmrptcandidataanio.ShowDialog();
        }

        private void btnRptcandidatapopular_Click(object sender, EventArgs e)
        {
            var frmrptcandidataanio = new frmRptCandidataConvocatoria();
            frmrptcandidataanio.ShowDialog();
        }

        private void btnRptcandidataporcapturista_Click(object sender, EventArgs e)
        {
            var frmrptcandidataanio = new frmRptCandidataUsuario();
            frmrptcandidataanio.ShowDialog();
        }

        private void btnRptcandidatapormunicipo_Click(object sender, EventArgs e)
        {
            var frmrptcandidataanio = new Form1();
            frmrptcandidataanio.ShowDialog();
        }
    }
}

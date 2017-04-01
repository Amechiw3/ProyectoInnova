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

namespace ProyectoInnovaDESK.Views
{
    public partial class frmSeaCandidata : Form
    {
        public frmSeaCandidata()
        {
            InitializeComponent();
        }

        private void frmSeaCandidata_Load(object sender, EventArgs e)
        {

        }

        public void llenardatos(string dato = "")
        {
            dgvDatos.DataSource = CandidataManager.ListarContenido(dato);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            llenardatos(txtBuscar.Text);
        }

        private void dgvDatos_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = $"Registros: {dgvDatos.RowCount}";
        }
    }
}

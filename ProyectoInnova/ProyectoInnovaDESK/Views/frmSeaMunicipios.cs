using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProyectoInnovaDESK.Tools;
using ProyectoInnovaDESK.Controllers;
using ProyectoInnovaDESK.Models;


namespace ProyectoInnovaDESK.Views
{
    public partial class frmSeaMunicipios : Form
    {
        public frmSeaMunicipios()
        {
            InitializeComponent();
        }

        private void dgvDatos_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = $"Registros: {dgvDatos.RowCount}";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frnAddMunicipio = new frnAddMunicipios();
            frnAddMunicipio.ShowDialog();
            
        }

        private void frmSeaMunicipios_Load(object sender, EventArgs e)
        {
            this.dgvDatos.AutoGenerateColumns = false;
            this.dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            llenardatos();
        }

        public void llenardatos()
        {
            dgvDatos.DataSource = MunicipioManager.ListarContenido();
        }
    }
}

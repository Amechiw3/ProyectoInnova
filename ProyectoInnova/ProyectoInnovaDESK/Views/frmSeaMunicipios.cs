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

        private void bnEditar_Click(object sender, EventArgs e)
        {
            var update = new frmUpdMunicipio(int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString()));
            update.ShowDialog();
            llenardatos();


        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text !="")
            {
                dgvDatos.DataSource = MunicipioManager.BuscarMunicipio(txtBuscar.Text);

            }
            else
            {
                llenardatos();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var Borrar = MunicipioManager.BuscarPorId(int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString()));
            MunicipioManager.Borrar(Borrar);
            llenardatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}

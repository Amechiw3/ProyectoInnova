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
    public partial class frmSeaCandidata : Form
    {
        public frmSeaCandidata()
        {
            InitializeComponent();
        }

        private void frmSeaCandidata_Load(object sender, EventArgs e)
        {
            this.dgvDatos.AutoGenerateColumns = false;
            this.dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            llenardatos(cboAnioConv.Text);
            procesarPermisos();
            llenarcombo();
        }

        public void llenarcombo()
        {
            List<String> deptos = CandidataManager.getAniosConvocatoria();
            cboAnioConv.DataSource = deptos;
        }

        public void procesarPermisos()
        {
            int permiso = 0;
            foreach (object obj in this.Controls)
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
                if (obj is TextBox)
                {
                    TextBox tsmi = (TextBox)obj;
                    permiso = Convert.ToInt32(tsmi.Tag);
                    //var SessionActiva = frmMainSistema.SessionActiva;
                    tsmi.Enabled = frmPrincipal.uHelper.TienePermisos(permiso);
                    if (!tsmi.Enabled)
                    {
                        //tsmi.BackColor = Color.FromArgb(211, 47, 47);
                    }
                }
            }
        }

        public void llenardatos(string anio ,string dato = "")
        {
            dgvDatos.DataSource = CandidataManager.ListarContenidoBuscar(anio, dato);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                llenardatos(cboAnioConv.Text,  txtBuscar.Text);
            }
            else
            {
                llenardatos(cboAnioConv.Text, "");
            }
        }

        private void dgvDatos_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = $"Registros: {dgvDatos.RowCount}";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frmAgregarCandidata = new frmAddCandidata();
            frmAgregarCandidata.ShowDialog();
            llenardatos(cboAnioConv.Text);
            llenarcombo();
        }

        private void bnEditar_Click(object sender, EventArgs e)
        {
            var update = new Views.frmUpdCandidata(int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString()));
            update.ShowDialog();
            llenardatos(cboAnioConv.Text);
            llenarcombo();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Candidata candidata = CandidataManager.getData(int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString()));
            CandidataManager.BorrarCandidata(candidata);
            llenardatos(cboAnioConv.Text);
            llenarcombo();
        }

        private void cboAnioConv_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenardatos(cboAnioConv.Text);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProyectoInnovaDESK.Models;
using ProyectoInnovaDESK.Controllers;

namespace ProyectoInnovaDESK.Views
{
    public partial class frmAddCandidata : Form
    {
        public frmAddCandidata()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var candidata = new Candidata();
            candidata.sNombre = txtNombre.Text;
            candidata.sApellido = txtApellido.Text;
            candidata.dfnac = DateTime.Parse(dtpFNac.Value.ToShortDateString());
            candidata.sCorreo = txtCorreo.Text;
            candidata.sCurp = txtCurp.Text;
            candidata.sNivelEstudios = cboNivelEstudios.Text;
            candidata.sAnioConvocatoria = txtAnioConvocatoria.Text;
            candidata.fotografia = webCamCandidatas.ImagenString;
            candidata.usuarios = UsuarioManager.BuscarPorNoEmpleado(frmPrincipal.uHelper.usuario.pkUsuario);
            candidata.municipio = MunicipioManager.BuscarPorId(int.Parse(cboMunicipo.SelectedValue.ToString()));
            candidata.sDescripcion = txtDescripcion.Text;

            CandidataManager.RegistrarCandidata(candidata);
            
            this.Close();

        }

        public void llenarcombomunicipios()
        {
            cboMunicipo.DisplayMember = "sNombre";
            cboMunicipo.ValueMember = "pkMunicipio";
            cboMunicipo.DataSource = MunicipioManager.ListarContenido();

            cboNivelEstudios.SelectedItem = 1;
        }

        private void frmAddCandidata_Load(object sender, EventArgs e)
        {
            llenarcombomunicipios();
        }
    }
}

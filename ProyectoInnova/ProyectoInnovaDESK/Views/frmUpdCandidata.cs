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
using ProyectoInnovaDESK.Models;
using ProyectoInnovaDESK.Controllers;

namespace ProyectoInnovaDESK.Views
{
    public partial class frmUpdCandidata : Form
    {
        Candidata candidataData;
        public frmUpdCandidata(Candidata xcandidata)
        {
            InitializeComponent();
            this.candidataData = xcandidata;
            FillData();
        }

        Candidata candidata;
        public void FillData()
        {
            candidata = CandidataManager.getData(candidataData);
            txtNombre.Text = candidata.sNombre;
            txtApellido.Text = candidata.sApellido;
            dtpFNac.Value = candidata.dfnac;
            txtCorreo.Text = candidata.sCorreo;
            txtCurp.Text = candidata.sCurp;
            txtNivelEst.Text = candidata.sNivelEstudios;
            txtAnioConvocatoria.Text = candidata.sAnioConvocatoria;
            webCamCandidatas.colocarFotografia(candidata.fotografia);
            cboMunicipo.Text = candidata.municipio.sNombre;
            txtDescripcion.Text = candidata.sDescripcion;
            UsuarioManager.BuscarPorNoEmpleado(frmPrincipal.uHelper.usuario.pkUsuario);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            candidata.sNombre = txtNombre.Text;
            candidata.sApellido = txtApellido.Text;
            candidata.dfnac = DateTime.Parse(dtpFNac.Value.ToShortDateString());
            candidata.sCorreo = txtCorreo.Text;
            candidata.sCurp = txtCurp.Text;
            candidata.sNivelEstudios = txtNivelEst.Text;
            candidata.sAnioConvocatoria = txtAnioConvocatoria.Text;
            candidata.fotografia = webCamCandidatas.ImagenString;
            candidata.usuarios = UsuarioManager.BuscarPorNoEmpleado(frmPrincipal.uHelper.usuario.pkUsuario);
            candidata.municipio = MunicipioManager.BuscarPorId(int.Parse(cboMunicipo.Text.ToString()));
            candidata.sDescripcion = txtDescripcion.Text;

            CandidataManager.RegistrarCandidata(candidata);

            this.Close();
        }

        private void frmUpdCandidata_Load(object sender, EventArgs e)
        {

        }
    }
}

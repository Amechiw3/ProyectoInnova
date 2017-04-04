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

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace ProyectoInnovaDESK.Reportes
{
    public partial class frmRptCandidataUsuario : Form
    {
        ReportDocument crpDocument;

        public frmRptCandidataUsuario()
        {
            InitializeComponent();
        }

        private void frmRptCandidataUsuario_Load(object sender, EventArgs e)
        {
            llenarcombo();
        }

        private void llenarcombo()
        {
            cboUsuarios.DisplayMember = "sNombre";
            cboUsuarios.ValueMember = "pkUsuario";
            cboUsuarios.DataSource = UsuarioManager.ListarContenido();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            crpDocument = new ReportDocument();
            crpDocument.Load(@"Reportes\rptCandidataUsuario.rpt");
            crpDocument.SetDataSource(CandidataManager.reporteCandidataUsuario(int.Parse(cboUsuarios.SelectedValue.ToString())));
            //crpDocument.SetParameterValue("NombreParametros",valor);
            this.crystalReportViewer1.ReportSource = crpDocument;
        }
    }
}

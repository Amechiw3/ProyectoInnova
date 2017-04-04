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
using ProyectoInnovaDESK.Reportes;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace ProyectoInnovaDESK.Reportes
{
    public partial class frmRptCandidataPopular : Form
    {
        ReportDocument crpDocument;

        public frmRptCandidataPopular()
        {
            InitializeComponent();
        }

        private void frmRptCandidataPopular_Load(object sender, EventArgs e)
        {
            crpDocument = new ReportDocument();
            crpDocument.Load(@"Reportes\rptCandidataPopular.rpt");
            crpDocument.SetDataSource(CandidataManager.ListarCandidatasPopulares3());
            //crpDocument.SetParameterValue("NombreParametros",valor);
            this.crystalReportViewer1.ReportSource = crpDocument;
        }
    }
}

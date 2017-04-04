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
    public partial class frmRptCandidataPopularMunicipio : Form
    {
        ReportDocument crpDocument;

        public frmRptCandidataPopularMunicipio()
        {
            InitializeComponent();
        }

        private void frmRptCandidataPopularMunicipio_Load(object sender, EventArgs e)
        {
            crpDocument = new ReportDocument();
            crpDocument.Load(@"Reportes\rptCandidataPopularMunicipo.rpt");
            crpDocument.SetDataSource(CandidataManager.ListarCandidatasPopularesMunicipio());
            //crpDocument.SetParameterValue("NombreParametros",valor);
            this.crystalReportViewer1.ReportSource = crpDocument;
        }
    }
}

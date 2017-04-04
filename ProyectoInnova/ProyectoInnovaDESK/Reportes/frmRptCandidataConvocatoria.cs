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
    public partial class frmRptCandidataConvocatoria : Form
    {
        ReportDocument crpDocument;

        public frmRptCandidataConvocatoria()
        {
            InitializeComponent();
        }

        private void frmRptCandidataConvocatoria_Load(object sender, EventArgs e)
        {
            llenarcombo();
        }
        
        public void llenarcombo()
        {
            List<String> deptos = CandidataManager.getAniosConvocatoria();
            comboBox1.DataSource = deptos;
        }

        public void generarReporte()
        {
            crpDocument = new ReportDocument();
            crpDocument.Load(@"Reportes\rptCandidataConvocatoria.rpt");
            crpDocument.SetDataSource(CandidataManager.reporteCandidataAnioConvocatoria(comboBox1.Text.Trim()));
            //crpDocument.SetParameterValue("NombreParametros",valor);
            this.crpVReporte.ReportSource = crpDocument;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generarReporte();
        }
    }
}

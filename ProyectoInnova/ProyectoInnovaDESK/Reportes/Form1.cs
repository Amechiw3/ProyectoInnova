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

namespace ProyectoInnovaDESK
{
    public partial class Form1 : Form
    {
        ReportDocument crpDocument;

        public Form1()
        {
            InitializeComponent();
            llenarcombomunicipios();
        }

        private void GenerarReporte()
        {
            crpDocument = new ReportDocument();
            crpDocument.Load(@"Reportes\rptCandidataMunicipio.rpt");
            crpDocument.SetDataSource(CandidataManager.reporteCandidataMunicipio(int.Parse(comboBox1.SelectedValue.ToString())));
            //crpDocument.SetParameterValue("NombreParametros",valor);
            this.crystalReportViewer1.ReportSource = crpDocument;

        }

        public void llenarcombomunicipios()
        {
            comboBox1.DisplayMember = "sNombre";
            comboBox1.ValueMember = "pkMunicipio";
            comboBox1.DataSource = MunicipioManager.ListarContenido();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }
    }
}

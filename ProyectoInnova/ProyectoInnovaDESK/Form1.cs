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

namespace ProyectoInnovaDESK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            llenarcombomunicipios();
        }

        public void llenarcombomunicipios()
        {
            comboBox1.DisplayMember = "sNombre";
            comboBox1.ValueMember = "pkMunicipio";
            comboBox1.DataSource = MunicipioManager.ListarContenido();
        }
    }
}

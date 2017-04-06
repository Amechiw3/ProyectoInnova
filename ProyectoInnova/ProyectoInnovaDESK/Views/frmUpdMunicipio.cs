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
    public partial class frmUpdMunicipio : Form
    {
        int municipio;
        public frmUpdMunicipio(int xMunicipio)
        { 
            InitializeComponent();
            this.municipio = xMunicipio;
            FillData();
        }

        Municipio municipioData;
        public void FillData()
        {
            municipioData = MunicipioManager.BuscarPorId(municipio);
            txtMunicipio.Text = municipioData.sNombre;
            ucFichaMunicipio1.colocarFotografia(municipioData.logotipo);
            txtDescripcion.Text = municipioData.sDescripcion;
        }

        private void frmUpdMunicipio_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtMunicipio.Text != "")

            {
                if (ucFichaMunicipio1.ImagenString != "")
                {
                    municipioData.sNombre = txtMunicipio.Text;
                    municipioData.logotipo = ucFichaMunicipio1.ImagenString;
                    municipioData.sDescripcion = txtDescripcion.Text;
                    MunicipioManager.Guardar(municipioData);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ingresar foto de Municipio, campo obligatorio");
                }
            }
            else
            {
                MessageBox.Show("Ingresar nombre de Municipio, campo obligatoriio");

            }
    }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMunicipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}

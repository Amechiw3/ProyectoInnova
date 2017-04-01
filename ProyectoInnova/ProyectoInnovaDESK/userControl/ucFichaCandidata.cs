using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProyectoInnovaDESK.Models;
using ProyectoInnovaDESK.Tools;
using ProyectoInnovaDESK.Views;
using ProyectoInnovaDESK.Controllers;

namespace ProyectoInnovaDESK.userControl
{
    public partial class ucFichaCandidata : UserControl
    {
        Candidata candidata;
        public ucFichaCandidata(Candidata xcandidata)
        {
            InitializeComponent();
            this.candidata = xcandidata;
            if(!this.candidata.bStatus)
            {
                this.BackColor = Color.Red;
            }
        }

        public int id;
        private void ucFichaCandidata_Load(object sender, EventArgs e)
        {
            pcbFotografia.Image = ImagenTool.Base64StringToBitmap(candidata.fotografia);
            lblNombre.Text = candidata.sNombre + " " + candidata.sApellido;
            lblDescripcion.Text = candidata.sDescripcion;
            this.Name = candidata.pkCandidata.ToString();
            this.id = candidata.pkCandidata;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var update = new Views.frmUpdCandidata(candidata);
            update.ShowDialog();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            CandidataManager.BorrarCandidata(candidata);
        }
    }
}

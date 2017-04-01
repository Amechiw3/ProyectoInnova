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
using ProyectoInnovaDESK.userControl;

namespace ProyectoInnovaDESK.Views
{
    public partial class frmListCandidata : Form
    {
        public frmListCandidata()
        {
            InitializeComponent();
        }

        private void frmListCandidata_Load(object sender, EventArgs e)
        {
            int left = 12;
            int top = 75;
            List<Candidata> candidatas = CandidataManager.ListarContenido();
            foreach (Candidata item in candidatas)
            {
                ucFichaCandidata nControl = new ucFichaCandidata(item);
                nControl.Left = left;
                nControl.Top = top;
                left += nControl.Width + 10;
                if ((left + nControl.Width) > this.Width)
                {
                    top += 12 + nControl.Height;
                    left = 12;
                }
                this.Controls.Add(nControl);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in this.Controls)
            {
                if (item is ucFichaCandidata)
                {
                    ucFichaCandidata ficha = (ucFichaCandidata)item;
                    this.Controls.Remove(ficha);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var vr = new frmAddCandidata();
            vr.ShowDialog();
        }
    }
}

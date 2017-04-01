﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProyectoInnovaDESK.Tools;
using ProyectoInnovaDESK.Controllers;
using ProyectoInnovaDESK.Models;

namespace ProyectoInnovaDESK.Views
{
    public partial class frmSeaCandidata : Form
    {
        public frmSeaCandidata()
        {
            InitializeComponent();
        }

        private void frmSeaCandidata_Load(object sender, EventArgs e)
        {
            this.dgvDatos.AutoGenerateColumns = false;
            this.dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            llenardatos();
        }

        public void llenardatos(string dato = "")
        {
            dgvDatos.DataSource = CandidataManager.ListarContenidoBuscar(dato);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            llenardatos(txtBuscar.Text);
        }

        private void dgvDatos_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = $"Registros: {dgvDatos.RowCount}";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frmAgregarCandidata = new frmAddCandidata();
            frmAgregarCandidata.ShowDialog();
        }

        private void bnEditar_Click(object sender, EventArgs e)
        {
            var update = new Views.frmUpdCandidata(int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString()));
            update.ShowDialog();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Candidata candidata = CandidataManager.getData(int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString()));
            CandidataManager.BorrarCandidata(candidata);
            llenardatos(txtBuscar.Text);
        }
    }
}
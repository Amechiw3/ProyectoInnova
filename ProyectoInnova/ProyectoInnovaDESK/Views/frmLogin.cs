﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProyectoInnovaDESK.Controllers.Helpers;
using ProyectoInnovaDESK.Controllers;
using ProyectoInnovaDESK.Models;

namespace ProyectoInnovaDESK.Views
{
    public partial class frmLogin : Form
    {
        UsuarioHelper uHelper;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtnoempleado.Text != "" && txtPassword.Text != "")
            {
                uHelper = UsuarioManager.Autentificar(int.Parse(txtnoempleado.Text), txtPassword.Text);
                if (uHelper.esValido)
                {
                    frmPrincipal.uHelper = uHelper;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(uHelper.sMensaje, "Autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnoempleado.Text = "";
                    txtnoempleado.Focus();
                }
            }
            else
            {
                MessageBox.Show("Faltan datos para acceder", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmPrincipal.uHelper = null;
            this.Close();
        }

        private void txtnoempleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}

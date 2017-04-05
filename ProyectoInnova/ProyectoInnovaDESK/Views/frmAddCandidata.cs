﻿using System;
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
using System.Text.RegularExpressions;

namespace ProyectoInnovaDESK.Views
{
    public partial class frmAddCandidata : Form
    {
        public frmAddCandidata()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Regex CURP = new Regex(@"^.*(?=.{18})(?=.*[0-9])(?=.*[A-ZÑ]).*$");
            Regex EMAIL = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            if (validarTextbox())
            {
                if (CURP.IsMatch(txtCurp.Text))
                {
                    if (EMAIL.IsMatch(txtCorreo.Text))
                    {
                        if (webCamCandidatas.ImagenString != "")
                        {
                            var candidata = new Candidata();
                            candidata.sNombre = txtNombre.Text;
                            candidata.sApellido = txtApellido.Text;
                            candidata.dfnac = DateTime.Parse(dtpFNac.Value.ToShortDateString());
                            candidata.sCorreo = txtCorreo.Text;
                            candidata.sCurp = txtCurp.Text;
                            candidata.sNivelEstudios = cboNivelEstudios.Text;
                            candidata.sAnioConvocatoria = txtAnioConvocatoria.Text;
                            candidata.fotografia = webCamCandidatas.ImagenString;
                            candidata.usuarios = UsuarioManager.BuscarPorNoEmpleado(frmPrincipal.uHelper.usuario.pkUsuario);
                            candidata.municipio = MunicipioManager.BuscarPorId(int.Parse(cboMunicipo.SelectedValue.ToString()));
                            candidata.sDescripcion = txtDescripcion.Text;

                            var validar = CandidataManager.validarCandidata(candidata);
                            if (validar != null)
                            {
                                MessageBox.Show("Candidata ya registrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                CandidataManager.RegistrarCandidata(candidata);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Se necesita una fotografia para completar el registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            webCamCandidatas.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formato de correo electronico incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCorreo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Formato de curp incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCurp.Focus();
                }
            }
            else
            {
                MessageBox.Show("Faltan datos por llenar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public bool validarTextbox()
        {
            if (txtNombre.Text == "")
            {
                return false;
            }
            if (txtApellido.Text == "")
            {
                return false;
            }
            if (txtAnioConvocatoria.TextLength != 4)
            {
                return false;
            }
            return true;
        }

        public void llenarcombomunicipios()
        {
            cboMunicipo.DisplayMember = "sNombre";
            cboMunicipo.ValueMember = "pkMunicipio";
            cboMunicipo.DataSource = MunicipioManager.ListarContenido();
        }

        private void frmAddCandidata_Load(object sender, EventArgs e)
        {
            llenarcombomunicipios();
        }

        private void txtAnioConvocatoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCurp_Leave(object sender, EventArgs e)
        {
            Regex CURP = new Regex(@"^.*(?=.{18})(?=.*[0-9])(?=.*[A-ZÑ]).*$");
            if (!CURP.IsMatch(txtCurp.Text))
            {
                MessageBox.Show("Formato de curp incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCurp.Focus();
            }
         }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAnioConvocatoria_Leave(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                lista.Add(DateTime.Now.AddYears(i).Year.ToString());
            }
            if(!lista.Contains(txtAnioConvocatoria.Text))
            {
                MessageBox.Show("El año de la convocatoria no es valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAnioConvocatoria.Focus();
            }
        }
    }
}

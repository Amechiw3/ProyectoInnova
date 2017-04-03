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

namespace ProyectoInnovaDESK.Views
{
    public partial class frmUpdUsuario : Form
    {
        Usuario usuario;
        public frmUpdUsuario(int ID)
        {
            InitializeComponent();
            usuario = UsuarioManager.BuscarPorNoEmpleado(ID);
        }

        private void frmUpdUsuario_Load(object sender, EventArgs e)
        {
            txtNombre.Text = usuario.sNombre;
            txtApellido.Text = usuario.sAppellidos;
            txtUsuario.Text = usuario.sUsuario;
            llenarCombo();
        }

        private void llenarCombo()
        {
            cboRol.DataSource = RolManager.ListarContenido();
            cboRol.DisplayMember = "sNombre";
            cboRol.ValueMember = "pkRol";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtApellido.Text != "" && txtUsuario.Text != "")
            {
                usuario.sNombre = txtNombre.Text;
                usuario.sAppellidos = txtApellido.Text;
                usuario.sUsuario = txtUsuario.Text;
                if(txtPassword.Text != "")
                {
                    usuario.sPassword = Tools.LoginTool.GetMD5(txtPassword.Text);
                }

                Rol Rol = RolManager.getDATA(int.Parse(cboRol.SelectedValue.ToString()));
                if (Rol.sNombre == "Administrador" && frmPrincipal.uHelper.usuario.rol.sNombre == "Administrador")
                {
                    MessageBox.Show("No tiene permiso para agregar\r\nun usuario con ese nivel de acceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    usuario.rol = Rol;
                    UsuarioManager.RegistrarNuevoUsuario(usuario, Rol);
                    this.Close();
                }
            }
        }
    }
}

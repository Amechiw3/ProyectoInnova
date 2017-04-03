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
using ProyectoInnovaDESK.Controllers;
using ProyectoInnovaDESK.Models;

namespace ProyectoInnovaDESK.Views
{
    public partial class frmSeaUsuario : Form
    {
        public frmSeaUsuario()
        {
            InitializeComponent();
        }

        private void frmSeaUsuario_Load(object sender, EventArgs e)
        {
            this.dgvDatos.AutoGenerateColumns = false;
            this.dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            llenardatos();
        }

        public void llenardatos(string dato = "")
        {
            dgvDatos.DataSource = UsuarioManager.ListarContenidoBuscar(dato);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var agregarUsuarios = new frmAddUsuario();
            agregarUsuarios.ShowDialog();
            llenardatos();
        }

        private void bnEditar_Click(object sender, EventArgs e)
        {
            var update = new Views.frmUpdUsuario(int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString()));
            update.ShowDialog();
            llenardatos();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = UsuarioManager.BuscarPorNoEmpleado(int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString()));
            UsuarioManager.BorrarUsuario(usuario);
            llenardatos();
        }
    }
}

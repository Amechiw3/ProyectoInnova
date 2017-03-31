using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoInnovaDESK.Models;

namespace ProyectoInnovaDESK.Controllers.Helpers
{
    public class UsuarioHelper
    {
        public Usuario usuario { get; set; }
        public Boolean esValido { get; set; }
        public String sMensaje { get; set; }

        public Boolean TienePermiso(int idPermiso)
        {
            Boolean tiene = true;
            foreach (PermisoNegado item in usuario.rol.PermisosNegados)
            {
                if (item.permiso.pkPermiso == idPermiso)
                {
                    tiene = false;
                    break;
                }
            }
            return tiene;
        }
        public UsuarioHelper()
        {
            this.usuario = null;
            this.esValido = false;
            this.sMensaje = "Datos incorrectos";
        }
    }
}

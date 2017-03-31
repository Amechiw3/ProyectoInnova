using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoInnovaDESK.Tools;
using ProyectoInnovaDESK.Models;
using ProyectoInnovaDESK.Controllers.Helpers;

namespace ProyectoInnovaDESK.Controllers
{
    public class UsuarioManager
    {
        public static UsuarioHelper Autentificar(String sUsuario, String sPassword)
        {
            UsuarioHelper uHelper = new UsuarioHelper();
            Usuario user = BuscarPorEmail(sUsuario);
            if (user != null)
            {
                if (user.sPassword == LoginTool.GetMD5(sPassword))
                {
                    uHelper.usuario = user;
                    uHelper.esValido = true;
                    Acceso nAcceso = new Acceso();
                    nAcceso.usuario = user;
                    AccesoManager.RegistrarAcceso(nAcceso);
                }
                else
                {
                    uHelper.sMensaje = "Datos Incorrectos";
                }
            }
            return uHelper;
        }

        private static Usuario BuscarPorEmail(string Email)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios.Include("rol")
                        .Include("rol.PermisosNegados")
                        .Include("rol.PermisosNegados.permiso")
                        .Where(r => r.sUsuario == Email).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void RegistrarNuevoUsuario(Usuario nUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Usuarios.Add(nUsuario);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

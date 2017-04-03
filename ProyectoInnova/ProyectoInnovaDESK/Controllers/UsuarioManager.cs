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
        public static UsuarioHelper Autentificar(int noEmpleado, String sPassword)
        {
            UsuarioHelper uHelper = new UsuarioHelper();
            Usuario user = BuscarPorNoEmpleado(noEmpleado);
            if (user != null)
            {
                if (user.sPassword == LoginTool.GetMD5(sPassword))
                {
                    uHelper.usuario = user;
                    uHelper.esValido = true;
                    Acceso nAcceso = new Acceso();
                    nAcceso.usuario = user;
                    //AccesoManager.RegistrarAcceso(nAcceso, user);
                }
                else
                {
                    uHelper.sMensaje = "Datos Incorrectos";
                }
            }
            return uHelper;
        }

        public static Usuario BuscarPorNoEmpleado(int noEmpleado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios.Include("rol")
                        .Include("rol.PermisosNegados")
                        .Include("rol.PermisosNegados.permiso")
                        .Where(r => r.pkUsuario == noEmpleado).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void RegistrarNuevoUsuario(Usuario nUsuario, Rol rol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    if(nUsuario.pkUsuario > 0)
                    {
                        ctx.Entry(nUsuario).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(nUsuario).State = System.Data.Entity.EntityState.Added;
                        ctx.Roles.Attach(rol);
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Usuario> ListarContenido(string dato = "")
        {
            try
            {
                var ctx = new DataModel();
                return ctx.Usuarios.Where(r => r.sNombre.Contains(dato) && r.bStatus == true).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int    pkUsuario { get; set; }
        public string sNombre   { get; set; }
        public string sUsuario  { get; set; }
        public string sRol      { get; set; }

        public static List<UsuarioManager> ListarContenidoBuscar(string dato = "")
        {
            try
            {
                var ctx = new DataModel();
                var lista = ctx.Usuarios.Include("rol")
                        .Include("rol.PermisosNegados")
                        .Include("rol.PermisosNegados.permiso")
                        .Where(r => r.sNombre.Contains(dato) && r.bStatus == true).ToList();

                return (from r in lista
                        select new UsuarioManager
                        {
                            pkUsuario = r.pkUsuario,
                            sNombre = $"{r.sNombre} {r.sAppellidos}",
                            sUsuario = r.sUsuario,
                            sRol = r.rol.sNombre
                        }).ToList();

                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void BorrarUsuario(Usuario nUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nUsuario.bStatus = false;
                    ctx.Entry(nUsuario).State = System.Data.Entity.EntityState.Modified;

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

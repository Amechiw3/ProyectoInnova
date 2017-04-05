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
        /// <summary>
        /// Esta funcion esta encargada de realizar la validacion de el login
        /// </summary>
        /// <param name="noEmpleado">llave primaria de el usuario</param>
        /// <param name="sPassword">Contraseña del usuario</param>
        /// <returns></returns>
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

        /// <summary>
        /// Esta funcion nos regresa un usuario buscando por su numero de empleado (llave primaria)
        /// </summary>
        /// <param name="noEmpleado">Llave primaria</param>
        /// <returns></returns>
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

        /// <summary>
        /// Esta funcion esta encargada de registrar a nuevos usuarios o actualizar la informacion de los existentes
        /// </summary>
        /// <param name="nUsuario">Objeto de usuario</param>
        /// <param name="rol">Objeto de rol</param>
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

        /// <summary>
        /// Esta funcion nos regresa una lista de todos los usuarios activos, tambien funciona
        /// como buscador del usuario por el nombre del mismo, sirva para llenar un combobox
        /// </summary>
        /// <param name="dato">Nombre a buscar</param>
        /// <returns></returns>
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

        /// <summary>
        /// Esta funcion nos regresa una lista de todos los usuarios activos, tambien funciona
        /// como buscador del usuario por el nombre del mismo
        /// </summary>
        /// <param name="dato">Nombre a buscar</param>
        /// <returns></returns>
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

        /// <summary>
        /// Esta funcion esta encargada de borrar a un usuario
        /// </summary>
        /// <param name="nUsuario">Objeto de usuario</param>
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

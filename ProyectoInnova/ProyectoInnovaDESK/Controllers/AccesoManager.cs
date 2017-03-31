using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoInnovaDESK.Models;

namespace ProyectoInnovaDESK.Controllers
{
    public class AccesoManager
    {
        /// <summary>
        /// Funcion encargada de registrar el acceso de un usuario al sistema
        /// </summary>
        /// <param name="acceso">Recibe los datos de acceso</param>
        public static void RegistrarAcceso(Acceso acceso)
        {
            try
            {
                var ctx = new DataModel();
                ctx.Accesos.Add(acceso);
                ctx.Usuarios.Attach(acceso.usuario);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

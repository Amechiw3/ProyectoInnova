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
    public class RolManager
    {
        public static List<Rol> ListarContenido()
        {
            try
            {
                var ctx = new DataModel();
                return ctx.Roles.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Rol getDATA( int ID )
        {
            try
            {
                var ctx = new DataModel();
                return ctx.Roles.Where(r => r.pkRol == ID).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

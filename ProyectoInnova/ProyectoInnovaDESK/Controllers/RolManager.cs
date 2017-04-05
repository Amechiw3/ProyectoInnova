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
        /// <summary>
        /// Esta funcion nos regresa  una lista de los roles disponibles
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Esta funcion nos regresa un objeto del tipo rol mediante la llave primaria
        /// </summary>
        /// <param name="ID">llave primaria</param>
        /// <returns></returns>
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

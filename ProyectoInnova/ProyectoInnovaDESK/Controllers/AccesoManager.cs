using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using ProyectoInnovaDESK.Models;

namespace ProyectoInnovaDESK.Controllers
{
    public class AccesoManager
    {
        /// <summary>
        /// Funcion encargada de registrar el acceso de un usuario al sistema
        /// </summary>
        /// <param name="acceso">Recibe los datos de acceso</param>
        public static void RegistrarAcceso(Acceso acceso, Usuario usuario)
        {
            try
            {
                var ctx = new DataModel();
                ctx.Entry(acceso).State = System.Data.Entity.EntityState.Added;

                ctx.Usuarios.Attach(usuario);

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\r\n"+ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

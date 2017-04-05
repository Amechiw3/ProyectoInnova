using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoInnovaDESK.Models;

namespace ProyectoInnovaDESK.Controllers
{
    public class MunicipioManager
    {
        public static List<Municipio> ListarContenido()
        {
            try
            {
                var ctx = new DataModel();
                return ctx.Municipios.Where(r => r.bStatus == true).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Municipio BuscarPorId(int ID)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Municipios.Where(r => r.pkMunicipio == ID).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

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
        public static void Guardar(Municipio muni)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    if (muni.pkMunicipio > 0)
                    {
                        ctx.Entry(muni).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(muni).State = System.Data.Entity.EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
                }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Municipio> BuscarMunicipio( string valor)
        {
            try
            {
                var ctx = new DataModel();
                return ctx.Municipios.Where(r => r.sNombre.Contains(valor) && r.bStatus == true).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void Borrar(Municipio muni)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    muni.bStatus = false;
                     ctx.Entry(muni).State = System.Data.Entity.EntityState.Modified;
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

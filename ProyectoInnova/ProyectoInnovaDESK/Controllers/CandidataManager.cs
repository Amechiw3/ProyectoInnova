using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoInnovaDESK.Models;

namespace ProyectoInnovaDESK.Controllers
{
    class CandidataManager
    {
        public static List<Candidata> ListarContenido(string dato = "")
        {
            try
            {
                var ctx = new DataModel();
                return ctx.Candidatas.Where(r => r.sNombre.Contains(dato) && r.bStatus == true).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Candidata getData(Candidata candidata)
        {
            try
            {
                var ctx = new DataModel();
                return ctx.Candidatas.Include("municipio").Include("usuarios")
                    .Where(r => r.pkCandidata == candidata.pkCandidata && r.bStatus == true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void RegistrarCandidata(Candidata candidata)
        {
            try
            {
                var ctx = new DataModel();
                if (candidata.pkCandidata > 0)
                {
                    ctx.Entry(candidata).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    Usuario usuario = ctx.Usuarios.Where(r => r.pkUsuario == candidata.usuarios.pkUsuario).FirstOrDefault();
                    Municipio municipo = ctx.Municipios.Where(r => r.pkMunicipio == candidata.municipio.pkMunicipio).FirstOrDefault();

                    ctx.Usuarios.Attach(usuario);
                    ctx.Municipios.Attach(municipo);

                    ctx.Entry(candidata).State = System.Data.Entity.EntityState.Added;
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void BorrarCandidata(Candidata candidata)
        {
            try
            {
                var ctx = new DataModel();
                candidata.bStatus = false;
                ctx.Entry(candidata).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

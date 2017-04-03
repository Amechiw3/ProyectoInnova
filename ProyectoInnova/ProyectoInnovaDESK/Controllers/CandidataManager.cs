using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoInnovaDESK.Models;
using System.Drawing.Imaging;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;
using ProyectoInnovaDESK.Tools;


namespace ProyectoInnovaDESK.Controllers
{
    class CandidataManager
    {
        public int pkCandidata { get; set; }
        public Bitmap Fotografia { get; set; }
        public String sNombre { get; set; }
        public String sApellido { get; set; }
        public String sAnios { get; set; }
        public String sDescripcion { get; set; }
        public String sNivelEstudios { get; set; }

        public int Votos { get; set; }

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

        public static List<CandidataManager> ListarContenidoBuscar(string dato = "")
        {
            try
            {
                var ctx = new DataModel();
                return (from r in ctx.Candidatas.Where(r => r.sNombre.Contains(dato) && r.bStatus == true).ToList()
                        select new CandidataManager
                        {
                            pkCandidata = r.pkCandidata,
                            sNombre = $"{r.sNombre} {r.sApellido}",
                            Fotografia = ImagenTool.Base64StringToBitmap(r.fotografia),
                            sDescripcion = r.sDescripcion,
                            sNivelEstudios = r.sNivelEstudios,
                            sAnios = (DateTime.Now.Year - r.dfnac.Year).ToString()
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Candidata getData(int candidata)
        {
            try
            {
                var ctx = new DataModel();
                return ctx.Candidatas.Include("municipio").Include("usuarios")
                    .Where(r => r.pkCandidata == candidata && r.bStatus == true).FirstOrDefault();
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

        /// <summary>
        /// Esta funcion valida los datos de una candidata para verificar si no se ingreso recientemente
        /// </summary>
        /// <param name="candidata">Datos de candidata</param>
        /// <returns>Regresa una candidata</returns>
        public static Candidata validarCandidata(Candidata candidata)
        {
            try
            {
                var ctx = new DataModel();
                return ctx.Candidatas.Include("municipio").Include("usuarios")
                    .Where( r => r.sAnioConvocatoria == candidata.sAnioConvocatoria && 
                            r.sCurp == candidata.sCurp && 
                            r.municipio.pkMunicipio == candidata.municipio.pkMunicipio).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

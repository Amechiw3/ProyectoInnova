using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoInnovaWEB.Models;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ProyectoInnovaWEB.Models.Manager
{
    public class CandidataManager
    {
        public int pkCandidata { get; set; }
        public String Fotografia { get; set; }
        public String sNombre { get; set; }
        public String sAnios { get; set; }
        public String sDescripcion { get; set; }
        public String sNivelEstudios { get; set; }
        public String municipio { get; set; }
        public int votos { get; set; }

        /// <summary>
        /// Esta funcion regresa la lista de candidatas
        /// </summary>
        /// <returns></returns>
        public static List<Candidata> GetAll()
        {
            try
            {
                var ctx = new DataModel();
                return ctx.Candidatas.Where(r => r.bStatus == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Candidata getData(int ID)
        {
            try
            {
                var ctx = new DataModel();
                return ctx.Candidatas.Where(r => r.pkCandidata == ID && r.bStatus == true).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<string> getAniosConvocatoria()
        {
            List<string> departamentos = new List<string>();
            try
            {
                var ctx = new DataModel();
                var listacandidatas = ctx.Candidatas.GroupBy(r => r.sAnioConvocatoria).ToList();
                foreach (var item in listacandidatas)
                {
                    departamentos.Add(item.Key.ToUpper());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return departamentos;

        }

        public static List<CandidataManager> ListarContenidoBuscar(string fecha = "", string nbCant = "", string nbCiu = "")
        {
            try
            {
                if (fecha == "")
                {
                    fecha = DateTime.Now.Year.ToString();
                }
                var ctx = new DataModel();
                return (from r in ctx.Candidatas.Include("municipio").Where(r => r.municipio.sNombre.Contains(nbCiu) && r.sAnioConvocatoria.Contains(fecha) && r.sNombre.Contains(nbCant) && r.bStatus == true).ToList()
                        select new CandidataManager
                        {
                            pkCandidata = r.pkCandidata,
                            sNombre = $"{r.sNombre} {r.sApellido}",
                            Fotografia = r.fotografia,
                            sDescripcion = r.sDescripcion,
                            sNivelEstudios = r.sNivelEstudios,
                            sAnios = (DateTime.Now.Year - r.dfnac.Year).ToString(),
                            municipio = r.municipio.sNombre,
                            votos = RankingManager.contarVotos(r.pkCandidata)
                        }).OrderByDescending(c => c.votos).ToList();
                        
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Municipio> ListarContenidoMunicipios()
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
    }
}

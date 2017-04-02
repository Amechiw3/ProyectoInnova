using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoInnovaWEB.Models;
using System.Drawing;
using System.IO;

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

        public int votos { get; set; }

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

        public static List<CandidataManager> ListarContenidoBuscar()
        {
            try
            {
                var ctx = new DataModel();
                return (from r in ctx.Candidatas.Where(r => r.bStatus == true).ToList()
                        select new CandidataManager
                        {
                            pkCandidata = r.pkCandidata,
                            sNombre = $"{r.sNombre} {r.sApellido}",
                            Fotografia = r.fotografia,
                            sDescripcion = r.sDescripcion,
                            sNivelEstudios = r.sNivelEstudios,
                            sAnios = (DateTime.Now.Year - r.dfnac.Year).ToString(),
                            votos = RankingManager.contarVotos(r.pkCandidata)
                        }).OrderByDescending(c => c.votos).ToList();
                        
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

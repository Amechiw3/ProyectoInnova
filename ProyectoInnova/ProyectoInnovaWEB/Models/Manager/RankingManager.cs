using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoInnovaWEB.Models.Manager
{
    public class RankingManager
    {
        /// <summary>
        /// Esta funcion esta encargada de registrar el voto
        /// por una candidata
        /// </summary>
        /// <param name="pkCandidata">pkCandidata</param>
        public static void votar(int pkCandidata)
        {
            try
            {
                var ctx = new DataModel();
                var candidata = CandidataManager.getData(pkCandidata);
                var ranking = new ranking();
                ranking.candidata = candidata;
                ctx.Entry(ranking).State = System.Data.Entity.EntityState.Added;
                ctx.Candidatas.Attach(candidata);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Esta funcion esta encargada de contar los votos que se han realizado
        /// por una candidadta
        /// </summary>
        /// <param name="ID">pkCandididata</param>
        /// <param name="voto">Votos realizados</param>
        /// <returns>Regresa un numero de votos</returns>
        public static int contarVotos(int ID, int voto = 0)
        {
            try
            {
                var ctx = new DataModel();
                var listaCandidatas = CandidataManager.getData(ID);
                var listaVotos = ctx.Rankings.Where(r => r.candidata.pkCandidata == listaCandidatas.pkCandidata).ToList();
                voto = listaVotos.Count();
                return voto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

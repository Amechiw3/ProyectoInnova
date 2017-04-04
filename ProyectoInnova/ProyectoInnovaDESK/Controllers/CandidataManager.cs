﻿using System;
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
        public String sAniosConvocatoria { get; set; }
        public String municipio { get; set; }
        public String sCorreo { get; set; }
        public String usuario { get; set; }

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

        /// <summary>
        /// Esta funcion regresa una lista de candidatas por municipo
        /// </summary>
        /// <param name="pkMunicipo">Llave primaria de municipio</param>
        /// <returns></returns>
        public static  List<CandidataManager> reporteCandidataMunicipio(int pkMunicipo)
        {
            try
            {
                var ctx = new DataModel();
                return (from r in ctx.Candidatas.Include("municipio").Include("usuarios").Where(r => r.municipio.pkMunicipio == pkMunicipo).ToList()
                        select new CandidataManager
                        {
                            pkCandidata =r.pkCandidata,
                            sNombre = $"{r.sNombre} {r.sApellido}",
                            sCorreo = r.sCorreo,
                            sAniosConvocatoria = r.sAnioConvocatoria,
                            municipio = r.municipio.sNombre
                        }).ToList();
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

        public static List<CandidataManager> reporteCandidataAnioConvocatoria(string AnioConvocatoria)
        {
            try
            {
                var ctx = new DataModel();
                return (from r in ctx.Candidatas.Include("municipio").Include("usuarios").Where(r => r.sAnioConvocatoria == AnioConvocatoria).ToList()
                select new CandidataManager
                        {
                            pkCandidata = r.pkCandidata,
                            sNombre = $"{r.sNombre} {r.sApellido}",
                            sCorreo = r.sCorreo,
                            sAniosConvocatoria = r.sAnioConvocatoria,
                            municipio = r.municipio.sNombre
                        }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<CandidataManager> reporteCandidataUsuario(int pkUsuario)
        {
            try
            {
                var ctx = new DataModel();
                return (from r in ctx.Candidatas.Include("municipio").Include("usuarios").Where(r => r.usuarios.pkUsuario == pkUsuario).ToList()
                        select new CandidataManager
                        {
                            pkCandidata = r.pkCandidata,
                            sNombre = $"{r.sNombre} {r.sApellido}",
                            sCorreo = r.sCorreo,
                            sAniosConvocatoria = r.sAnioConvocatoria,
                            municipio = r.municipio.sNombre,
                            usuario = $"{r.usuarios.sNombre} {r.usuarios.sAppellidos}"
                        }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<CandidataManager> ListarCandidatasPopulares3()
        {
            try
            {
                var ctx = new DataModel();
                List<CandidataManager> listacompleta = new List<CandidataManager>();
                foreach (var item in ctx.Municipios.Where(r => r.bStatus == true).ToList())
                {
                    listacompleta.AddRange((from r in ctx.Candidatas.Where(r => r.municipio.pkMunicipio == item.pkMunicipio && r.bStatus == true).ToList()
                                            select new CandidataManager
                                            {
                                                pkCandidata = r.pkCandidata,
                                                sNombre = $"{r.sNombre} {r.sApellido}",
                                                Fotografia = ImagenTool.Base64StringToBitmap(r.fotografia),
                                                sDescripcion = r.sDescripcion,
                                                sCorreo = r.sCorreo,
                                                sNivelEstudios = r.sNivelEstudios,
                                                sAnios = (DateTime.Now.Year - r.dfnac.Year).ToString(),
                                                municipio = item.sNombre,
                                                Votos = contarVotos(r.pkCandidata)
                                            }).OrderByDescending(c => c.Votos).Take(3).ToList());
                }

                return listacompleta;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<CandidataManager> ListarCandidatasPopularesMunicipio()
        {
            try
            {
                var ctx = new DataModel();
                List<CandidataManager> listacompleta = new List<CandidataManager>();
                foreach (var item in ctx.Municipios.Where(r => r.bStatus == true).ToList())
                {
                    listacompleta.AddRange((from r in ctx.Candidatas.Where(r => r.municipio.pkMunicipio == item.pkMunicipio && r.bStatus == true).ToList()
                                            select new CandidataManager
                                            {
                                                pkCandidata = r.pkCandidata,
                                                sNombre = $"{r.sNombre} {r.sApellido}",
                                                Fotografia = ImagenTool.Base64StringToBitmap(r.fotografia),
                                                sDescripcion = r.sDescripcion,
                                                sCorreo = r.sCorreo,
                                                sNivelEstudios = r.sNivelEstudios,
                                                sAnios = (DateTime.Now.Year - r.dfnac.Year).ToString(),
                                                municipio = item.sNombre,
                                                Votos = contarVotos(r.pkCandidata)
                                            }).OrderByDescending(c => c.Votos).Take(1).ToList());
                }

                return listacompleta;

            }
            catch (Exception ex)
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

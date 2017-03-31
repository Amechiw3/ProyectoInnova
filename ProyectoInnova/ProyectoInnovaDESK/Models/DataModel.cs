using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ProyectoInnovaDESK.Models
{
    public class DataModel : DbContext
    {
        /// <summary>
        /// Contructor de la clase DataModel ese envia la conexion a la clase heredada
        /// </summary>
        public DataModel() : base("DataModel") {   }

        public DbSet<ranking> Rankings { get; set; }
        public DbSet<Candidata> Candidatas { get; set; }
        public DbSet<Municipio> Municipios { get; set; }

        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PermisoNegado> PermisosNegados { get; set; }
        public DbSet<Acceso> Accesos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

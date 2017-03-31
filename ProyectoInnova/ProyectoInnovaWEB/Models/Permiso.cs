using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoInnovaWEB.Models
{
    [Table("Permisos")]
    public class Permiso
    {
        [Key]
        public int pkPermiso { get; set; }
        public String sNombre { get; set; }
        public String sDescripcion { get; set; }

        public ICollection<PermisoNegado> PermisosNegados { get; set; }
    }
}

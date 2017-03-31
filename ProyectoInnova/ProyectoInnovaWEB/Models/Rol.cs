using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoInnovaWEB.Models
{
    [Table("Roles")]
    public class Rol
    {
        [Key]
        public int pkRol { get; set; }
        public String sNombre { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<PermisoNegado> PermisosNegados { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoInnovaWEB.Models
{
    [Table("Accesos")]
    public class Acceso
    {
        [Key]
        public int pkAcceso { get; set; }
        public DateTime dFecha { get; set; }

        public virtual Usuario usuario { get; set; }

        public Acceso()
        {
            dFecha = System.DateTime.Now;
        }
    }
}

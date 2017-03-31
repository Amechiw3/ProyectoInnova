using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoInnovaWEB.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int pkUsuario { get; set; }
        public String sUsuario { get; set; }
        public String sPassword { get; set; }
        public String sNombre { get; set; }
        public String sAppellidos { get; set; }
        public Boolean bStatus { get; set; }

        public virtual Rol rol { get; set; }
        public ICollection<Acceso> Accesos { get; set; }

        /// <summary>
        /// POR DEFATUL LA CLAVE PARA TODOS LOS USUARIOS ES 123123
        /// </summary>
        public Usuario()
        {
            this.bStatus = true;
            this.sPassword = "4297f44b13955235245b2497399d7a93";
        }

    }
}

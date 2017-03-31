using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoInnovaDESK.Models
{
    [Table("Municipios")]
    public class Municipio
    {
        [Key]
        public int pkMunicipio { get; set; }

        [Required(ErrorMessage = "Se requiere el nombre del municipo")]
        public String sNombre { get; set; }

        [Required(ErrorMessage = "Se requiere una fotografia de la candidata")]
        public String logotipo { get; set; }

        public String sDescripcion { get; set; }

        public Boolean bStatus { get; set; }

        //  Relaciones \\
        public ICollection<Candidata> Candidatas { get; set; }

        public Municipio()
        {
            this.bStatus = true;
        }
    }
}

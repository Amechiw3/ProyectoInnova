using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoInnovaDESK.Models
{
    [Table("Candidatas")]
    public class Candidata
    {
        [Key]
        public int pkCandidata { get; set; }

        [Required(ErrorMessage = "Se requiere el nombre de la candidata")]
        public String sNombre { get; set; }

        [Required(ErrorMessage = "Se requiere el apellido de la candidata")]
        public String sApellido { get; set; }

        [Required(ErrorMessage = "Se requiere la fecha de nacimiento de la candidata")]
        public DateTime dfnac { get; set; }

        [Required(ErrorMessage = "Se requiere el correo de la candidata")]
        public String sCorreo { get; set; }

        [Required(ErrorMessage = "Se requiere el curp de la candidata")]
        public String sCurp { get; set; }

        [Required(ErrorMessage = "Se requiere el nivel de estudio de la candidata")]
        public String sNivelEstudios { get; set; }

        [Required(ErrorMessage = "Se requiere una fotografia de la candidata")]
        public String fotografia { get; set; }

        [Required(ErrorMessage = "Se requiere el año de convocatoria de la candidata")]
        public String sAnioConvocatoria { get; set; }

        public String sDescripcion { get; set; }

        public Boolean bStatus { get; set; }

        //  Relaciones  \\
        public ICollection<ranking> rankings { get; set; }

        public Usuario usuarios { get; set; }

        public Municipio municipio { get; set; }

        public Candidata()
        {
            this.bStatus = true;
        }

    }
}

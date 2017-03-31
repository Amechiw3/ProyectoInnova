using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoInnovaWEB.Models
{
    [Table("Ranking")]
    public class ranking
    {
        [Key]
        public int pkRanking { get; set; }

        public Candidata candidata { get; set; }
    }
}

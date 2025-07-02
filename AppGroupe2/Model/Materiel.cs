using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGroupe2.Model;

namespace AppGroupe2.Model
{
    public class Materiel
    {
        [Key]
        public int idMateriel { get; set; }
        [Required, MaxLength(160)]
        public string Designation { get; set; }
        public DateTime? dateAquisition { get; set; }
        [Required]
        public float? Poids { get; set; }

        public decimal PU { get; set; }
        public int? IdRayon { get; set; }
        [ForeignKey("IdRayon")]
        public virtual Rayon Rayon { get; set; }
    }
}
   
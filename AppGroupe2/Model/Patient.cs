using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGroupe2.Model
{
    /// <summary>
    /// ***********************************************************************
    /// La classe patient eprésente un patient dans le système médical.
    /// </summary>
    public class Patient : Personne
    {

        [Key]
        public string IdPatient { get; set; }

        public int? IdGroupeSanguin { get; set; }
        [ForeignKey("IdGroupeSanguin")]
        public virtual GroupeSanguin GroupeSanguin { get; set; }
        [Required]
        public float? Poids { get; set; }
        [Required]
        public float? Taille { get; set; }

        public DateTime? DateNaissance { get; set; }
        public virtual ICollection<RendezVous> rendezVous { get; set; }

    }
}
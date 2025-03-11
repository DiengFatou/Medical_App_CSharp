using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGroupe2.Model
{
    /// <summary>
    /// ***********************************************************************
    /// La classe medecin eprésente un médecin dans le système médical.
   
    /// </summary>
    public class Medecin: Utilisateur
    {
        [Key]
        public string IdMedecin { get; set; }
    
        public int? IdSpecialite { get; set; }
        [ForeignKey("IdSpecialite")]
        public virtual Specialite Specialite {  get; set; }

        [MaxLength(10)]
        public string NumeroOrdre { get; set; }
       
        public virtual ICollection<Agenda> agenda { get; set; }
        public virtual ICollection<RendezVous> rendezVous { get; set; }

    }
}

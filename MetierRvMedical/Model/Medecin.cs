using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MaterielRvMedical.Model
{
    /// <summary>
    /// ***********************************************************************
    /// La classe medecin eprésente un médecin dans le système médical.

    /// </summary>
    [DataContract]
    public class Medecin : Utilisateur
    {
        [Key, DataMember]
        public string IdMedecin { get; set; }
        [DataMember]
        public int? IdSpecialite { get; set; }

        [ForeignKey("IdSpecialite"), DataMember]
        public virtual Specialite Specialite { get; set; }
        [MaxLength(10), DataMember]
        public string NumeroOrdre { get; set; }
        [DataMember]
        public virtual ICollection<Agenda> agenda { get; set; }
        [DataMember]
        public virtual ICollection<RendezVous> rendezVous { get; set; }
    
}
}

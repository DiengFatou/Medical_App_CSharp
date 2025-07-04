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
    /// La classe Agenda est responsable de la gestion des rendez-vous médicaux.
    /// </summary>
    [DataContract]
    public class Agenda
    {
        [Key, DataMember]
        public int IdAgenda { get; set; }
        [DataMember]
        public DateTime? DatePlanifier { get; set; }
        [DataMember]
        public string Titre { get; set; }
        [DataMember]
        public string Lieu { get; set; }
        [DataMember]
        public string HeureDebut { get; set; }
        [DataMember]
        public string HeureFin { get; set; }
        [DataMember]
        public int Creneau { get; set; }
        [DataMember]
        public string Statut { get; set; }

        [DataMember]
        public int IdMedecin { get; set; }
        [ForeignKey("IdMedecin"), DataMember]
        public Medecin Medecin { get; set; }
        [DataMember]
        public virtual ICollection<RendezVous> RendezVous { get; set; }
    }
}

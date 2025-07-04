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
    /// La classe représente un rendez-vous médical dans le système.
    /// </summary>
    [DataContract]
    public class RendezVous
    {
        [Key]
        [DataMember]
        public int IdRv { get; set; }

        [Required]
        [DataMember]
        public DateTime DateRv { get; set; }

        [MaxLength(10)]
        [DataMember]
        public string Statut { get; set; }

        [DataMember]
        public int? IdSoin { get; set; }

        [ForeignKey("IdSoin")]
        [DataMember]
        public virtual Soin Soin { get; set; }

        [DataMember]
        public int? IdCreneau { get; set; }

        [ForeignKey("IdCreneau")]
        [DataMember]
        public virtual Creneau Creneau { get; set; }

        [DataMember]
        public int? IdPatient { get; set; }

        [ForeignKey("IdPatient")]
        [DataMember]
        public virtual Patient Patient { get; set; }

        [DataMember]
        public int? IdMedecin { get; set; }

        [ForeignKey("IdMedecin")]
        [DataMember]
        public virtual Medecin Medecin { get; set; }

        [DataMember]
        public decimal Cout { get; set; }

        [DataMember]
        public string ModePaiement { get; set; }

        [DataMember]
        public string ReferencePaiement { get; set; }

        [DataMember]
        public string Horaire { get; set; }

        [DataMember]
        public string NumeroRecu { get; set; }
    }
}

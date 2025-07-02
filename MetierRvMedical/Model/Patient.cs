using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MaterielRvMedical.Model
{
    /// <summary>
    /// ***********************************************************************
    /// La classe patient eprésente un patient dans le système médical.
    /// </summary>
   
        [DataContract]
        public class Patient : Personne
        {
            [Key, DataMember]
            public string IdPatient { get; set; }
            [DataMember]
            public int? IdGroupeSanguin { get; set; }

            [ForeignKey("IdGroupeSanguin"), DataMember]
            public virtual GroupeSanguin GroupeSanguin { get; set; }
            [Required, DataMember]
            public float? Poids { get; set; }
            [Required, DataMember]
            public float? Taille { get; set; }
            [DataMember]
            public DateTime? DateNaissance { get; set; }
            [DataMember]
            public virtual ICollection<RendezVous> rendezVous { get; set; }
        }
    }
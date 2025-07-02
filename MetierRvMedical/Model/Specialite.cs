using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MaterielRvMedical.Model
{
    /// <summary>
    /// ***********************************************************************
    /// Représente un spécialiste dans le domaine médical.
    /// </summary>

    [DataContract]
    public class Specialite
    {
        [Key]
        [DataMember]
        public int IdSpecialite { get; set; }

        [Required, MaxLength(10)]
        [DataMember]
        public string CodeSpecialite { get; set; }

        [Required, MaxLength(100)]
        [DataMember]
        public string NomSpecialite { get; set; }
    }
}

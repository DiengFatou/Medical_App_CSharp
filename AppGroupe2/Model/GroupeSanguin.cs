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
    /// Représente un groupe sanguin pour un patient.
    /// /// </summary>
    [DataContract]
    public class GroupeSanguin
    {
        [Key]
        [DataMember]
        public int IdGroupeSanguin { get; set; }

        [Required, MaxLength(3)]
        [DataMember]
        public string CodeGroupeSanguin { get; set; }
    }
}

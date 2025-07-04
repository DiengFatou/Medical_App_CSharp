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
    /// La classe soin eprésente un soin médical donné lors d'un rendez-vous.
    /// </summary>
    [DataContract]
    public class Soin
    {
        [Key]
        [DataMember]
        public int IdSoin { get; set; }

        [Required]
        [DataMember]
        public string Libelle { get; set; }
    }
}

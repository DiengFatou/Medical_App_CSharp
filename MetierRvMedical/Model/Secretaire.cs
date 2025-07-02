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
    /// Représente une secrétaire dans le système.
    /// La secrétaire gère les rendez-vous, les informations des patients, etc.
    /// </summary>
    [DataContract]
    public class Secretaire : Utilisateur
    {
        [Key, DataMember]
        public int IdSecretaire { get; set; }
        [MaxLength(15), DataMember]
        public string TelephoneFixe { get; set; }
    }

}

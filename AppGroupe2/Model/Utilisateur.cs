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
    [DataContract]
    public class Utilisateur : Personne
    {
        [Key, DataMember]
        public int IdUtilisateur { get; set; }
        [Required, MaxLength(20), DataMember]
        public string Identifiant { get; set; }
        [Required, MaxLength(250), DataMember]
        public string MotDePasse { get; set; }
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public int? IdRole { get; set; }

        [ForeignKey("IdRole"), DataMember]
        public virtual Role Role { get; set; }
    }

}

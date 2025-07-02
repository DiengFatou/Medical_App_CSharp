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
    [DataContract]
    public class Personne
    {
        [Key, DataMember]
        public int IDU { get; set; }
        [Required, MaxLength(160), DataMember]
        public string NomPrenom { get; set; }
        [Required, MaxLength(200), DataMember]
        public string Adresse { get; set; }
        [Required, MaxLength(80), DataType(DataType.EmailAddress), DataMember]
        public string Email { get; set; }
        [Required, MaxLength(20), DataMember]
        public string Tel { get; set; }
    }
}

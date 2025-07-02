using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MaterielRvMedical.Model
{
    [DataContract]
    public class Role
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [MaxLength(10)]
        [DataMember]
        public string Code { get; set; }

        [MaxLength(30)]
        [DataMember]
        public string Libelle { get; set; }
    }

}

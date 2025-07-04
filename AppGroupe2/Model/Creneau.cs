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
    public class Creneau
    {
        [Key]
        [DataMember]
        public int IdCreneau { get; set; }

        [DataMember]
        public TimeSpan HeureDebut { get; set; }

        [DataMember]
        public TimeSpan HeureFin { get; set; }

        [DataMember]
        public int IdAgenda { get; set; }

        [ForeignKey("IdAgenda")]
        [DataMember]
        public virtual Agenda Agenda { get; set; }
    }

}

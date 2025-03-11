using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGroupe2.Model
{
    public class Creneau
    {
        [Key]
        public int IdCreneau { get; set; }

        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }

        public int IdAgenda { get; set; }
        [ForeignKey("IdAgenda")]
        public virtual Agenda Agenda { get; set; }
    }
}

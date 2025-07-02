using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGroupe2.Model
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(30)]
        public string Libelle { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGroupe2.Model
{
    /// <summary>
    /// ***********************************************************************
    /// La classe soin eprésente un soin médical donné lors d'un rendez-vous.
    /// </summary>
    public class Soin
    {
        [Key]
        public int IdSoin { get; set; }
        [Required]
        public string Libelle { get; set; }

    }
}

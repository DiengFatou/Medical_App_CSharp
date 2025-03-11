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
    /// Repr�sente une secr�taire dans le syst�me.
    /// La secr�taire g�re les rendez-vous, les informations des patients, etc.
    /// </summary>
    public class Secretaire: Utilisateur
    {
        [Key]
        public int IdSecretaire { get; set; }

        [MaxLength(15)]
        public string TelephoneFixe { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Crmf;

namespace AppGroupe2.Model
{
    /// <summary>
    /// Représente un rapport généré à partir des données du système.
    /// Cette classe permet de générer des rapports sur les rendez-vous
    /// </summary>
    internal class ClassReportTicketRv
    {
      
        public string NomPrenom {  get; set; }
        public DateTime DateNaissance { get; set; }
        public DateTime DateRv {  get; set; }
        public string Medecin { get; set; }
        public string HeureRv { get; set; }
        public byte DataQr { get; set; }
    }
}

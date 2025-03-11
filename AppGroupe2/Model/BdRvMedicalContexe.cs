using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.EntityFramework;

namespace AppGroupe2.Model
{

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    /// <summary>
    /// ***********************************************************************
    /// Représente le contexte de la base de données pour les rendez-vous médicaux.
    /// Gère la communication avec la base de données et les entités liées.
    /// </summary>
    public class BdRvMedicalContexe:DbContext
    {

        public BdRvMedicalContexe() : base("bdRvMedicalContext") { }
           


        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public  DbSet<Agenda> Agenda { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<RendezVous> RendezVous {  get; set; }

        public DbSet<Soin> Soins { get; set; }
        public DbSet<Secretaire> Secretaires { get; set; }
        public DbSet<Specialite> Specialites {  get; set; }
        public DbSet<GroupeSanguin> GroupeSanguins {  get; set; }
        public DbSet<Creneau> Creneaux { get; set; }
        public DbSet<Td_Erreur> Td_Erreur { get; set; }


    }

}

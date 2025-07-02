using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MaterielRvMedical.Model;

namespace MetierRvMedical
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        BdRvMedicalContexe db = new BdRvMedicalContexe();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// Retourner la liste des agendas
        /// </summary>
        /// <returns></returns>
        public List<Agenda> GetListAgenda()
        {
            return db.Agenda.ToList();
        }

        /// <summary>
        /// Ajouter un agenda
        /// </summary>
        /// <returns></returns>
        public bool AddAgenda(Agenda agenda)
        {
            try
            {
                db.Agenda.Add(agenda);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }

        }
        /// <summary>
        /// Modifier un agenda
        /// </summary>
        /// <returns></returns>
        public bool UpdateAgenda(Agenda agenda)
        {
            try
            {
                db.Entry(agenda).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Supprimer un agenda par son ID
        /// </summary>
        /// <param name="id">L'identifiant de l'agenda à supprimer</param>
        /// <returns>True si la suppression a réussi, False sinon</returns>
        public bool DeleteAgenda(int id)
        {
            try
            {
                var agenda = db.Agenda.Find(id);
                if (agenda != null)
                {
                    db.Agenda.Remove(agenda);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Récupérer un agenda par son ID
        /// </summary>
        /// <param name="id">L'identifiant de l'agenda à retrouver</param>
        /// <returns>L'agenda correspondant ou null</returns>
        public Agenda GetAgendaById(int id)
        {
            return db.Agenda.Find(id);
        }

        /// <summary>
        /// Choisir/retrouver un agenda selon des critères spécifiques
        /// </summary>
        /// <returns>Liste des agendas correspondants</returns>
        //public List<Agenda> ChooseAgenda(int id)
        //{
        //    return db.Agenda.Where(a => a.IdAgenda.Find(id)
        //                    .ToList();
        //}
        /// <summary>
        /// Trouver un medecin par son id
        /// </summary>
        /// <returns></returns>
        public Medecin GetMedecinById(int id)
        {
            return db.Medecins.Find(id);
        }

        /// <summary>
        /// Retourner la liste des patients
        /// </summary>
        /// <returns></returns>

        public List<Patient> GetListPatient()
        {
            return db.Patients.ToList();
        }

        /// <summary>
        /// Ajouter un patient
        /// </summary>
        /// <returns></returns>
        /// 

        public bool AddPatient(Patient patient)
        {
            try
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Modifier un patient
        /// </summary>
        /// <returns></returns>
        /// 

        public bool UpdatePatient(Patient patient)
        {
            try
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);

                return false;
            }


        }


        /// <summary>
        /// Supprimer un patient par son ID
        /// </summary>
        /// <param name="id">L'identifiant du patient à supprimer</param>
        /// <returns>True si la suppression a réussi, False sinon</returns>
        public bool DeletePatient(int id)
        {
            try
            {
                var patient = db.Patients.Find(id);
                if (patient != null)
                {
                    db.Patients.Remove(patient);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Récupérer un agenda par son ID
        /// </summary>
        /// <param name="id">L'identifiant du patient à retrouver</param>
        /// <returns>Le patient correspondant ou null</returns>
        public Patient GetPatientById(int id)
        {
            return db.Patients.Find(id);
        }

        /// <summary>
        /// Retourner la liste des medecins
        /// </summary>
        /// <returns></returns>

        public List<Medecin> GetListMedecin()
        {
            return db.Medecins.ToList();
        }

        /// <summary>
        /// Ajouter un medecin
        /// </summary>
        /// <returns></returns>
        /// 

        public bool AddMedecin(Medecin medecin)
        {
            try
            {
                db.Medecins.Add(medecin);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);

                return false;
            }

        }

        /// <summary>
        /// Modifier un medecin
        /// </summary>
        /// <returns></returns>
        /// 

        public bool UpdateMedecin(Medecin medecin)
        {
            try
            {
                db.Entry(medecin).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }


        }


        /// <summary>
        /// Supprimer un agenda par son ID
        /// </summary>
        /// <param name="id">L'identifiant de l'agenda à supprimer</param>
        /// <returns>True si la suppression a réussi, False sinon</returns>
        public bool DeleteMedecin(int id)
        {
            try
            {
                var medecin = db.Medecins.Find(id);
                if (medecin != null)
                {
                    db.Medecins.Remove(medecin);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Retourner la liste des patients
        /// </summary>
        /// <returns></returns>

        public List<RendezVous> GetListRendezvous()
        {
            return db.RendezVous.ToList();
        }

        /// <summary>
        /// Ajouter un patient
        /// </summary>
        /// <returns></returns>
        /// 

        public bool AddRendezvous(RendezVous rendezVous)
        {
            try
            {
                db.RendezVous.Add(rendezVous);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Modifier un patient
        /// </summary>
        /// <returns></returns>
        /// 

        public bool UpdateRendezvous(RendezVous rendezvous)
        {
            try
            {
                db.Entry(rendezvous).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }


        }


        /// <summary>
        /// Supprimer un agenda par son ID
        /// </summary>
        /// <param name="id">L'identifiant de l'agenda à supprimer</param>
        /// <returns>True si la suppression a réussi, False sinon</returns>
        public bool DeleteRendezvous(int id)
        {
            try
            {
                var rendezvous = db.RendezVous.Find(id);
                if (rendezvous != null)
                {
                    db.RendezVous.Remove(rendezvous);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Récupérer un agenda par son ID
        /// </summary>
        /// <param name="id">L'identifiant du patient à retrouver</param>
        /// <returns>Le patient correspondant ou null</returns>
        public RendezVous GetRendezvousById(int id)
        {
            return db.RendezVous.Find(id);
        }

        /// <summary>
        /// Retourner la liste des patients
        /// </summary>
        /// <returns></returns>

        public List<Creneau> GetListCreneau()
        {
            return db.Creneaux.ToList();
        }

        /// <summary>
        /// Ajouter un patient
        /// </summary>
        /// <returns></returns>
        /// 

        public bool AddCreneau(Creneau creneau)
        {
            try
            {
                db.Creneaux.Add(creneau);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Modifier un patient
        /// </summary>
        /// <returns></returns>
        /// 

        public bool UpdateCreneau(Creneau creneau)
        {
            try
            {
                db.Entry(creneau).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }


        }


        /// <summary>
        /// Supprimer un agenda par son ID
        /// </summary>
        /// <param name="id">L'identifiant de l'agenda à supprimer</param>
        /// <returns>True si la suppression a réussi, False sinon</returns>
        public bool DeleteCreneau(int id)
        {
            try
            {
                var creneau = db.Creneaux.Find(id);
                if (creneau != null)
                {
                    db.Creneaux.Remove(creneau);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Récupérer un agenda par son ID
        /// </summary>
        /// <param name="id">L'identifiant du creneau à retrouver</param>
        /// <returns>Le creneau correspondant ou null</returns>
        public Creneau GetCreneauById(int id)
        {
            return db.Creneaux.Find(id);
        }

        /// <summary>
        /// Récupérer un agenda par son ID
        /// </summary>
        /// <param name="id">L'identifiant de la specialite à retrouver</param>
        /// <returns>Le specialite correspondant ou null</returns>

        public Specialite GetSpecialiteById(int id)
        {

            return db.Specialites.Find(id);
        }
        /// <summary>
        /// Récupère la liste de toutes les spécialités
        /// </summary>
        /// <returns>Liste des spécialités</returns>
        public List<Specialite> GetAllSpecialites()
        {
            try
            {
                return db.Specialites.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                throw new FaultException($"Erreur lors de la récupération des spécialités: {ex.Message}");
            }
        }


        /// <summary>
        /// Récupérer un agenda par son ID
        /// </summary>
        /// <param name="id">L'identifiant de la g à reroupe sanguinstrouver</param>
        /// <returns>Le groupeS sanguin correspondant ou null</returns>

        public GroupeSanguin GetGroupeSanguinById(int id)
        {

            return db.GroupeSanguins.Find(id);
        }
        /// <summary>
        /// Récupère la liste de toutes les groupe sanguins
        /// </summary>
        /// <returns>Liste des groupe sanguins</returns>
        public List<GroupeSanguin> GetAllGroupesSanguins()
        {
            try
            {
                return db.GroupeSanguins.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                throw new FaultException($"Erreur lors de la récupération des groupeSanguins: {ex.Message}");
            }
        }

        public Utilisateur GetUtilisateurByIdentifiant(string identifiant)
        {
            using (var db = new BdRvMedicalContexe())
            {
                return db.Utilisateurs
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Identifiant.ToLower() == identifiant.ToLower());
            }
        }


        /// <summary>
        /// Retourner la liste des soins
        /// </summary>
        /// <returns></returns>

        public List<Soin> GetListSoin()
        {
            return db.Soins.ToList();
        }

        /// <summary>
        /// Ajouter un soin
        /// </summary>
        /// <returns></returns>
        /// 

        public bool AddSoin(Soin soin
            )
        {
            try
            {
                db.Soins.Add(soin);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Modifier un soin
        /// </summary>
        /// <returns></returns>
        /// 

        public bool UpdateSoin(Soin soin)
        {
            try
            {
                db.Entry(soin).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }


        }


        /// <summary>
        /// Supprimer un soin par son ID
        /// </summary>
        /// <param name="id">L'identifiant du soin à supprimer</param>
        /// <returns>True si la suppression a réussi, False sinon</returns>
        public bool DeleteSoin(int id)
        {
            try
            {
                var soin = db.Soins.Find(id);
                if (soin != null)
                {
                    db.Soins.Remove(soin);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Récupérer un soin par son ID
        /// </summary>
        /// <param name="id">L'identifiant du soin à retrouver</param>
        /// <returns>Le soin correspondant ou null</returns>
        public Soin GetSoinById(int id)
        {
            return db.Soins.Find(id);
        }

        public Role GetRoleByCode(string code)
        {
            return db.Roles.FirstOrDefault(r => r.Code.ToLower() == code.ToLower());
        }

        public int CountAdmins()
        {
            return db.Admins.Count();
        }

        public bool AddAdmin(Admin admin)
        {
            try
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return false;
            }
        }

    }

}

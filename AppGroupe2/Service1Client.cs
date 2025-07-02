using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using AppGroupe2.App_Start;
using MetierRvMedical;
using MaterielRvMedical.Model;

namespace AppGroupe2.ServiceMetier
{
    public class Service1Client : IDisposable
    {
        private IService1 _service;
        private ChannelFactory<IService1> _factory;

        public Service1Client()
        {
            try
            {
                _factory = new ChannelFactory<IService1>("BasicHttpBinding_IService1");
                _service = _factory.CreateChannel();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur de connexion au service: " + ex.Message);
            }
        }

        public string GetData(int value)
        {
            return _service.GetData(value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            return _service.GetDataUsingDataContract(composite);
        }

        public bool AddAgenda(Agenda agenda)
        {
            return _service.AddAgenda(agenda);
        }

        public bool UpdateAgenda(Agenda agenda)
        {
            return _service.UpdateAgenda(agenda);
        }

        public List<Agenda> GetListAgenda()
        {
            return _service.GetListAgenda();
        }

        public Medecin GetMedecinById(int id)
        {
            return _service.GetMedecinById(id);
        }

        public bool DeleteAgenda(int id)
        {
            return _service.DeleteAgenda(id);
        }

        public Agenda GetAgendaById(int id)
        {
            return _service.GetAgendaById(id);
        }

        public bool DeletePatient(int id)
        {
            return _service.DeletePatient(id);
        }

        public Patient GetPatientById(int id)
        {
            return _service.GetPatientById(id);
        }

        public bool AddPatient(Patient patient)
        {
            return _service.AddPatient(patient);
        }

        public bool UpdatePatient(Patient patient)
        {
            return _service.UpdatePatient(patient);
        }

        public List<Patient> GetListPatient()
        {
            return _service.GetListPatient();
        }

        public bool AddMedecin(Medecin medecin)
        {
            return _service.AddMedecin(medecin);
        }

        public bool UpdateMedecin(Medecin medecin)
        {
            return _service.UpdateMedecin(medecin);
        }

        public List<Medecin> GetListMedecin()
        {
            return _service.GetListMedecin();
        }

        public bool DeleteMedecin(int id)
        {
            return _service.DeleteMedecin(id);
        }

        public bool AddRendezvous(RendezVous rendezVous)
        {
            return _service.AddRendezvous(rendezVous);
        }

        public bool UpdateRendezvous(RendezVous rendezVous)
        {
            return _service.UpdateRendezvous(rendezVous);
        }

        public List<RendezVous> GetListRendezvous()
        {
            return _service.GetListRendezvous();
        }

        public bool DeleteRendezvous(int id)
        {
            return _service.DeleteRendezvous(id);
        }

        public bool AddCreneau(Creneau creneau)
        {
            return _service.AddCreneau(creneau);
        }

        public bool UpdateCreneau(Creneau creneau)
        {
            return _service.UpdateCreneau(creneau);
        }

        public List<Creneau> GetListCreneau()
        {
            return _service.GetListCreneau();
        }

        public bool DeleteCreneau(int id)
        {
            return _service.DeleteCreneau(id);
        }

        public RendezVous GetRendezvousById(int id)
        {
            return _service.GetRendezvousById(id);
        }

        public Creneau GetCreneauById(int id)
        {
            return _service.GetCreneauById(id);
        }

        public Specialite GetSpecialiteById(int id)
        {
            return _service.GetSpecialiteById(id);
        }

        public List<Specialite> GetAllSpecialites()
        {
            return _service.GetAllSpecialites();
        }

        public GroupeSanguin GetGroupeSanguinById(int id)
        {
            return _service.GetGroupeSanguinById(id);
        }

        public List<GroupeSanguin> GetAllGroupesSanguins()
        {
            return _service.GetAllGroupesSanguins();
        }

        public Utilisateur GetUtilisateurByIdentifiant(string identifiant)
        {
            return _service.GetUtilisateurByIdentifiant(identifiant);
        }

        public bool AddSoin(Soin soin)
        {
            return _service.AddSoin(soin);
        }

        public bool UpdateSoin(Soin soin)
        {
            return _service.UpdateSoin(soin);
        }

        public List<Soin> GetListSoin()
        {
            return _service.GetListSoin();
        }

        public bool DeleteSoin(int id)
        {
            return _service.DeleteSoin(id);
        }

        public Role GetRoleByCode(string code)
        {
            return _service.GetRoleByCode(code);
        }

        public int CountAdmins()
        {
            return _service.CountAdmins();
        }

        public bool AddAdmin(Admin admin)
        {
            return _service.AddAdmin(admin);
        }

        public void Dispose()
        {
            if (_service != null && _service is ICommunicationObject)
            {
                try
                {
                    ((ICommunicationObject)_service).Close();
                }
                catch
                {
                    ((ICommunicationObject)_service).Abort();
                }
            }

            if (_factory != null)
            {
                _factory.Close();
            }
        }
    }
}
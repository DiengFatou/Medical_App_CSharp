using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MaterielRvMedical.Model;

namespace MetierRvMedical
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        bool AddAgenda(Agenda agenda);

        [OperationContract]
        bool UpdateAgenda(Agenda agenda);

        [OperationContract]
        List<Agenda> GetListAgenda();

        [OperationContract]
        Medecin GetMedecinById(int id);

        [OperationContract]
        bool DeleteAgenda(int id);

        [OperationContract]
        Agenda GetAgendaById(int id);

        [OperationContract]
        bool DeletePatient(int id);

        [OperationContract]
        Patient GetPatientById(int id);

        [OperationContract]
        bool AddPatient(Patient patient);

        [OperationContract]
        bool UpdatePatient(Patient patient);

        [OperationContract]
        List<Patient> GetListPatient();


        [OperationContract]
        bool AddMedecin(Medecin medecin);

        [OperationContract]
        bool UpdateMedecin(Medecin medecin);

        [OperationContract]
        List<Medecin> GetListMedecin();

      
        [OperationContract]
        bool DeleteMedecin(int id);

        [OperationContract]
        bool AddRendezvous(RendezVous rendezVous);

        [OperationContract]
        bool UpdateRendezvous(RendezVous rendezVous);

        [OperationContract]
        List<RendezVous> GetListRendezvous();

   

        [OperationContract]
        bool DeleteRendezvous(int id);

        [OperationContract]
        bool AddCreneau(Creneau creneau);

        [OperationContract]
        bool UpdateCreneau(Creneau creneau);

        [OperationContract]
        List<Creneau> GetListCreneau();

    

        [OperationContract]
        bool DeleteCreneau(int id);
        [OperationContract]
        RendezVous GetRendezvousById(int id);

        [OperationContract]
        Creneau GetCreneauById(int id);

        [OperationContract]
        Specialite GetSpecialiteById(int id);

        [OperationContract]
        List<Specialite> GetAllSpecialites();

        [OperationContract]
        GroupeSanguin GetGroupeSanguinById(int id);

        [OperationContract]
        List<GroupeSanguin> GetAllGroupesSanguins();

        [OperationContract]
        Utilisateur GetUtilisateurByIdentifiant(string identifiant);

        [OperationContract]
        bool AddSoin(Soin soin);

        [OperationContract]
        bool UpdateSoin(Soin soin);

        [OperationContract]
        List<Soin> GetListSoin();

        [OperationContract]
        Soin GetSoinById(int id);

        [OperationContract]
        bool DeleteSoin(int id);


        [OperationContract]
        Role GetRoleByCode(string code);

        [OperationContract]
        int CountAdmins();

        [OperationContract]
        bool AddAdmin(Admin admin);


        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}


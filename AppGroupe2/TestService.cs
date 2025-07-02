using System;
using System.Windows.Forms;
using AppGroupe2.ServiceMetier;

namespace AppGroupe2
{
    public class TestService
    {
        public static bool TestConnexionService()
        {
            try
            {
                using (var service = new AppGroupe2.ServiceMetier.Service1Client())
                {
                    // Test simple pour vérifier la connexion
                    var result = service.GetData(1);
                    return !string.IsNullOrEmpty(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de connexion au service: {ex.Message}", "Test de Connexion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void TestChargementDonnees()
        {
            try
            {
                using (var service = new AppGroupe2.ServiceMetier.Service1Client())
                {
                    // Test du chargement des patients
                    var patients = service.GetListPatient();
                    MessageBox.Show($"Nombre de patients chargés: {patients?.Count ?? 0}", "Test de Données",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Test du chargement des médecins
                    var medecins = service.GetListMedecin();
                    MessageBox.Show($"Nombre de médecins chargés: {medecins?.Count ?? 0}", "Test de Données",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Test du chargement des soins
                    var soins = service.GetListSoin();
                    MessageBox.Show($"Nombre de soins chargés: {soins?.Count ?? 0}", "Test de Données",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du test de chargement: {ex.Message}", "Test de Données",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 
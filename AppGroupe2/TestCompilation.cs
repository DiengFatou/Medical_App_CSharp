using System;
using System.Windows.Forms;
using AppGroupe2.ServiceMetier;

namespace AppGroupe2
{
    public class TestCompilation
    {
        public static void TestServiceClientCreation()
        {
            try
            {
                // Test de création du client simple
                using (var simpleClient = new SimpleServiceClient())
                {
                    string result = simpleClient.TestConnection();
                    MessageBox.Show($"Test de connexion réussi: {result}", "Test de Compilation",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du test: {ex.Message}", "Test de Compilation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void TestServiceClientFull()
        {
            try
            {
                // Test de création du client complet
                using (var fullClient = new Service1Client())
                {
                    string result = fullClient.GetData(1);
                    MessageBox.Show($"Test du client complet réussi: {result}", "Test de Compilation",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du test du client complet: {ex.Message}", "Test de Compilation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 
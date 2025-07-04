using AppGroupe2.Helper;
using AppGroupe2.ServiceMetier;
using AppGroupe2.View;
using MaterielRvMedical.Model;
using System;
using System.Windows.Forms;

namespace AppGroupe2
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                InitializeAdminAccount();
                Application.Run(new frmMenu());
            }
            catch (Exception ex)
            {
                HandleGlobalException(ex);
            }
        }

        private static void InitializeAdminAccount()
        {
            try
            {
                using (var service = new Service1Client())
                {
                    if (!AdminExists(service))
                    {
                        CreateDefaultAdmin(service);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur d'initialisation admin: {ex.Message}",
                    "Erreur Critique",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                // Log l'exception si nécessaire
            }
        }

        private static bool AdminExists(Service1Client service)
        {
            try
            {
                return service.CountAdmins() > 0;
            }
            catch
            {
                // Log l'erreur
                return true; // Empêche les tentatives répétées en cas d'erreur
            }
        }

        private static void CreateDefaultAdmin(Service1Client service)
        {
            var role = service.GetRoleByCode("admin");
            if (role == null)
            {
                throw new InvalidOperationException("Le rôle admin n'est pas configuré dans le système");
            }

            var admin = new Admin
            {
                Adresse = "Kounoune",
                Identifiant = "admin",
                Status = true,
                NomPrenom = "Dieng Fatou",
                Tel = "778985335",
                Email = "dieng@admin.com",
                MotDePasse = CryptString.GetMd5Hash("Passer@123"),
                IdRole = role.Id
            };

            if (!service.AddAdmin(admin))
            {
                throw new ApplicationException("Échec de la création du compte admin");
            }
        }

        private static void HandleGlobalException(Exception ex)
        {
            // Ici vous pourriez logger l'exception dans un fichier
            MessageBox.Show($"Une erreur critique est survenue: {ex.Message}\nL'application va se fermer.",
                "Erreur Fatale",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            Environment.Exit(1);
        }
    }
}
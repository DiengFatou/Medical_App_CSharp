using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web;
using AppGroupe2.ServiceMetier;
using MaterielRvMedical.Model;

namespace AppGroupe2.App_Code
{
    public class Utils
    {
        /// <summary>
        /// Rédiger les erreurs au niveau de la base de données via le service WCF
        /// </summary>
        /// <param name="TitreErreur">Le titre provoquant l'erreur</param>
        /// <param name="erreur">Le message d'erreur</param>
        public void WriteDataError(string TitreErreur, string erreur)
        {
            try
            {
                using (var service = new Service1Client())
                {
                    var log = new Td_Erreur
                    {
                        DateErreur = DateTime.Now,
                        DescriptionErreur = erreur.Length > 1000 ? erreur.Substring(0, 1000) : erreur,
                        TitreErreur = TitreErreur
                    };

                    service.AddError(log); // Assure-toi que cette méthode existe dans le service
                }
            }
            catch (Exception ex)
            {
                WriteLogSystem(ex.ToString(), "WriteDataError");
            }
        }

        /// <summary>
        /// Rédiger le message d'erreur dans l'Observateur d'événements Windows
        /// </summary>
        public static void WriteFileError(string erreur, string libelle)
        {
            try
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "GestionRvMedical";
                    eventLog.WriteEntry($"date: {DateTime.Now}, libelle: {libelle}, desciption: {erreur}",
                        EventLogEntryType.Information, 101, 1);
                }
            }
            catch { }
        }

        public static void WriteFileError(string message)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath("~/Error/erreur.txt");
                using (TextWriter writeFile = new StreamWriter(path, true))
                {
                    writeFile.WriteLine(DateTime.Now);
                    writeFile.WriteLine(message);
                    writeFile.WriteLine("---------------------------------------------------------------------------------------");
                }
            }
            catch (IOException e)
            {
                WriteLogSystem(e.ToString(), "WriteFileError");
            }
        }

        public bool CreateFile(string message)
        {
            bool rep = false;
            string fileName = $"{DateTime.Now:yyyyMMdd}.txt";
            try
            {
                string path = HttpContext.Current.Server.MapPath($"~/Error/{fileName}");

                if (File.Exists(path))
                    File.Delete(path);

                using (TextWriter writeFile = new StreamWriter(path, true))
                {
                    writeFile.WriteLine(DateTime.Now);
                    writeFile.WriteLine(message);
                    writeFile.WriteLine("-------------------------------------------");
                }

                rep = true;
            }
            catch (IOException e)
            {
                WriteLogSystem(e.ToString(), "CreateFile");
            }

            return rep;
        }

        public void WriteErrorLoad(List<string> messages, string fileName)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath($"~/Error/{fileName}.txt");

                if (File.Exists(path))
                    File.Delete(path);

                using (TextWriter writeFile = new StreamWriter(path, true))
                {
                    writeFile.WriteLine("---------------------DEBUT----------------------");
                    foreach (var msg in messages)
                        writeFile.WriteLine(msg);
                    writeFile.WriteLine("----------------------FIN---------------------");
                }
            }
            catch (IOException e)
            {
                WriteLogSystem(e.ToString(), "WriteErrorLoad");
            }
        }

        public static void WriteLogSystem(string erreur, string libelle)
        {
            try
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "DPV Permis";
                    eventLog.WriteEntry($"date: {DateTime.Now}, libelle: {libelle}, description {erreur}",
                        EventLogEntryType.Error, 101, 1);
                }
            }
            catch { }
        }
    }
}

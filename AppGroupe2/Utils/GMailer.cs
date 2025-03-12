using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.IO;
using AppGroupe2.App_Code;

namespace AppGroupe2.App_Start
{
    public class GMailer
    {

        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        //public class TempMail
        //{
        //    public string DestinataireMail { get; set; }
        //    public string TitreMail { get; set; }
        //    public string TextMail { get; set; }
        //    public string Envoyer { get; set; }
        //}
        // Charger les paramètres SMTP depuis appsettings.json
        static GMailer()
        {
            
            GmailHost = "smtp.gmail.com";
            GmailPort = 587;  // port 587 pour Gmail avec SSL/TLS
            GmailSSL = true;
        }

        public void Send()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);
            try
            {
                using (var message = new MailMessage(GmailUsername, ToEmail))
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = IsHtml;
                    smtp.Send(message);
                }

            }
            catch (Exception ex)
            { 
           //to do
                };
            } 
        

        public static void SendMail(string destinataire, string subject, string body)
        {
            try
            {
                GMailer.GmailUsername = "dchifai8@gmail.com";
                GMailer.GmailPassword = "a7832140";

                GMailer mailer = new GMailer();
                mailer.ToEmail = destinataire;
                mailer.Subject = subject;
                mailer.Body = body;
                mailer.IsHtml = true;
                mailer.Send();
            }
            catch (Exception ex)
            {
                // Ajouter un log d'erreur ici (par exemple, enregistrer dans un fichier log ou une base de données)
                Console.WriteLine("Erreur lors de l'envoi de l'email : " + ex.Message);
            };
        }
           
    }
}
 

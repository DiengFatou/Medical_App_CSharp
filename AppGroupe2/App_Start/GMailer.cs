using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AppGroupe2.App_Start
{
    public class GMailer
    {
        public static AppGroupe2.Service1Client service = new AppGroupe2.Service1Client();

        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public class TempMail
        {
            public string DestinataireMail { get; set; }
            public string TitreMail { get; set; }
            public string TextMail { get; set; }
            public string Envoyer { get; set; }
        }
        // Charger les paramètres SMTP depuis appsettings.json
        static GMailer()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            GmailUsername = config["EmailSettings:Email"];
            GmailPassword = config["EmailSettings:Password"];
            GmailHost = "smtp.gmail.com";
            GmailPort = 587;  // Correction : port 587 pour Gmail avec SSL/TLS
            GmailSSL = true;
        }

        public void Send()
        {
            using (SmtpClient smtp = new SmtpClient(GmailHost, GmailPort))
            {
                smtp.EnableSsl = GmailSSL;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
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
                    Console.WriteLine($"Erreur d'envoi de l'email : {ex.Message}");
                    // Stockage de l'erreur pour réessayer plus tard
                    TempMail mail = new TempMail
                    {
                        DestinataireMail = ToEmail,
                        Envoyer = "N",
                        TextMail = Body,
                        TitreMail = Subject
                    };
                    service.AddMailSended(mail);
                }
            }
        }

        public static void SendMail(string address, string subject, string body)
        {
            using (MailMessage message = new MailMessage(GmailUsername, address))
            {
                message.Subject = subject;
                message.Body = "<pre>" + body + "</pre>";
                message.Priority = MailPriority.High;
                message.IsBodyHtml = true;

                using (SmtpClient client = new SmtpClient(GmailHost, GmailPort))
                {
                    client.EnableSsl = GmailSSL;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erreur lors de l'envoi de l'email : {ex.Message}");
                        TempMail mail = new TempMail
                        {
                            DestinataireMail = address,
                            Envoyer = "N",
                            TextMail = body,
                            TitreMail = subject
                        };
                        service.AddMailSended(mail);
                    }
                }
            }
        }
    }
}

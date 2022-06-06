//using Base_Comun;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Options;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Mail;
//using System.Threading.Tasks;

//namespace Logica.EmailService
//{
//    public class EmailService : IEmailService
//    {
//        private SmtpClient Cliente { get; }
//        private EmailServiceOptions Options { get; }

//        public EmailService(IOptions<EmailServiceOptions> options)
//        {
//            Options = options.Value;
//            Cliente = new SmtpClient()
//            {
//                Host = Options.SmtpServer,
//                Port = Options.Port,
//                DeliveryMethod = SmtpDeliveryMethod.Network,
//                UseDefaultCredentials = false,
//                Credentials = new NetworkCredential(Options.Email, Options.Password),
//                EnableSsl = Options.EnableSsl,
//            };
//        }

//        public Task SendEmailAsync(List<string> destinatarios, string subject, string body)
//        {
//            var correo = new MailMessage();
//            correo.From = new MailAddress(Options.Email);
//            correo.Subject = subject;
//            correo.Body = body;
//            correo.IsBodyHtml = true;

//            foreach (var email in destinatarios)
//                correo.To.Add(email);

//            return Cliente.SendMailAsync(correo);
//        }
//        public Task SendEmailWithAtachmentAsync(List<string> destinatarios, string subject, string body, IFormFile file)
//        {
//            var correo = new MailMessage();
//            correo.From = new MailAddress(Options.Email);
//            correo.Subject = subject;
//            correo.Body = body;
//            correo.IsBodyHtml = true;
//            correo.Attachments.Add(new Attachment(file.OpenReadStream(), file.FileName));


//            foreach (var email in destinatarios)
//                correo.To.Add(email);

//            return Cliente.SendMailAsync(correo);
//        }
//        public Task SendEmailWithAtachmentAsync(List<string> destinatarios, string subject, string body, IEnumerable<IFormFile> files)
//        {
//            var correo = new MailMessage();
//            correo.From = new MailAddress(Options.Email);
//            correo.Subject = subject;
//            correo.Body = body;
//            correo.IsBodyHtml = true;

//            foreach (var email in destinatarios)
//                correo.To.Add(email);

//            foreach (var file in files)
//                correo.Attachments.Add(new Attachment(file.OpenReadStream(), file.FileName));

//            return Cliente.SendMailAsync(correo);
//        }
//    }
//}

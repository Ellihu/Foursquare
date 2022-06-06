using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logica.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<string> destinatarios, string subject, string message);
        public Task SendEmailWithAtachmentAsync(List<string> destinatarios, string subject, string message, IFormFile file);
        public Task SendEmailWithAtachmentAsync(List<string> destinatarios, string subject, string message, IEnumerable<IFormFile> files);

    }
}

using System.Threading.Tasks;
using Twilio.Application.DTOs.Mail;

namespace Twilio.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}
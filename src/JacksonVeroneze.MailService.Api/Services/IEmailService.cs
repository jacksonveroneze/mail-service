using System.Threading.Tasks;
using JacksonVeroneze.MailService.Api.Models;

namespace JacksonVeroneze.MailService.Api.Services
{
    public interface IEmailService
    {
        Task Send(MailRequest mailRequest);
    }
}

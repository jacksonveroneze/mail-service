using System.Threading.Tasks;
using JacksonVeroneze.MailService.Api.Models;

namespace JacksonVeroneze.MailService.Api.Services
{
    public interface IEmailService
    {
        Task<MailResponse> SendAsync(MailRequest mailRequest);
    }
}

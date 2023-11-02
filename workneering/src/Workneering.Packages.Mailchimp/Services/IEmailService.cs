using Workneering.Packages.Mailchimp.Models;

namespace Workneering.Packages.Mailchimp.Services
{
    public interface IEmailService
    {
        Task SendEmailService(SingleEmailOptions options);

    }
}

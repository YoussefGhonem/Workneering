using Ardalis.GuardClauses;
using System;

namespace Workneering.Packages.Mailchimp.Models
{
    public class SingleEmailOptions
    {
        public int TemplateId { get; set; }
        public EmailAddressModel? To { get; set; }
        public string? Title { get; set; }
        public string? SubjectLine { get; set; }
        public string? HtmlContent { get; set; }

        public SingleEmailOptions(EmailAddressModel to, int templateId, string subject, string textBody, string title)
        {
            To = to;
            SubjectLine = Guard.Against.NullOrWhiteSpace(subject, nameof(subject));
            HtmlContent = Guard.Against.NullOrWhiteSpace(textBody, nameof(textBody));
            Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
            TemplateId = templateId;
        }
    }
}

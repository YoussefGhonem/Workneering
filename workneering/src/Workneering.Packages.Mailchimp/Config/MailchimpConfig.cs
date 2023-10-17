namespace Workneering.Packages.Mailchimp.Config;

public sealed class MailchimpConfig
{
    public string? ApiKey { get; set; }
    public string? ListId { get; set; }
    public string? AudienceName { get; set; }
    public MailchimpFromConfig? From { get; set; }
}
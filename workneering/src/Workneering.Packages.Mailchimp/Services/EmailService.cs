using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MailChimp;
using MailChimp.Campaigns;
using MailChimp.Net;
using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using Microsoft.Extensions.Configuration;
using Workneering.Packages.Mailchimp.Config;
using Workneering.Packages.Mailchimp.Models;

namespace Workneering.Packages.Mailchimp.Services;

public class EmailService : IEmailService
{
    private readonly MailchimpConfig _sendGridConfig;
    private readonly MailChimp.Net.MailChimpManager _mailchimpManager;

    public EmailService(IConfiguration configuration)
    {
        _sendGridConfig = configuration.GetSendGridConfig();
        _mailchimpManager = new MailChimp.Net.MailChimpManager(_sendGridConfig.ApiKey);
    }


    public async Task SendEmailService(SingleEmailOptions options)
    {
        try
        {

            var _campaignSettings = new Setting
            {
                ReplyTo = options.To.Email,
                ToName = options.To.Name,
                FromName = _sendGridConfig.From.Name,
                Title = options.Title,
                SubjectLine = options.SubjectLine,
            };
            var campaign = _mailchimpManager.Campaigns.AddAsync(new MailChimp.Net.Models.Campaign
            {
                Settings = _campaignSettings,
                Recipients = new Recipient { ListId = _sendGridConfig.ListId },
                Type = CampaignType.Regular
            }).Result;

            var timeStr = DateTime.Now.ToString();
            var content = _mailchimpManager.Content.AddOrUpdateAsync(
             campaign.Id,
             new ContentRequest()
             {
                 Template = new ContentTemplate
                 {
                     Id = options.TemplateId,
                     Sections = new Dictionary<string, object>()
                     {
                       { "{{body_content}}", options.HtmlContent }
                     }
                 }
             }).Result;

            _mailchimpManager.Campaigns.SendAsync(campaign.Id).Wait();

        }
        catch (Exception ex)
        {
        }
    }

    public static async Task<int> TemplateCreateAsync(string apiKey, string templateName, string UnlayerContent)
    {
        var template = await new MailChimp.Net.MailChimpManager(apiKey).Templates.CreateAsync(templateName, string.Empty, UnlayerContent);
        return template.Id;
    }


}
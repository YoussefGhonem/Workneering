﻿using Microsoft.Extensions.Configuration;
using Workneering.Packages.Mailchimp.Config;

namespace TicketManagement.Base.Email.SendGrid.Extensions;

public static class ConfigureService
{
    public static MailchimpConfig GetSendGridConfig(this IConfiguration configuration)
    {
        var confg = configuration.GetSection("MailChimp").Get<MailchimpConfig>();
        if (confg == null)
            throw new Exception("Missing 'MailChimp' configuration section from the appsettings.");
        return confg;
    }
}
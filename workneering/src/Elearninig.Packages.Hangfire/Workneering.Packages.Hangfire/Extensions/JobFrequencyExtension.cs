using Hangfire;
using Workneering.Packages.Hangfire.Enums;

namespace Workneering.Packages.Hangfire.Extensions;

public static class JobFrequencyExtension
{
    public static string ToCron(this JobFrequencyEnum jobFrequency)
    {
        return jobFrequency switch
        {
            JobFrequencyEnum.Daily => Cron.Daily(),
            JobFrequencyEnum.Weekly => Cron.Weekly(),
            JobFrequencyEnum.Monthly => Cron.Monthly(),
            JobFrequencyEnum.Yearly => Cron.Yearly(),
            _ => Cron.Monthly(),
        };
    }
}
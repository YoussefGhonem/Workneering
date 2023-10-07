namespace Workneering.Identity.Infrastructure.Helper
{
    public class GoogleAuthSettings
    {
        public const string SectionName = "GoogleAuth";
        public string ClientId { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;
    }
}

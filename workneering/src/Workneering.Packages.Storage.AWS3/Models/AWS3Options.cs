namespace Workneering.Packages.Storage.AWS3.Models
{
    public class AWS3Options
    {
        public string AWSAccessKey { get; set; } = null!;
        public string AWSSecretKey { get; set; } = null!;
        public string DefaultBucket { get; set; } = null!;
    }
}

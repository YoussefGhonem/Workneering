namespace Workneering.Packages.Storage.AWS3.Models;

public class StoredFile
{
    public Guid BlobId { get; set; }
    public string? FileName { get; set; }
    public string? DownloadUrl { get; set; }
    public DateTimeOffset UploadedDate { get; set; }
    public long FileSize { get; set; }
}
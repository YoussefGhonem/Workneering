using Microsoft.AspNetCore.Http;
using Workneering.Packages.Storage.AWS3.Models;

namespace Workneering.Packages.Storage.AWS3.Services
{
    public interface IStorageService
    {
        Task<StoredFile> Upload(IFormFile file, string? containerName = null, CancellationToken cancellationToken = default);

        Task<StoredFile> Upload(Stream? file, string? fileName, string? containerName = null, CancellationToken cancellationToken = default);

        Task<List<StoredFile>?> UploadFiles(List<IFormFile>? file, string? containerName = null, CancellationToken cancellationToken = default);

        Task Delete(Guid blobId, string? containerName = null);
        //Task<DownloadedFile> Download(Guid blobId, string? containerName = null);
        Task<byte[]?> DownlaodAsMemoryStream(Guid blobId, string? containerName = null);
    }
}

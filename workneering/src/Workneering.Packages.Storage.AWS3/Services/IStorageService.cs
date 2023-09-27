using Microsoft.AspNetCore.Http;
using Workneering.Packages.Storage.AWS3.Models;

namespace Workneering.Packages.Storage.AWS3.Services;
public interface IStorageService
{
    Task<StoredFile> Upload(IFormFile? file, CancellationToken cancellationToken = default);
    Task<List<StoredFile>?> UploadFiles(List<IFormFile>? file, CancellationToken cancellationToken = default);
    Task<bool> Delete(string key, CancellationToken cancellationToken = default);
    Task<DownloadedFile> DownloadFile(string key);
    Task<string> DownloadFileUrl(string key);
}

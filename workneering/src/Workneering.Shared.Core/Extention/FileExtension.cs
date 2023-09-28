using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Models;

namespace Workneering.Shared.Core.Extention;

public static class FileExtension
{
    public static string SetDownloadFileUrl(this FileDto? file, IStorageService storageService)
    {
        if (file is null || string.IsNullOrWhiteSpace(file.Key)) return file?.Key;
        var url = storageService.DownloadFileUrl(file.Key).Result;
        return url.ToString();
    }

}
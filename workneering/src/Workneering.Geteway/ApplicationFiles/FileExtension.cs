using Microsoft.Extensions.Configuration;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Shared.Core.Models;

namespace Workneering.Geteway.ApplicationFiles;

public static class FileExtension
{
    private static bool _secured;

    public static List<string?>? SetDownloadFileUrls(this List<FileDto>? files)
    {
        if (files is null || !files.Any()) return new List<string?>();

        return files?.Select(image => image.SetDownloadFileUrl()).ToList();
    }

    public static string? SetDownloadFileUrl(this FileDto? file)
    {
        if (file is null || string.IsNullOrWhiteSpace(file.Key)) return file?.Key;

        return $"{CurrentUser.BaseUrl}/api/v1/files/{file.Key}/download";
    }

    internal static void InitializeConfiguration(IConfiguration configuration)
    {
        _secured = bool.Parse(configuration["AzureBlobStorage:Secured"]);
    }
}
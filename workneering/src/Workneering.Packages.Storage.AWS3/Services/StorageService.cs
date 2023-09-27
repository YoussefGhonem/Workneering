using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Workneering.Packages.Storage.AWS3.Extensions;
using Workneering.Packages.Storage.AWS3.Models;

namespace Workneering.Packages.Storage.AWS3.Services
{
    public class StorageService : IStorageService
    {
        private readonly AWS3Options _storageConfig;
        private readonly string _bucketName;
        private readonly IConfiguration _configuration;
        public StorageService(IConfiguration configuration)
        {
            _storageConfig = configuration.GetAWSConfigurationOptions();
            _bucketName = _storageConfig.DefaultBucket;
            _configuration = configuration;
        }

        public async Task<StoredFile> Upload(Stream? file, string? fileName, string? bucketName = null, CancellationToken cancellationToken = default)
        {
            if (file is null) return new StoredFile();
            if (fileName is null) return new StoredFile();

            var credential = AWS3OptionsExtension.GetAWSConfigurationOptions(_configuration);
            var key = Guid.NewGuid();
            var stream = file;
            bucketName = credential.DefaultBucket;
            var fileNameStorage = GetFileName(key, fileName);
            var region = AWS3ConfigurationExtension.GetRgionAWS();

            var uploadRequest = new TransferUtilityUploadRequest()
            {
                BucketName =
            };
        }
        public Task<List<StoredFile>?> UploadFiles(List<IFormFile>? file, string? bucketName = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Guid blobId, string? bucketName = null)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]?> DownlaodAsMemoryStream(Guid blobId, string? bucketName = null)
        {
            throw new NotImplementedException();
        }

        public Task<StoredFile> Upload(IFormFile file, string? bucketName = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        #region Helpers
        private static string GetFileName(Guid blobId, string contentType)
        {
            var fileSplit = contentType.Split('.');
            var fileExtension = fileSplit[^1];
            var blobFileName = blobId.ToString();
            if (fileSplit.Length > 1) blobFileName += "." + fileExtension;
            return blobFileName;
        }

        #endregion

    }
}

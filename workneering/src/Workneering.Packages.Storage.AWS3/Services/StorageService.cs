using Amazon.Runtime.Internal;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text;
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

        public async Task<StoredFile> Upload(IFormFile? file, CancellationToken cancellationToken = default)
        {
            if (file is null) return new StoredFile();

            try
            {
                var options = AWS3OptionsExtension.GetAWSConfigurationOptions(_configuration);
                var region = AWS3ConfigurationExtension.GetRgionAWS();
                var credential = AWS3ConfigurationExtension.GetBasicAWSCredentials(_configuration);

                var key = Guid.NewGuid();
                var stream = file.OpenReadStream();
                var bucketName = options.DefaultBucket;
                var fileNameStorage = GetFileName(key, file.FileName);

                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    BucketName = bucketName,
                    Key = fileNameStorage,
                    InputStream = stream,
                    CannedACL = S3CannedACL.PublicRead,

                };
                uploadRequest.Metadata.Add("filename", $"{file.FileName}");
                var client = new AmazonS3Client(credential, region);
                // upload to s3
                var transferUtility = new TransferUtility(client);
                await transferUtility.UploadAsync(uploadRequest, cancellationToken);

                var size = file.Length;
                var originalFileName = file.FileName;
                var extension = Path.GetExtension(originalFileName);

                return new StoredFile()
                {
                    FileName = originalFileName,
                    Key = fileNameStorage,
                    Extension = extension,
                    FileSize = size,
                };
            }
            catch (AmazonS3Exception e)
            {
                throw;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<List<StoredFile>?> UploadFiles(List<IFormFile>? files, CancellationToken cancellationToken = default)
        {
            if (files == null || files.Count == 0)
            {
                return new List<StoredFile>();
            }

            var options = AWS3OptionsExtension.GetAWSConfigurationOptions(_configuration);
            var region = AWS3ConfigurationExtension.GetRgionAWS();
            var credential = AWS3ConfigurationExtension.GetBasicAWSCredentials(_configuration);

            var bucketName = options.DefaultBucket;
            var uploadedFiles = new List<StoredFile>();

            var transferUtility = new TransferUtility(new AmazonS3Client(credential, region));

            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                {
                    // Handle the case where a file is null or empty (optional).
                    continue;
                }

                var key = Guid.NewGuid();
                var stream = file.OpenReadStream();
                var fileNameStorage = GetFileName(key, file.FileName);

                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    BucketName = bucketName,
                    Key = fileNameStorage,
                    InputStream = stream,
                    CannedACL = S3CannedACL.NoACL
                };
                uploadRequest.Metadata.Add("filename", $"{file.FileName}");
                await transferUtility.UploadAsync(uploadRequest, cancellationToken);

                var size = file.Length;
                var originalFileName = file.FileName;
                var extension = Path.GetExtension(originalFileName);

                var storedFile = new StoredFile()
                {
                    FileName = originalFileName,
                    Key = fileNameStorage,
                    Extension = extension,
                    FileSize = size,
                };

                uploadedFiles.Add(storedFile);
            }

            return uploadedFiles;
        }
        public async Task<bool> Delete(string key, CancellationToken cancellationToken = default)
        {
            var options = AWS3OptionsExtension.GetAWSConfigurationOptions(_configuration);
            var region = AWS3ConfigurationExtension.GetRgionAWS();
            var credential = AWS3ConfigurationExtension.GetBasicAWSCredentials(_configuration);
            var bucketName = options.DefaultBucket;

            var client = new AmazonS3Client(credential, region);

            var deleteRequest = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = key
            };

            try
            {
                var response = await client.DeleteObjectAsync(deleteRequest, cancellationToken);
                // Check the response for success
                return response.HttpStatusCode == HttpStatusCode.NoContent;
            }
            catch (AmazonS3Exception ex)
            {
                // Handle exceptions, such as object not found
                // Log the error or perform other error handling as needed
                return false;
            }
        }
        public async Task<string> DownloadFileUrl(string key)
        {
            var options = AWS3OptionsExtension.GetAWSConfigurationOptions(_configuration);
            var region = AWS3ConfigurationExtension.GetRgionAWS();
            var credential = AWS3ConfigurationExtension.GetBasicAWSCredentials(_configuration);
            var bucketName = options.DefaultBucket;

            var client = new AmazonS3Client(credential, region);

            // Generate a pre-signed URL for the object with a specific key
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = key,
            };

            var url = client.GetPreSignedURL(request);
            return url;
        }

        public async Task<DownloadedFile> DownloadFile(string key)
        {
            var options = AWS3OptionsExtension.GetAWSConfigurationOptions(_configuration);
            var region = AWS3ConfigurationExtension.GetRgionAWS();
            var credential = AWS3ConfigurationExtension.GetBasicAWSCredentials(_configuration);
            var bucketName = options.DefaultBucket;

            using (var client = new AmazonS3Client(credential, region))
            {
                var getObjectRequest = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = key
                };

                using (var response = await client.GetObjectAsync(getObjectRequest))
                using (var streamReader = new StreamReader(response.ResponseStream))
                {
                    var fileContent = Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
                    var contentType = response.Headers.ContentType;
                    var fileName = response.Metadata["filename"]; // Make sure to set this when uploading the file

                    return new DownloadedFile(fileContent, contentType, fileName);
                }
            }
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

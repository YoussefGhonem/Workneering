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

                //var uploadRequest = new TransferUtilityUploadRequest()
                //{
                //    BucketName = bucketName,
                //    Key = fileNameStorage,
                //    InputStream = stream,
                //}; 

                var uploadRequest = new PutObjectRequest()
                {
                    BucketName = bucketName,
                    Key = fileNameStorage,
                    InputStream = stream,

                };
                var size = file.Length;
                var originalFileName = file.FileName;
                var extension = Path.GetExtension(originalFileName);

                string contentType = GetContentType(originalFileName);
                //uploadRequest.Metadata.Add("filename", $"{file.FileName}");
                uploadRequest.Metadata.Add("Content-Type", contentType);

                var client = new AmazonS3Client(credential, region);
                // upload to s3
                var transferUtility = new TransferUtility(client);
                await client.PutObjectAsync(uploadRequest, cancellationToken);



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

            var uploadedFiles = new List<StoredFile>();

            foreach (var file in files)
            {
                var result = await Upload(file, cancellationToken);
                uploadedFiles.Add(result);
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
        public async Task<string?> DownloadFileUrl(string? key)
        {
            try
            {
                if (string.IsNullOrEmpty(key)) return null;
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
                    Expires = DateTime.Now.AddHours(1) // Adjust expiration as needed

                };

                var url = client.GetPreSignedURL(request);
                return url;
            }
            catch (AmazonS3Exception e)
            {
                throw;

            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<DownloadedFile> DownloadFile(string key, CancellationToken cancellationToken)
        {
            var options = AWS3OptionsExtension.GetAWSConfigurationOptions(_configuration);
            var bucketName = options.DefaultBucket;
            var region = AWS3ConfigurationExtension.GetRgionAWS();
            var credential = AWS3ConfigurationExtension.GetBasicAWSCredentials(_configuration);
            using (var s3Client = new AmazonS3Client(credential, region))
            {
                using (var transferUtility = new TransferUtility(s3Client))
                {
                    var downloadRequest = new TransferUtilityDownloadRequest
                    {
                        BucketName = bucketName,
                        Key = key,
                        FilePath = "D:\\images\\" + key
                    };


                    // Download the file asynchronously
                    await transferUtility.DownloadAsync(downloadRequest, cancellationToken);

                    // Determine the content type based on the file extension
                    string contentType = GetContentType(key);

                    // Read the file from the local file path
                    var fileBytes = System.IO.File.ReadAllBytes(downloadRequest.FilePath);

                    // Return the file as a FileContentResult
                    return new DownloadedFile(fileBytes, contentType, key);

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

        private static string GetContentType(string? filePath)
        {

            // Determine content type based on file extension
            string extension = Path.GetExtension(filePath).ToLower();

            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".pdf":
                    return "application/pdf";
                // Add more cases for other file types as needed
                default:
                    return "application/octet-stream"; // Default content type for unknown types
            }
        }

        #endregion

    }
}

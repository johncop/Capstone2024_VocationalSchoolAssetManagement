using ASM.Services.Interfaces;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ASM.Services.Services
{
    public class BlobService : IBlobService
    {
        private readonly string _connectionString;
        private readonly string _containerName;

        public BlobService(IConfiguration congiguration)
        {
            _connectionString = congiguration["AzureBlobStorage:ConnectionString"];
            _containerName = congiguration["AzureBlobStorage:ContainerName"];
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            var blobContainerClient = new BlobContainerClient(_connectionString, _containerName);
            await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

            var blobClient = blobContainerClient.GetBlobClient(file.FileName);

            await using (var fileStream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
            }

            return blobClient.Uri.ToString();
        }

        public async Task<bool> DeleteASync(IFormFile file)
        {
            var isDeleted = false;
            var blobContainerClient = new BlobContainerClient(_connectionString, _containerName);
            await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

            var blobClient = blobContainerClient.GetBlobClient(file.FileName);
            var isBlobExists = await blobClient.ExistsAsync();
            if (!isBlobExists)
            {
                return isDeleted;
            }

            await blobClient.DeleteAsync();
            isDeleted = true;

            return isDeleted;
        }
    }
}

using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using RecipesApp.Application.Abstractions;

namespace RecipesApp.Infrastructure.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobClient;

        public BlobService(BlobServiceClient blobClient)
        {
            _blobClient = blobClient;
        }

        public async Task DeleteBlob(string name, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<string> UploadBlob(string name, IFormFile file, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };
            
            await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);
            var blobUrl = blobClient.Uri.AbsoluteUri;

            return blobUrl;
        }
    }
}

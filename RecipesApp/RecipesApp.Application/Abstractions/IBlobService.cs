using Microsoft.AspNetCore.Http;

namespace RecipesApp.Application.Abstractions
{
    public interface IBlobService
    {
        Task<string> UploadBlob(string name, IFormFile file, string containerName);
        Task DeleteBlob(string name, string containerName);
    }
}

using Microsoft.AspNetCore.Http;

namespace RecipesApp.Application.Abstractions.Services
{
    public interface IImageStorageService
    {
        Task<string> UploadImage(string name, IFormFile file, string containerName);
        Task DeleteImage(string name, string containerName);
    }
}

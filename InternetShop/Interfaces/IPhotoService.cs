using CloudinaryDotNet.Actions;

namespace InternetShop.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult>DeletePhotoAsync(string publicId);

    }
}

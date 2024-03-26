using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository.ImageRepository
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}

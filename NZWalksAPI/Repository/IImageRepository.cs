using NZWalksAPI.Model.Domain;

namespace NZWalksAPI.Repository
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}

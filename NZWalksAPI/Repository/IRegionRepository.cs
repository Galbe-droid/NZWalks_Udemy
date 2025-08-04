using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Model.Domain;

namespace NZWalksAPI.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> CreateAsync(Region region);
        Task<Region?> UpdateAsync(Region region, Guid id);
        Task<Region?> DeleteAsync(Guid id);

    }
}

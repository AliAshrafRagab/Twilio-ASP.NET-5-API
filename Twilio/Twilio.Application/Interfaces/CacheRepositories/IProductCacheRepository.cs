using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Domain.Entities.Catalog;

namespace Twilio.Application.Interfaces.CacheRepositories
{
    public interface IBrandCacheRepository
    {
        Task<List<Brand>> GetCachedListAsync();

        Task<Brand> GetByIdAsync(int brandId);
    }
}
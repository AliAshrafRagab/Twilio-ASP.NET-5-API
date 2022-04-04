using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Domain.Entities.Catalog;

namespace Twilio.Application.Interfaces.CacheRepositories
{
    public interface IProductCacheRepository
    {
        Task<List<Product>> GetCachedListAsync();

        Task<Product> GetByIdAsync(int brandId);
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio.Domain.Entities.Catalog;

namespace Twilio.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        Task<List<Product>> GetListAsync();

        Task<Product> GetByIdAsync(int productId);

        Task<int> InsertAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);
    }
}
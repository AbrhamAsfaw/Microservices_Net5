using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Catalog.Service.Entities;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;


namespace Play.Catalog.Service.Repositories
{
    public interface IItemsRepository
    {
        Task CreateAsync(Item entity);
        Task DeleteAsync(Guid id);
        Task<IReadOnlyCollection<Item>> GetAllAsync();
        Task<Item> GetAsync(Guid id);
        Task UpdateAsync(Item entity);
    }
}
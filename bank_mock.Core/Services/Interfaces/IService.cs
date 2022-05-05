using System.Collections.Generic;
using System.Threading.Tasks;
using bank_mock.Core.Models.Interfaces;

namespace bank_mock.Core.Services.Interfaces
{
    public interface IService<TEntity>
        where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(long id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
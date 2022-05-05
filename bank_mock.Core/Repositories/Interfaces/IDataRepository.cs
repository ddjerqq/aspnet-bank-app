using System.Collections.Generic;
using System.Threading.Tasks;
using bank_mock.Core.Models.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace bank_mock.Core.Repositories.Interfaces
{
    public interface IDataRepository<TEntity> 
        where TEntity : BaseEntity
    {
        public Task<List<TEntity>> GetAllAsync();
        public Task<TEntity> GetAsync(long id);
        public Task AddAsync(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public Task SaveChangesAsync();
    }
}
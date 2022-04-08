using System.Collections.Generic;
using bank_mock.Core.Models.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace bank_mock.Core.Repositories.Interfaces
{
    public interface IDataRepository<TEntity> 
        where TEntity : BaseEntity
    {
        public List<TEntity> GetAll();
        public TEntity Get(long id);
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public void SaveChanges();
    }
}
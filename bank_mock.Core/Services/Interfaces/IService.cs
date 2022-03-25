using System.Collections.Generic;
using bank_mock.Core.Models.Interfaces;

namespace bank_mock.Core.Services.Interfaces
{
    public interface IService<TEntity>
    {
        List<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
using System.Collections.Generic;
using System.Linq;
using bank_mock.Core.Contexts;
using bank_mock.Core.Models;
using bank_mock.Core.Models.Interfaces;
using bank_mock.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bank_mock.Core.Repositories
{
    // es aris `User`Repository, mashin rat gvinda aq generic interfacebi?
    public sealed class DataRepository<TEntity> : IDataRepository<TEntity>
    where TEntity : BaseEntity
    {
        // TODO es rato arsebobs lol
        // mtliani generic interface,
        // 
        private readonly UserContext _userContext;
        
        public DbSet<TEntity> DbSet { get; }

        public DataRepository(UserContext userContext)
        {
            _userContext = userContext;
            DbSet = _userContext.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public TEntity Get(long id)
        {
            return DbSet.FirstOrDefault(i => i.Id == id);
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
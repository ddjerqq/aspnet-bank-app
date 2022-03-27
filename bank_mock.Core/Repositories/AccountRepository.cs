using System.Collections.Generic;
using System.Linq;
using bank_mock.Core.Contexts;
using bank_mock.Core.Models;
using bank_mock.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bank_mock.Core.Repositories
{
    public class AccountRepository : IDataRepository<Account>
    {
        private readonly AccountContext _accountContext;
        public DbSet<Account> DbSet { get; }

        // TODO aq IDataRepository<Account> repository es xom ar mwirdeba
        // context-is magivrad
        public AccountRepository(AccountContext context)
        {
            _accountContext = context;
            DbSet = _accountContext.Set<Account>();
        }
        
        public List<Account> GetAll()
        {
            return DbSet.ToList();
        }

        public Account Get(long id)
        {
            return DbSet.FirstOrDefault(e => 
                e.Id == id);
        }

        public void Add(Account entity)
        {
            DbSet.Add(entity);
            _accountContext.SaveChanges();
        }

        public void Update(Account entity)
        {
            DbSet.Update(entity);
            _accountContext.SaveChanges();
        }

        public void Delete(Account entity)
        {
            DbSet.Remove(entity);
            _accountContext.SaveChanges();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using bank_mock.Core.Contexts;
using bank_mock.Core.Models;
using bank_mock.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bank_mock.Core.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDatabaseContext _accountContext;

        public AccountRepository(ApplicationDatabaseContext context)
        {
            _accountContext = context;
        }
        
        public List<Account> GetAll()
        {
            return _accountContext.Accounts.ToList();
        }
        
        public Account Get(long id)
        {
            return _accountContext.Accounts.FirstOrDefault(e => 
                e.Id == id);
        }
        
        public void Add(Account acc)
        {
            _accountContext.Accounts.Add(acc);
        }
        
        public void Update(Account acc)
        {
            _accountContext.Accounts.Update(acc);
        }
        
        public void Delete(Account acc)
        {
            _accountContext.Accounts.Remove(acc);
        }

        public void SaveChanges()
        {
            _accountContext.SaveChanges();
        }
    }
}
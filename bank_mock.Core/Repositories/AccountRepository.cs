using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public async Task<List<Account>> GetAllAsync()
        {
            return await _accountContext.Accounts.ToListAsync();
        }
        
        public async Task<Account> GetAsync(long id)
        {
            return await _accountContext.Accounts.FirstOrDefaultAsync(e => 
                e.Id == id);
        }
        
        public async Task AddAsync(Account acc)
        {
            await _accountContext.Accounts.AddAsync(acc);
        }

        public void Update(Account acc)
        {
            _accountContext.Accounts.Update(acc);
        }
        
        public void Delete(Account acc)
        {
            _accountContext.Accounts.Remove(acc);
        }

        public async Task SaveChangesAsync()
        {
            await _accountContext.SaveChangesAsync();
        }
    }
}
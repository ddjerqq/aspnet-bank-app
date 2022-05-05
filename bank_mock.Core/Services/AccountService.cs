using System.Collections.Generic;
using System.Threading.Tasks;
using bank_mock.Core.Models;
using bank_mock.Core.Repositories;
using bank_mock.Core.Repositories.Interfaces;
using bank_mock.Core.Services.Interfaces;

namespace bank_mock.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        
        public AccountService(IAccountRepository repository)
        {
            _accountRepository = repository;
        }
        
        public async Task<List<Account>> GetAllAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        public async Task<Account> GetAsync(long id)
        {
            return await _accountRepository.GetAsync(id);
        }

        public async Task AddAsync(Account entity)
        {
            await _accountRepository.AddAsync(entity);
            await _accountRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account entity)
        {
            _accountRepository.Update(entity);
            await _accountRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Account entity)
        {
            _accountRepository.Delete(entity);
            await _accountRepository.SaveChangesAsync();
        }
    }
}
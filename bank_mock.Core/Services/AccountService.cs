using System.Collections.Generic;
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
        
        public List<Account> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public Account Get(long id)
        {
            return _accountRepository.Get(id);
        }

        public void Add(Account entity)
        {
            _accountRepository.Add(entity);
            _accountRepository.SaveChanges();
        }

        public void Update(Account entity)
        {
            _accountRepository.Update(entity);
            _accountRepository.SaveChanges();
        }

        public void Delete(Account entity)
        {
            _accountRepository.Delete(entity);
            _accountRepository.SaveChanges();
        }
    }
}
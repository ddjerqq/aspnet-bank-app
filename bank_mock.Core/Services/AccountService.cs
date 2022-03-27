using System.Collections.Generic;
using bank_mock.Core.Models;
using bank_mock.Core.Repositories.Interfaces;
using bank_mock.Core.Services.Interfaces;

namespace bank_mock.Core.Services
{
    public class AccountService : IService<Account>
    {
        private readonly IDataRepository<Account> _accountRepository;
        
        // TODO es cudia?
        public AccountService(IDataRepository<Account> repository)
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
        }

        public void Update(Account entity)
        {
            _accountRepository.Update(entity);
        }

        public void Delete(Account entity)
        {
            _accountRepository.Delete(entity);
        }
    }
}
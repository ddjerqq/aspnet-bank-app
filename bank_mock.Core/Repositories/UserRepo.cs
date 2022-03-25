using System.Collections.Generic;
using bank_mock.Core.Models;
using bank_mock.Core.Repositories.Interfaces;

namespace bank_mock.Core.Repositories
{
    public class UserRepo : IUserRepo
    {
        // TODO ar sheidzleba es iyos IDataRepository<User>-is inheritori?
        private readonly IDataRepository<User> _repository;

        public UserRepo(IDataRepository<User> repository)
        {
            _repository = repository;
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User Get(long id)
        {
            return _repository.Get(id);
        }

        public void Add(User entity)
        {
            _repository.Add(entity);
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
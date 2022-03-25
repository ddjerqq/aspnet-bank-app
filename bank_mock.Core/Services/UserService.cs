using System.Collections.Generic;
using bank_mock.Core.Models;
using bank_mock.Core.Models.Interfaces;
using bank_mock.Core.Repositories;
using bank_mock.Core.Repositories.Interfaces;
using bank_mock.Core.Services.Interfaces;

namespace bank_mock.Core.Services
{
    public class UserService : IService<User>
    {
        // TODO amis interface aq rat gvinda?
        // ar sheidzleba ro UserRepo iyos calke da UserRepo iyos
        // IDataRepositoris inheritori?
        private readonly IUserRepo _userRepository;

        public UserService(IUserRepo userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Get(long id)
        {
            return _userRepository.Get(id);
        }

        public void Add(User entity)
        {
            _userRepository.Add(entity);
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
        }

        public void Delete(User entity)
        {
            _userRepository.Delete(entity);
        }
    }
}
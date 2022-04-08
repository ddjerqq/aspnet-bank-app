using System.Collections.Generic;
using bank_mock.Core.Models;
using bank_mock.Core.Models.Interfaces;
using bank_mock.Core.Repositories;
using bank_mock.Core.Repositories.Interfaces;
using bank_mock.Core.Services.Interfaces;

namespace bank_mock.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
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
            _userRepository.SaveChanges();
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
            _userRepository.SaveChanges();
        }

        public void Delete(User entity)
        {
            _userRepository.Delete(entity);
            _userRepository.SaveChanges();
        }
    }
}
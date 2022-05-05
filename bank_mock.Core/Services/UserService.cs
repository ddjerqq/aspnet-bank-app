using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetAsync(long id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task AddAsync(User entity)
        {
            await _userRepository.AddAsync(entity);
            await _userRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _userRepository.Update(entity);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            _userRepository.Delete(entity);
            await _userRepository.SaveChangesAsync();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bank_mock.Core.Contexts;
using bank_mock.Core.Models;
using bank_mock.Core.Models.Interfaces;
using bank_mock.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bank_mock.Core.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDatabaseContext _context;
        
        public UserRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetAsync(long id)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(User user)
        {
           await _context.Users.AddAsync(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
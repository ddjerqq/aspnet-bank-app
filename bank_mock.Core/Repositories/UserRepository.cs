using System.Collections.Generic;
using System.Linq;
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

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Get(long id)
        {
            return _context.Users.FirstOrDefault(i => i.Id == id);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
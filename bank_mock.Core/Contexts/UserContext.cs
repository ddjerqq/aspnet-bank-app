using bank_mock.Core.Models;
using bank_mock.Core.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bank_mock.Core.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) :
            base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
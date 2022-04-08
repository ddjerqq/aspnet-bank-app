using bank_mock.Core.Models;
using bank_mock.Core.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bank_mock.Core.Contexts
{
    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) :
            base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
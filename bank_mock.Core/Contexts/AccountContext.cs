using bank_mock.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace bank_mock.Core.Contexts
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : 
            base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
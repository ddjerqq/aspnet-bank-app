using System.Collections;
using System.Collections.Generic;
using bank_mock.Core.Models.Interfaces;

namespace bank_mock.Core.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public  ICollection<Account> Accounts { get; set; }
    }
}
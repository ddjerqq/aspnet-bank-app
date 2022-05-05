using bank_mock.Core.Models.Interfaces;

namespace bank_mock.Core.Models
{
    public class AccountDto
    {
        public decimal AvailableFunds { get; set; }
        public string IBAN { get; set; }
        public long UserId { get; set; }
        public UserDto User { get; set; }
    }
}
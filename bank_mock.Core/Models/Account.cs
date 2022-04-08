using bank_mock.Core.Models.Interfaces;

namespace bank_mock.Core.Models
{
    public class Account : BaseEntity
    {
        public decimal AvailableFunds { get; set; }
        public string IBAN { get; set; }
        
        public User User { get; set; }
        public long UserId { get; set; }
    }
}
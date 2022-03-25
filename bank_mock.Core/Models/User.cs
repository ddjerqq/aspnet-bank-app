using bank_mock.Core.Models.Interfaces;

namespace bank_mock.Core.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
    }
}
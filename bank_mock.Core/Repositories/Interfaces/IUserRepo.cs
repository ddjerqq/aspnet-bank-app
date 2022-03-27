using System.Collections.Generic;
using bank_mock.Core.Models;
using bank_mock.Core.Services.Interfaces;

// TODO es ro movashorot aqedan?
// da marto IDataRepository<> davtovot
// da mart UserRepository davtovot. 
// da mere agar dagvwirdeba es interface

namespace bank_mock.Core.Repositories.Interfaces
{
    public interface IUserRepo : IService<User>
    {
        // TODO es rat gvinda saertod?
        // unit testingistvis?
    }
}
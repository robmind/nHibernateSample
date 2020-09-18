using System.Collections.Generic;

namespace NilexTicket.DB.Repositories.Interfaces
{
    public interface IUserRepositoty : IEntityRepository<User>
    {
        User LoadByLogin(string login);
        IEnumerable<User> LoadAllUser();
    }
}

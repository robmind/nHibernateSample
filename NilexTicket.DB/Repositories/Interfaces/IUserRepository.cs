using System.Collections.Generic;

namespace NilexTicket.DB.Repositories.Interfaces
{
    public interface IUserRepositoty : IEntityRepository<User>
    {
        User GetUserByLogin(string login);
        IEnumerable<User> GetAllUser();
        IEnumerable<User> GetAllUserByRoleId(string role);
        User GetUserByUserId(int id);
        void DeleteUser(int id);
        void DeleteUserData(int id);
    }
}

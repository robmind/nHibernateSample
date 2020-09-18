using System.Collections.Generic;
using NilexTicket.DB.Repositories.Interfaces;

namespace NilexTicket.DB.Repositories
{
    public class NHUserRepository : NHBaseRepository<User>, IUserRepositoty
    {
        public User LoadByLogin(string Username)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var user = session.QueryOver<User>()
                .Where(us => us.Username == Username)
                .SingleOrDefault();

            NHibernateHelper.CloseSession();

            return user;
        }

        public IEnumerable<User> LoadAllUser()
        {
            var session = NHibernateHelper.GetCurrentSession();

            var user = session.QueryOver<User>().List();

            NHibernateHelper.CloseSession();

            return user;
        }
    }
}

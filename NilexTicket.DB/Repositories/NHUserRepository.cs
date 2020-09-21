using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NilexTicket.DB.Repositories.Interfaces;

namespace NilexTicket.DB.Repositories
{
    public class NHUserRepository : NHBaseRepository<User>, IUserRepositoty
    {
        public User GetUserByLogin(string Username)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var user = session.QueryOver<User>()
                .Where(us => us.Username == Username && us.IsDeleted == false)
                .SingleOrDefault();

            NHibernateHelper.CloseSession();

            return user;
        }

        public IEnumerable<User> GetAllUser()
        {
            var session = NHibernateHelper.GetCurrentSession();

            var user = session.QueryOver<User>().Where(n =>  n.IsDeleted == false).List();

            NHibernateHelper.CloseSession();

            return user;
        }
        public IEnumerable<User> GetAllUserByRoleId(string role)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var user = session.QueryOver<User>().Where(x => x.Role == role && x.IsDeleted == false).List().OrderBy(x => x.Username);

            NHibernateHelper.CloseSession();

            return user;
        }

        public User GetUserByUserId(int id)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var user = session.QueryOver<User>().Where(x => x.ID == id && x.IsDeleted == false).SingleOrDefault();

            NHibernateHelper.CloseSession();

            return user;
        }

        public void DeleteUser(int id)
        {
            var session = NHibernateHelper.GetCurrentSession();

            //session.Delete("delete from Tickets where UserID = ?", id, NHibernateUtil.Int32);
            //session.Delete("delete from Comments where UserID = ?", id, NHibernateUtil.Int32);

            session.CreateSQLQuery("update Users set IsDeleted = 1, DeleteDate = GETDATE() where ID = " + id).ExecuteUpdate();
            session.CreateSQLQuery("update Tickets set IsDeleted = 1, DeleteDate = GETDATE() where UserID = " + id).ExecuteUpdate();
            session.CreateSQLQuery("update Comments set IsDeleted = 1, DeleteDate = GETDATE() where UserID = " + id).ExecuteUpdate();

            NHibernateHelper.CloseSession();
        }

        public void DeleteUserData(int id)
        {
            var session = NHibernateHelper.GetCurrentSession();

            //session.Delete("delete from Tickets where UserID = ?", id, NHibernateUtil.Int32);
            //session.Delete("delete from Comments where UserID = ?", id, NHibernateUtil.Int32);

            session.CreateSQLQuery("update Tickets set IsDeleted = 1, DeleteDate = GETDATE() where UserID = " + id).ExecuteUpdate();
            session.CreateSQLQuery("update Comments set IsDeleted = 1, DeleteDate = GETDATE() where UserID = " + id).ExecuteUpdate();

            NHibernateHelper.CloseSession();
        }
    }
}

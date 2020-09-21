using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;
using NilexTicket.DB;
using NilexTicket.DB.Repositories;
using NilexTicket.DB.Repositories.Interfaces;

namespace NilexComment.DB.Repositories
{
    public class NHCommentRepository : NHBaseRepository<Comment>, ICommentRepository
    {
        public IEnumerable<Comment> GetAllCommentByTitle(string title)
        {
            var session = NHibernateHelper.GetCurrentSession();
            var notes = session.QueryOver<Comment>()
                .Where(Restrictions.On<Comment>(note => note.Explanation).IsLike($"%{title}%"))
                .Where(n => n.IsDeleted == false)
                .List();

            NHibernateHelper.CloseSession();

            return notes;
        }

        public IEnumerable<Comment> GetAllPublishedComment()
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Comment>()
                .Where(n => n.IsDeleted == false).List();

            NHibernateHelper.CloseSession(); ;

            return notes;
        }

        public IEnumerable<Comment> GetAllCommentByUserId(int userId)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Comment>()
                .Where(note => note.User.ID == userId && note.IsDeleted == false)
                .List();

            NHibernateHelper.CloseSession(); ;

            return notes;
        }

        public IEnumerable<Comment> GetAllAvailableCommentByUserId(int userId)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Comment>()
                .Where(note => note.User.ID == userId && note.IsDeleted == false)
                .List();

            NHibernateHelper.CloseSession(); ;

            return notes;
        }

        public IEnumerable<Comment> GetAllCommentByTicketId(int ticket)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Comment>()
                .Where(note => note.Ticket.ID == ticket && note.IsDeleted == false)
                .List();

            NHibernateHelper.CloseSession(); ;

            return notes;
        }
    }
}

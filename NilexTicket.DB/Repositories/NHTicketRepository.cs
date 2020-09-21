using NHibernate.Criterion;
using NilexTicket.DB.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NilexTicket.DB.Repositories
{
    public class NHTicketRepository : NHBaseRepository<Ticket>, ITicketRepository
    {
        public IEnumerable<Ticket> GetAllTicketByTitle(string title)
        {
            var session = NHibernateHelper.GetCurrentSession();
            var notes = session.QueryOver<Ticket>()
                .Where(Restrictions.On<Ticket>(note => note.Title).IsLike($"%{title}%"))
                .Where(n => n.IsDeleted == false)
                .List();

            NHibernateHelper.CloseSession();

            return notes;
        }
          
        public IEnumerable<Ticket> GetAllTicket()
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Ticket>().Where(n => n.IsDeleted == false).List().ToList();

            NHibernateHelper.CloseSession(); ;

            return notes;
        }

        public IEnumerable<Ticket> GetAllTicketByIsItRead()
        {
            return GetAllTicket().OrderByDescending(z => z.Status).ThenBy(x => x.IsItRead);
        }

        public IEnumerable<Ticket> GetAllTicketByUserId(int userId)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Ticket>()
                .Where(note => note.User.ID == userId && note.IsDeleted == false)
                .List();

            NHibernateHelper.CloseSession(); ;

            return notes;
        }

        public Ticket GetTicketByFilename(string filename)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var user = session.QueryOver<Ticket>().Where(x => x.ImageUrl == filename).SingleOrDefault();

            NHibernateHelper.CloseSession();

            return user;
        }

        public Ticket GetTicketByTicketId(int ticketid)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var user = session.QueryOver<Ticket>().Where(x => x.ID == ticketid && x.IsDeleted == false).SingleOrDefault();

            NHibernateHelper.CloseSession();

            return user;
        }
    }
}

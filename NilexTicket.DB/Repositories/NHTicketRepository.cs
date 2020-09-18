using NHibernate.Criterion;
using NilexTicket.DB.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NilexTicket.DB.Repositories
{
    public class NHTicketRepository : NHBaseRepository<Ticket>, ITicketRepository
    {
        public IEnumerable<Ticket> FindByTitle(string title)
        {
            var session = NHibernateHelper.GetCurrentSession();
            var notes = session.QueryOver<Ticket>()
                .Where(Restrictions.On<Ticket>(note => note.Title).IsLike($"%{title}%"))
                .List();

            NHibernateHelper.CloseSession();

            return notes;
        }
          
        public IEnumerable<Ticket> LoadAllPublished()
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Ticket>()
                .List();

            NHibernateHelper.CloseSession(); ;

            return notes;
        }

        public IEnumerable<Ticket> LoadByUser(int userId)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Ticket>()
                .Where(note => note.User.ID == userId)
                .List();

            NHibernateHelper.CloseSession(); ;

            return notes;
        }
        
        public IEnumerable<Ticket> LoadAllAvailable(int userId)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Ticket>()
                .Where(note => note.User.ID == userId)
                .List();

            NHibernateHelper.CloseSession(); ;

            return notes;
        }


        //public override void Save(Note entity)
        //{
            //var session = NHibernateHelper.GetCurrentSession();
            
            //try
            //{
            //    var q = session.CreateSQLQuery(
            //        $"EXEC SaveNote @Title=:title,@Published=:published,@Text=:text,@Tags=:tags," +
            //        $"@CreationDate=:date,@UserId=:userId,@BinaryFile=:fileData,@FileType=:fileType")
            //    .SetString("title", entity.Title)
            //    .SetBoolean("published", entity.Published)
            //    .SetString("text", entity.Text)
            //    .SetString("tags", entity.Tags)
            //    .SetDateTime("date", entity.CreationDate)
            //    .SetInt64("userId", entity.User.Id)
            //    .SetParameter("fileData", entity.BinaryFile)
            //    .SetString("fileType", entity.FileType)
            //    .UniqueResult();
            //}
            //finally
            //{
            //    NHibernateHelper.CloseSession();
            //}
        //}
    }
}

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
        public IEnumerable<Comment> FindByTitle(string title)
        {
            var session = NHibernateHelper.GetCurrentSession();
            var notes = session.QueryOver<Comment>()
                .Where(Restrictions.On<Comment>(note => note.Explanation).IsLike($"%{title}%"))
                .List();

            NHibernateHelper.CloseSession();

            return notes;
        }

        public IEnumerable<Comment> LoadAllPublished()
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Comment>()
                .List();

            NHibernateHelper.CloseSession(); ;

            return notes;
        }

        public IEnumerable<Comment> LoadByUser(int userId)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Comment>()
                .Where(note => note.User.ID == userId)
                .List();

            NHibernateHelper.CloseSession(); ;

            return notes;
        }

        public IEnumerable<Comment> LoadAllAvailable(int userId)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Comment>()
                .Where(note => note.User.ID == userId)
                .List();

            NHibernateHelper.CloseSession(); ;

            return notes;
        }

        public IEnumerable<Comment> LoadByTicket(int ticket)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var notes = session.QueryOver<Comment>()
                .Where(note => note.Ticket.ID == ticket)
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

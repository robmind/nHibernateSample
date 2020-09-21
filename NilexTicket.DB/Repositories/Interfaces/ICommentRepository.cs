using System.Collections.Generic;

namespace NilexTicket.DB.Repositories.Interfaces
{
    public interface ICommentRepository : IEntityRepository<Comment>
    {
        IEnumerable<Comment> GetAllCommentByTitle(string title);
        IEnumerable<Comment> GetAllPublishedComment();
        IEnumerable<Comment> GetAllCommentByUserId(int userId);
        IEnumerable<Comment> GetAllCommentByTicketId(int ticket);
        IEnumerable<Comment> GetAllAvailableCommentByUserId(int userId);
    }
}

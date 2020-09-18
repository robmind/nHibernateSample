using System.Collections.Generic;

namespace NilexTicket.DB.Repositories.Interfaces
{
    public interface ICommentRepository : IEntityRepository<Comment>
    {
        IEnumerable<Comment> FindByTitle(string title);
        IEnumerable<Comment> LoadAllPublished();
        IEnumerable<Comment> LoadByUser(int userId);
        IEnumerable<Comment> LoadByTicket(int ticket);
        IEnumerable<Comment> LoadAllAvailable(int userId);
    }
}

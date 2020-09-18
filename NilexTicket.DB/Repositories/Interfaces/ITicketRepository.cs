using System.Collections.Generic;

namespace NilexTicket.DB.Repositories.Interfaces
{
    public interface ITicketRepository : IEntityRepository<Ticket>
    {
        IEnumerable<Ticket> FindByTitle(string title);
        IEnumerable<Ticket> LoadAllPublished();
        IEnumerable<Ticket> LoadByUser(int userId);
        IEnumerable<Ticket> LoadAllAvailable(int userId);
    }
}
using System.Collections.Generic;

namespace NilexTicket.DB.Repositories.Interfaces
{
    public interface ITicketRepository : IEntityRepository<Ticket>
    {
        IEnumerable<Ticket> GetAllTicketByTitle(string title);
        IEnumerable<Ticket> GetAllTicket();
        Ticket GetTicketByTicketId(int ticketid);
        IEnumerable<Ticket> GetAllTicketByIsItRead();
        IEnumerable<Ticket> GetAllTicketByUserId(int userId);
        Ticket GetTicketByFilename(string filename);
    }
}
using TicketManagement.Models;

namespace TicketManagement.Repositories.RepositoryInterface
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Task<Event> GetById(long id);
        void Update(Event @event);
        void Delete(Event @event);
    }
}

using Microsoft.EntityFrameworkCore;
using TicketManagement.Models;
using TicketManagement.Repositories.RepositoryInterface;

namespace TicketManagement.Repositories.RepositoryImplementation
{
    public class EventRepository : IEventRepository
    {
        private readonly TicketManagementContext _ticketManagementContext;
        public EventRepository() 
        {
            _ticketManagementContext = new TicketManagementContext();
        }
        public IEnumerable<Event> GetAll()
        {
            var events =  _ticketManagementContext.Events
                .Include(e => e.Venue)
                .Include(e=>e.TicketCategories)
                .Include(e=>e.EventType);
            return events;
        }

        public async Task<Event> GetById(long id)
        {
            var @event = await _ticketManagementContext.Events
                .Include(e=>e.TicketCategories)
                .Include(e=>e.EventType)
                .Include(e=>e.Venue)
                .Where(e => e.EventId == id).FirstOrDefaultAsync();
            return @event;
        }
        public void Update(Event @event)
        {
            _ticketManagementContext.Entry(@event).State = EntityState.Modified;
            _ticketManagementContext.SaveChanges();
        }
        public void Delete(Event @event)
        {
            _ticketManagementContext.Remove(@event);
            _ticketManagementContext.SaveChanges();
        }
    }
}

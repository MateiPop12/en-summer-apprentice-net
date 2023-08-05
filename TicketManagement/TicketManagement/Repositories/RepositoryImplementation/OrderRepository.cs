using Microsoft.EntityFrameworkCore;
using TicketManagement.Models;
using TicketManagement.Repositories.RepositoryInterface;

namespace TicketManagement.Repositories.RepositoryImplementation;

public class OrderRepository : IOrderRepository
{
    private readonly TicketManagementContext _ticketManagementContext;

    public OrderRepository()
    {
        _ticketManagementContext = new TicketManagementContext();
    }
    public IEnumerable<Order> GetAll()
    {
        var orders = _ticketManagementContext.Orders
            .Include(e => e.TicketCategory);
        return orders;
    }

    public async Task<Order> GetOrderById(long id)
    {
        var @order = await _ticketManagementContext.Orders
            .Where(o => o.OrderId == id).FirstOrDefaultAsync();
        return @order;
    }

    public void Create(Order order)
    {
        throw new NotImplementedException();
    }

    public void Update(Order order)
    {
        _ticketManagementContext.Entry(@order).State = EntityState.Modified;
        _ticketManagementContext.SaveChanges();
    }

    public void Delete(Order order)
    {
        _ticketManagementContext.Remove(@order);
        _ticketManagementContext.SaveChanges();
    }
}
using TicketManagement.Models;

namespace TicketManagement.Repositories.RepositoryInterface;

public interface IOrderRepository
{
    IEnumerable<Order> GetAll();
    Task<Order> GetOrderById(long id);
    void Create(Order @order);
    void Update(Order @order);
    void Delete(Order @order);

}
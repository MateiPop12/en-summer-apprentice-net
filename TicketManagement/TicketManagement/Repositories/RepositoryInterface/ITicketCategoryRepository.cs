using TicketManagement.Models;

namespace TicketManagement.Repositories.RepositoryInterface;

public interface ITicketCategoryRepository
{
    Task<TicketCategory> GetById(long id);
}